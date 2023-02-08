using System;
using System.Collections.Generic;

namespace DB_CourseWork.Core
{
    public interface ISubscriberPhoneService
    {
        IList<SubscriberPhone> GetAllSubscriberPhones();
        SubscriberPhone FindSubscriberPhoneByNumber(string phoneNumber);
    }
}
