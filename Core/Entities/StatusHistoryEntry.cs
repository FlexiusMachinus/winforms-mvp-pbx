using System;

namespace DB_CourseWork.Core
{
    public class StatusHistoryEntry
    {
        public StatusHistoryEntry(SubscriberPhone subscriberPhone, PhoneStatus status, DateTime dateTime, string comment)
        {
            Phone = subscriberPhone;
            Status = status;
            DateTime = dateTime;
            Comment = comment;
        }

        protected StatusHistoryEntry()
        {
        }

        public int Id { get; set; }

        public int PhoneId { get; set; }
        public SubscriberPhone Phone { get; set; }

        public int StatusId { get; set; }
        public PhoneStatus Status { get; set; }

        public DateTime DateTime { get; set; }

        public string Comment { get; set; }
    }
}
