using System;
using EntityFramework.Triggers;
using Microsoft.Extensions.DependencyInjection;

namespace DB_CourseWork.Core.Data
{
    public static class PbxTriggers
    {
        public static IServiceCollection AddPbxTriggers(this IServiceCollection serviceCollection)
        {
            Triggers<Payment, PbxContext>.Inserted += e =>
            {
                Payment payment = e.Entity;
                payment.Phone.AccountBalance += payment.Amount;
            };

            Triggers<Payment, PbxContext>.Updating += e =>
            {
                Payment payment = e.Entity;
                if (payment.DateTime > DateTime.Now)
                {
                    e.Cancel = true;
                }
            };

            return serviceCollection.AddTriggers();
        }
    }
}
