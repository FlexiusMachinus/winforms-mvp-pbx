using System;
using System.Collections.Generic;

namespace DB_CourseWork.Core
{
    public interface IReportService
    {
        IDictionary<Tariff, decimal> CalculatePaymentsByTariffs(DateTime startDate, DateTime endDate);
        IDictionary<Tariff, decimal> CalculateDebtsByTariffs(DateTime startDate, DateTime endDate);
    }
}
