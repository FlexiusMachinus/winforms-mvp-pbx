using System;
using System.ComponentModel.DataAnnotations;

namespace DB_CourseWork.Core
{
    public class Payment
    {
        public Payment(SubscriberPhone subscriberPhone, decimal amount, DateTime dateTime)
        {
            Phone = subscriberPhone;
            Amount = amount;
            DateTime = dateTime;
        }

        protected Payment()
        {
        }

        public int Id { get; set; }

        public int PhoneId { get; set; }
        public SubscriberPhone Phone { get; set; }

        [Range(0.01d, (double)decimal.MaxValue, ErrorMessage = "Сумма платежа не может быть меньше или равна нулю.")]
        public decimal Amount { get; set; }

        public DateTime DateTime { get; set; }
    }
}
