using System;
using System.Collections.Generic;
using System.Linq;

namespace DB_CourseWork.Core
{
    public class SubscriberPhone : Phone
    {
        public SubscriberPhone(string number, PhoneType phoneType, string address, string subscriberFullName) : this(number)
        {
            PhoneType = phoneType;
            Address = address;
            SubscriberFullName = subscriberFullName;
        }

        protected SubscriberPhone() : this(default)
        {
        }

        private SubscriberPhone(string number) : base(number)
        {
            Payments = new List<Payment>();
            TariffHistory = new List<TariffHistoryEntry>();
            StatusHistory = new List<StatusHistoryEntry>();
        }

        public int PhoneTypeId { get; set; }
        public PhoneType PhoneType { get; set; }
        public string Address { get; set; }
        public string SubscriberFullName { get; set; }
        public bool IsReducedRate { get; set; }
        public decimal AccountBalance { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<TariffHistoryEntry> TariffHistory { get; set; }
        public virtual ICollection<StatusHistoryEntry> StatusHistory { get; set; }

        public int CurrentStatusId => CurrentStatus.Id;
        public PhoneStatus CurrentStatus => StatusHistory.LastOrDefault()?.Status;
    }
}
