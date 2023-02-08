using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DB_CourseWork
{
    public class SubscriberPhone : Phone
    {
        public SubscriberPhone(string number, PhoneType phoneType, string address, string subscriberFullName) : this(number)
        {
            PhoneType = phoneType;
            Address = address;
            SubscriberFullName = subscriberFullName;
        }

        private SubscriberPhone(string number) : base(number)
        {
            Payments = new List<Payment>();
            TariffHistory = new List<TariffHistoryEntry>();
            StatusHistory = new List<StatusHistoryEntry>();
        }

        private SubscriberPhone() : this(default)
        {
        }

        [DisplayName("Тип телефона")]
        public int? PhoneTypeId { get; set; }

        [Browsable(false)]
        public PhoneType PhoneType { get; set; }

        [DisplayName("Адрес")]
        [Required(AllowEmptyStrings = false)]
        public string Address { get; set; }

        [DisplayName("ФИО абонента")]
        [MaxLength(128)]
        [Required(AllowEmptyStrings = false)]
        public string SubscriberFullName { get; set; }

        [DisplayName("Наличие льгот")]
        public bool IsReducedRate { get; set; }

        [DisplayName("Баланс")]
        public decimal AccountBalance { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<TariffHistoryEntry> TariffHistory { get; set; }
        public virtual ICollection<StatusHistoryEntry> StatusHistory { get; set; }

        [NotMapped]
        [DisplayName("Статус")]
        public int? CurrentStatusId => CurrentStatus?.Id;

        [NotMapped]
        [Browsable(false)]
        public PhoneStatus CurrentStatus => StatusHistory.LastOrDefault()?.Status;
    }
}
