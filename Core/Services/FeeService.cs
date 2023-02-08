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
        private readonly IPhoneStatusService _statusService;

        private readonly IList<SubscriberPhone> _phones;

        public FeeService(PbxContext context, IPhoneStatusService statusService)
        {
            _context = context;
            _statusService = statusService;

            _phones = _context.SubscriberPhones
                .Include(p => p.StatusHistory.Select(e => e.Status))
                .Include(p => p.TariffHistory.Select(e => e.Tariff))
                .ToList();
        }

        public IList<SubscriberPhone> GetDebtorPhones()
        {
            return _phones.Where(p => p.AccountBalance < 0 || _statusService.IsPhoneDebtor(p)).ToList();
        }

        public DebtCalculationResult UpdateDebts()
        {
            decimal debtsTotal = 0;
            decimal debtsPaid = 0;
            decimal newDebt = 0;

            foreach (var phone in _phones)
            {
                if (_statusService.IsPhoneConnected(phone))
                {
                    if (phone.AccountBalance < 0)
                    {
                        newDebt += -phone.AccountBalance;

                        _statusService.SetDebtStatus(phone);
                    }
                }
                else if (_statusService.IsPhoneDebtor(phone))
                {
                    if (phone.AccountBalance >= 0)
                    {
                        DateTime debtDate = phone.StatusHistory.Last().DateTime;
                        decimal paymentsAmountSinceDebt = CalculateTotalPaymentAmount(phone, debtDate);
                        debtsPaid += Math.Abs(phone.AccountBalance - paymentsAmountSinceDebt);

                        _statusService.SetConnectedStatus(phone);
                    }
                    else
                    {
                        debtsTotal += -phone.AccountBalance;
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
            foreach (var phone in _phones.Where(p => p.AccountBalance >= 0 && _statusService.IsPhoneConnected(p)))
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
