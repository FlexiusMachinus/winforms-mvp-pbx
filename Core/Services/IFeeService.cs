using System;
using System.Collections.Generic;

namespace DB_CourseWork.Core
{
    public interface IFeeService
    {
        IList<SubscriberPhone> GetDebtorPhones();

        DebtCalculationResult UpdateDebts();
        FeeCalculationResult MakeTariffPayments();
    }
}
