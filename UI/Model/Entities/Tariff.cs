using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB_CourseWork
{
    public class Tariff
    {
        public Tariff(string name, decimal subscriptionFee)
        {
            Name = name;
            SubscriptionFee = subscriptionFee;
        }

        private Tariff()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("Название")]
        [MaxLength(64)]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [DisplayName("Абонентская плата")]
        public decimal SubscriptionFee { get; set; }
    }
}
