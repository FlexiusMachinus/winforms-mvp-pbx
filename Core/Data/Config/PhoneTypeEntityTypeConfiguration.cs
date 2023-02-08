using System;
using System.Data.Entity.ModelConfiguration;

namespace DB_CourseWork.Core.Data.Config
{
    public class PhoneTypeEntityTypeConfiguration : EntityTypeConfiguration<PhoneType>
    {
        private const int NameMaxLength = 32;

        public PhoneTypeEntityTypeConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(NameMaxLength);
        }
    }
}
