using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using DB_CourseWork.Core.Data;

namespace DB_CourseWork.Core
{
    public class ReportService : IReportService
    {
        private readonly PbxContext _context;

        public ReportService(PbxContext context)
        {
            _context = context;
        }

        public IDictionary<Tariff, decimal> CalculatePaymentsByTariffs(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("The start date cannot be greater than the end date.");
            }

            var feesByTariffs = new Dictionary<Tariff, decimal>();

            var payments = _context.Payments
                .Include(p => p.Phone.TariffHistory.Select(e => e.Tariff)).ToList()
                .Where(p => IsDateInRange(p.DateTime, startDate, endDate));

            var groupings = payments
                .GroupBy(p => p.Phone.TariffHistory.Last().Tariff)
                .OrderBy(g => g.Key.Name);

            feesByTariffs = groupings.ToDictionary(
				x => x.Key,
				x => x.Select(p => p.Amount).Sum()
			);

            //foreach (var grouping in groupings)
            //{
            //    Tariff tariff = grouping.Key;
            //    decimal paymentsTotal = grouping.Sum(p => p.Amount);
            //    feesByTariffs.Add(tariff, paymentsTotal);
            //}

            return feesByTariffs;
        }

        public IDictionary<Tariff, decimal> CalculateDebtsByTariffs(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                throw new ArgumentException("The start date cannot be greater than the end date.");
            }

            var debtsByTariffs = new Dictionary<Tariff, decimal>();

            var groupings = _context.SubscriberPhones
                .Include(p => p.StatusHistory.Select(e => e.Status))
                .Include(p => p.TariffHistory.Select(e => e.Tariff))
                .Where(p => p.AccountBalance < 0).ToList()
                .Where(p => IsDateInRange(p.StatusHistory.Last().DateTime, startDate, endDate))
                .GroupBy(p => p.TariffHistory.Last().Tariff)
                .OrderBy(g => g.Key.Name);

            foreach (var grouping in groupings)
            {
                Tariff tariff = grouping.Key;
                decimal debtsTotal = grouping.Sum(p => p.AccountBalance);
                debtsByTariffs.Add(tariff, -debtsTotal);
            }

            return debtsByTariffs;
        }

        private bool IsDateInRange(DateTime dateTime, DateTime startDate, DateTime endDate)
        {
            return (dateTime >= startDate && dateTime <= endDate);
        }
    }
}
