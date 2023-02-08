using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DB_CourseWork.Core.Data;

namespace DB_CourseWork.Core
{
    public class FeeService : IFeeService
    {
        private readonly PbxContext _context;

        private readonly IList<SubscriberPhone> _phones;

        // TODO: Refactor this garbage (move to PhoneStatusService)
        private readonly List<PhoneStatus> _phoneStatuses;
        private readonly PhoneStatus _connectedStatus;
        private readonly PhoneStatus _debtStatus;

        public FeeService(PbxContext context)
        {
            _context = context;

            _phones = _context.SubscriberPhones
                .Include(p => p.StatusHistory.Select(e => e.Status))
                .Include(p => p.TariffHistory.Select(e => e.Tariff))
                .ToList();

            _phoneStatuses = _context.PhoneStatuses.OrderBy(s => s.Id).ToList();
            _connectedStatus = _phoneStatuses[0];
            _debtStatus = _phoneStatuses[2];
        }

        public IList<SubscriberPhone> GetDebtorPhones()
        {
            return _phones.Where(p => p.AccountBalance < 0 || p.CurrentStatus == _debtStatus).ToList();
        }

        public IList<PhoneStatus> GetStatuses()
        {
            return _phoneStatuses;
        }

        public DebtCalculationResult UpdateDebts()
        {
            decimal debtsTotal = 0;
            decimal debtsPaid = 0;
            decimal newDebt = 0;

            foreach (var phone in _phones)
            {
                if (phone.CurrentStatus == _debtStatus)
                {
                    if (phone.AccountBalance >= 0)
                    {
                        DateTime debtDate = phone.StatusHistory.Last().DateTime;
                        decimal paymentsAmountSinceDebt = CalculateTotalPaymentAmount(phone, debtDate);
                        debtsPaid += Math.Abs(phone.AccountBalance - paymentsAmountSinceDebt);

                        SetNewPhoneStatus(phone, _connectedStatus);
                    }
                    else
                    {
                        debtsTotal += -phone.AccountBalance;
                    }
                }
                else if (phone.CurrentStatus == _connectedStatus)
                {
                    if (phone.AccountBalance < 0)
                    {
                        newDebt += -phone.AccountBalance;

                        SetNewPhoneStatus(phone, _debtStatus);
                    }
                }
            }

            _context.SaveChanges();

            return new DebtCalculationResult(debtsTotal + newDebt, debtsPaid, newDebt);
        }

        public FeeCalculationResult MakeTariffPayments()
        {
            int count = 0;
            decimal feesTotal = 0;
            foreach (var phone in _phones.Where(p => p.AccountBalance >= 0 && p.CurrentStatus == _connectedStatus))
            {
                feesTotal += MakeTariffPayment(phone);
                ++count;
            }

            return new FeeCalculationResult(count, feesTotal);
        }

        private decimal MakeTariffPayment(SubscriberPhone phone)
        {
            decimal fee = phone.TariffHistory.Last().Tariff.SubscriptionFee;
            if (phone.IsReducedRate) fee /= 2;
            phone.AccountBalance -= fee;
            return fee;
        }

        // TODO: Move to PhoneStatusService
        private void SetNewPhoneStatus(SubscriberPhone phone, PhoneStatus newStatus, string comment = "")
        {
            var newStatusEntry = new StatusHistoryEntry(phone, newStatus, DateTime.Now, comment);
            phone.StatusHistory.Add(newStatusEntry);
        }

        private decimal CalculateTotalPaymentAmount(SubscriberPhone phone, DateTime startDate)
        {
            decimal totalAmount = 0;
            foreach (var payment in phone.Payments.Where(p => p.DateTime > startDate))
            {
                totalAmount += payment.Amount;
            }

            return totalAmount;
        }
    }
}
