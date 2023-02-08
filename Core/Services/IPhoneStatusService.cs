using System;
using System.Collections.Generic;

namespace DB_CourseWork.Core
{
    // Not the cleanest solution.
    // Any change related to phone statuses in the database has to be
    // reflected in this interface and its implementation (because a
    // phone status only has a name field), but it's better to have
    // this dependency contained in one interface rather than
    // scattered across all services working with statuses.
    public interface IPhoneStatusService
    {
        IList<PhoneStatus> GetStatuses();

        bool IsPhoneConnected(SubscriberPhone phone);
        bool IsPhoneDebtor(SubscriberPhone phone);

        void SetConnectedStatus(SubscriberPhone phone, string comment = "");
        void SetDebtStatus(SubscriberPhone phone, string comment = "");
        void SetDisconnectedStatus(SubscriberPhone phone, string comment = "");
    }
}
