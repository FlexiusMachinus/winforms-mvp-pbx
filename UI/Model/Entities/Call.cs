using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_CourseWork
{
    public class Call
    {
        public Call(Phone localPhone, string otherPhoneNumber, DateTime startDateTime, int duration, bool isOutgoing) : this()
        {
            LocalPhone = localPhone;
            OtherPhoneNmber = otherPhoneNumber;
            StartDateTime = startDateTime;
            Duration = duration;
            IsOutgoing = isOutgoing;
        }

        private Call()
        {
            PayphoneCards = new List<PayphoneCard>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Местный телефон")]
        public int? LocalPhoneId { get; set; }

        [Browsable(false)]
        public Phone LocalPhone { get; set; }

        [DisplayName("Номер")]
        [MaxLength(16)]
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$")]
        public string OtherPhoneNmber { get; set; }

        [DisplayName("Дата и время")]
        public DateTime? StartDateTime { get; set; }

        [DisplayName("Продолжительность")]
        public int Duration { get; set; }

        [DisplayName("Исходящий")]
        public bool IsOutgoing { get; set; }

        [Browsable(false)]
        public virtual ICollection<PayphoneCard> PayphoneCards { get; set; }
    }
}
