using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DB_CourseWork
{
    public class PbxContext : DbContext
    {
        public PbxContext() : base("PbxDbConnection")
        {
        }

        static PbxContext()
        {
            Database.SetInitializer(new PbxDbInitializer());
        }

        public virtual DbSet<Phone> Phones { get; set; }
        public virtual DbSet<PhoneType> PhoneTypes { get; set; }

        public virtual DbSet<PhoneStatus> PhoneStatuses { get; set; }
        public virtual DbSet<StatusHistoryEntry> StatuseHistoryEntries { get; set; }

        public virtual DbSet<SubscriberPhone> SubscriberPhones { get; set; }
        public virtual DbSet<Tariff> Tariffs { get; set; }
        public virtual DbSet<TariffHistoryEntry> TariffHistoryEntries { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Payphone> Payphones { get; set; }
        public virtual DbSet<PayphoneCard> PayphoneCards { get; set; }
        public virtual DbSet<Call> Calls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phone>().ToTable("Phones");
            modelBuilder.Entity<Payphone>().ToTable("Payphones");
            modelBuilder.Entity<SubscriberPhone>().ToTable("SubscriberPhones");

            modelBuilder.Entity<StatusHistoryEntry>().HasRequired(e => e.Status).WithMany().HasForeignKey(e => e.StatusId);
            modelBuilder.Entity<StatusHistoryEntry>().HasRequired(e => e.Phone).WithMany(p => p.StatusHistory).HasForeignKey(e => e.PhoneId);

            modelBuilder.Entity<TariffHistoryEntry>().HasRequired(e => e.Tariff).WithMany().HasForeignKey(e => e.TariffId);
            modelBuilder.Entity<TariffHistoryEntry>().HasRequired(e => e.Phone).WithMany(p => p.TariffHistory).HasForeignKey(e => e.PhoneId);

            modelBuilder.Entity<Payment>().HasRequired(p => p.Phone).WithMany(p => p.Payments).HasForeignKey(p => p.PhoneId);

            modelBuilder.Entity<Call>().HasRequired(c => c.LocalPhone).WithMany().HasForeignKey(c => c.LocalPhoneId);
            modelBuilder.Entity<Call>().HasMany(c => c.PayphoneCards).WithMany(c => c.Calls).Map(cc =>
            {
                cc.MapLeftKey("CardRefId");
                cc.MapRightKey("CallRefId");
                cc.ToTable("CallCard");
            });
        }
    }
}
