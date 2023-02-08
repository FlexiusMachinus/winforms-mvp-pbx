using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DB_CourseWork
{
    public class FeeService : IFeeService
    {
        private readonly PbxContext _context;

        private readonly IList<SubscriberPhone> _phones;
        private readonly IList<PhoneStatus> _phoneStatuses;

        private readonly PhoneStatus _connectedStatus;
        private readonly PhoneStatus _disconnectedStatus;
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
            _disconnectedStatus = _phoneStatuses[1];
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
                        DateTime debtDate = phone.StatusHistory.Last().DateTime.Value;
                        decimal paymentsAmountSinceDebt = CalculateTotalPaymentAmount(phone, debtDate);
                        debtsPaid += Math.Abs(phone.AccountBalance - paymentsAmountSinceDebt);

                        var newStatusEntry = new StatusHistoryEntry(phone, _connectedStatus, DateTime.Now, string.Empty);
                        phone.StatusHistory.Add(newStatusEntry);
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

                        var newStatusEntry = new StatusHistoryEntry(phone, _debtStatus, DateTime.Now, string.Empty);
                        phone.StatusHistory.Add(newStatusEntry);
                    }
                }
            }

            _context.SaveChanges();

            return new DebtCalculationResult(debtsTotal + newDebt, debtsPaid, newDebt);
        }

        public FeeCalculationResult CalculateFees()
        {
            int count = 0;
            decimal feesTotal = 0;

            foreach (var phone in _phones.Where(p => p.CurrentStatus == _connectedStatus))
            {
                decimal fee = phone.TariffHistory.Last().Tariff.SubscriptionFee;
                if (phone.IsReducedRate) fee /= 2;
                phone.AccountBalance -= fee;

                feesTotal += fee;
                ++count;
            }

            return new FeeCalculationResult(count, feesTotal);
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
