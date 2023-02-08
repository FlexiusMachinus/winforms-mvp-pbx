using System;
using System.Data.Entity.ModelConfiguration;

namespace DB_CourseWork.Core.Data.Config
{
    public class PayphoneEntityTypeConfiguration : EntityTypeConfiguration<Payphone>
    {
        public PayphoneEntityTypeConfiguration()
        {
            Property(p => p.Address).IsRequired();
        }
    }
}
