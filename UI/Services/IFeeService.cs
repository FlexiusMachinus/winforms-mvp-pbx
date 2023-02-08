using System;
using System.Collections.Generic;

namespace DB_CourseWork
{
    public interface IFeeService
    {
        IList<SubscriberPhone> GetDebtorPhones();
        IList<PhoneStatus> GetStatuses();

        DebtCalculationResult UpdateDebts();
        FeeCalculationResult CalculateFees();
    }
}
