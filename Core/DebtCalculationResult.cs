using System;

namespace DB_CourseWork.Core
{
    public readonly struct DebtCalculationResult
    {
        public DebtCalculationResult(decimal debtsTotal, decimal debtsPaid, decimal newDebts)
        {
            DebtsTotal = debtsTotal;
            DebtsPaid = debtsPaid;
            NewDebts = newDebts;
        }

        public decimal DebtsTotal { get; }
        public decimal DebtsPaid { get; }
        public decimal NewDebts { get; }

    }
}
