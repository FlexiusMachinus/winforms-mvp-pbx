using System;
using System.Data.Entity.ModelConfiguration;

namespace DB_CourseWork.Core.Data.Config
{
    public class PhoneEntityTypeConfiguration : EntityTypeConfiguration<Phone>
    {
        private const int NumberMaxLength = 16;

        public PhoneEntityTypeConfiguration()
        {
            Property(p => p.Number).IsRequired().HasMaxLength(NumberMaxLength);
        }
    }
}
