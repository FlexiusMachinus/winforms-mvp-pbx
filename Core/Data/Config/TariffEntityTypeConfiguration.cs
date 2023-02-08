using System;
using System.Data.Entity.ModelConfiguration;

namespace DB_CourseWork.Core.Data.Config
{
    internal class TariffEntityTypeConfiguration : EntityTypeConfiguration<Tariff>
    {
        private const int NameMaxLength = 64;

        public TariffEntityTypeConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(NameMaxLength);
        }
    }
}
