using System;
using System.ComponentModel.DataAnnotations;

namespace DB_CourseWork.Core
{
    public class Tariff
    {
        public Tariff(string name, decimal subscriptionFee)
        {
            Name = name;
            SubscriptionFee = subscriptionFee;
        }

        protected Tariff()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal SubscriptionFee { get; set; }
    }
}
