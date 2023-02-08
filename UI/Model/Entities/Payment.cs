using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_CourseWork
{
    public class Payment
    {
        public Payment(SubscriberPhone subscriberPhone, decimal amount, DateTime dateTime)
        {
            Phone = subscriberPhone;
            Amount = amount;
            DateTime = dateTime;
        }

        private Payment()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Абонентский телефон")]
        public int? PhoneId { get; set; }

        [Browsable(false)]
        public SubscriberPhone Phone { get; set; }

        [DisplayName("Сумма")]
        [Range(0.01d, (double)decimal.MaxValue, ErrorMessage = "Сумма платежа не может быть меньше или равна нулю.")]
        public decimal Amount { get; set; }

        [DisplayName("Дата и время")]
        public DateTime? DateTime { get; set; }
    }
}
