using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_CourseWork
{
    public class TariffHistoryEntry
    {
        public TariffHistoryEntry(SubscriberPhone subscriberPhone, Tariff tariff, DateTime dateTime)
        {
            Phone = subscriberPhone;
            Tariff = tariff;
            DateTime = dateTime;
        }

        private TariffHistoryEntry()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Абонентский телефон")]
        public int? PhoneId { get; set; }

        [Browsable(false)]
        public SubscriberPhone Phone { get; set; }

        [DisplayName("Тариф")]
        public int? TariffId { get; set; }

        [Browsable(false)]
        public Tariff Tariff { get; set; }

        [DisplayName("Дата назначения")]
        public DateTime? DateTime { get; set; }
    }
}
