using System;

namespace DB_CourseWork.Core
{
    public readonly struct FeeCalculationResult
    {
        public FeeCalculationResult(int feeCount, decimal feesTotal)
        {
            FeeCount = feeCount;
            FeesTotal = feesTotal;
        }

        public int FeeCount { get; }
        public decimal FeesTotal { get; }
    }
}
