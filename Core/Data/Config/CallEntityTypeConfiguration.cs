using System;
using System.Data.Entity.ModelConfiguration;

namespace DB_CourseWork.Core.Data.Config
{
    public class CallEntityTypeConfiguration : EntityTypeConfiguration<Call>
    {
        private const int PhoneNumberMaxLength = 16;

        public CallEntityTypeConfiguration()
        {
            Property(p => p.StartDateTime).IsRequired();
            Property(p => p.OtherPhoneNumber).IsRequired().HasMaxLength(PhoneNumberMaxLength);
        }
    }
}
