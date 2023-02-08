using System;
using System.Data.Entity.ModelConfiguration;

namespace DB_CourseWork.Core.Data.Config
{
    public class PhoneStatusEntityTypeConfiguration : EntityTypeConfiguration<PhoneStatus>
    {
        private const int NameMaxLength = 32;

        public PhoneStatusEntityTypeConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(NameMaxLength);
        }
    }
}
