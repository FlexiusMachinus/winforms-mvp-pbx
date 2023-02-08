using System;
using System.Data.Entity.ModelConfiguration;

namespace DB_CourseWork.Core.Data.Config
{
    public class PayphoneCardEntityTypeConfiguration : EntityTypeConfiguration<PayphoneCard>
    {
        private const int NumberMaxLength = 6;

        public PayphoneCardEntityTypeConfiguration()
        {
            Property(p => p.ReleaseDate).IsRequired();
            Property(p => p.Number).IsRequired().HasMaxLength(NumberMaxLength).IsFixedLength();
            Ignore(p => p.Calls);
        }
    }
}
