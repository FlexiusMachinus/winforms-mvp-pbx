using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB_CourseWork.Core
{
    public class Call
    {
        public Call(Phone localPhone, string otherPhoneNumber, DateTime startDateTime, int duration, bool isOutgoing) : this()
        {
            LocalPhone = localPhone;
            OtherPhoneNumber = otherPhoneNumber;
            StartDateTime = startDateTime;
            Duration = duration;
            IsOutgoing = isOutgoing;
        }

        protected Call()
        {
            PayphoneCards = new List<PayphoneCard>();
        }

        public int Id { get; set; }

        public int LocalPhoneId { get; set; }
        public Phone LocalPhone { get; set; }

        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$")]
        public string OtherPhoneNumber { get; set; }

        public DateTime? StartDateTime { get; set; }

        public int Duration { get; set; }

        public bool IsOutgoing { get; set; }

        public virtual ICollection<PayphoneCard> PayphoneCards { get; set; }
    }
}
