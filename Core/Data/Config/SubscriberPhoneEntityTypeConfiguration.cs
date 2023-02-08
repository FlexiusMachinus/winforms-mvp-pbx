using System;
using System.Data.Entity.ModelConfiguration;

namespace DB_CourseWork.Core.Data.Config
{
    public class SubscriberPhoneEntityTypeConfiguration : EntityTypeConfiguration<SubscriberPhone>
    {
        private const int FullNameMaxLength = 128;
        private const int AddressMaxLength = 256;

        public SubscriberPhoneEntityTypeConfiguration()
        {
            Property(p => p.SubscriberFullName).IsRequired().HasMaxLength(FullNameMaxLength);
            Property(p => p.Address).IsRequired().HasMaxLength(AddressMaxLength);
            Ignore(p => p.CurrentStatus).Ignore(p => p.CurrentStatusId);
        }
    }
}
