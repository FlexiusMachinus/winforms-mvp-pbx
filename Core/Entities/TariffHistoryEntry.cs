using System;

namespace DB_CourseWork.Core
{
    public class TariffHistoryEntry
    {
        public TariffHistoryEntry(SubscriberPhone subscriberPhone, Tariff tariff, DateTime dateTime)
        {
            Phone = subscriberPhone;
            Tariff = tariff;
            DateTime = dateTime;
        }

        protected TariffHistoryEntry()
        {
        }

        public int Id { get; set; }

        public int PhoneId { get; set; }
        public SubscriberPhone Phone { get; set; }

        public int TariffId { get; set; }
        public Tariff Tariff { get; set; }

        public DateTime DateTime { get; set; }
    }
}
