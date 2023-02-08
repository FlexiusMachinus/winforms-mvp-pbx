using System;

namespace DB_CourseWork
{
    public readonly struct DebtCalculationResult
    {
        public DebtCalculationResult(decimal debtsTotal, decimal debtsPaid, decimal debtsSinceLastUpdate)
        {
            DebtsTotal = debtsTotal;
            DebtsPaid = debtsPaid;
            DebtsSinceLastUpdate = debtsSinceLastUpdate;
        }

        public decimal DebtsTotal { get; }
        public decimal DebtsPaid { get; }
        public decimal DebtsSinceLastUpdate { get; }

    }
}
