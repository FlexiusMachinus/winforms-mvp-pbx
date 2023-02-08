using System;
using System.Data.Entity.ModelConfiguration;

namespace DB_CourseWork.Core.Data.Config
{
    public class StatusHistoryEntryEntityTypeConfiguration : EntityTypeConfiguration<StatusHistoryEntry>
    {
        private const int CommentMaxLength = 128;

        public StatusHistoryEntryEntityTypeConfiguration()
        {
            Property(p => p.Comment).HasMaxLength(CommentMaxLength);
        }
    }
}
