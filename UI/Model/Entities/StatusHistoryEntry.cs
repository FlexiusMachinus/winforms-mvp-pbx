using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_CourseWork
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

        private StatusHistoryEntry()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Абонентский телефон")]
        public int? PhoneId { get; set; }

        [Browsable(false)]
        public SubscriberPhone Phone { get; set; }

        [DisplayName("Статус")]
        public int? StatusId { get; set; }

        [Browsable(false)]
        public PhoneStatus Status { get; set; }

        [DisplayName("Дата назначения")]
        public DateTime? DateTime { get; set; }

        [MaxLength(128)]
        [DisplayName("Комментарий")]
        public string Comment { get; set; }
    }
}
