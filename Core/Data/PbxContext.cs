using System;
using System.Data.Entity;
using DB_CourseWork.Core.Data.Config;
using EntityFramework.Triggers;

namespace DB_CourseWork.Core.Data
{
    public class PbxContext : DbContextWithTriggers
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
        public virtual DbSet<SubscriberPhone> SubscriberPhones { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<PhoneStatus> PhoneStatuses { get; set; }
        public virtual DbSet<StatusHistoryEntry> StatuseHistoryEntries { get; set; }
        public virtual DbSet<Tariff> Tariffs { get; set; }
        public virtual DbSet<TariffHistoryEntry> TariffHistoryEntries { get; set; }
        public virtual DbSet<Payphone> Payphones { get; set; }
        public virtual DbSet<PayphoneCard> PayphoneCards { get; set; }
        public virtual DbSet<Call> Calls { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CallEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PayphoneEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PayphoneCardEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PhoneStatusEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PhoneTypeEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new PhoneEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new StatusHistoryEntryEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new SubscriberPhoneEntityTypeConfiguration());
            modelBuilder.Configurations.Add(new TariffEntityTypeConfiguration());

            modelBuilder.Entity<Phone>().ToTable("Phones").HasIndex(p => p.Number).IsUnique();
            modelBuilder.Entity<Payphone>().ToTable("Payphones");
            modelBuilder.Entity<SubscriberPhone>().ToTable("SubscriberPhones");

            modelBuilder.Entity<Call>().HasMany(c => c.PayphoneCards).WithMany(c => c.Calls).Map(cc =>
            {
                cc.MapLeftKey("CardRefId");
                cc.MapRightKey("CallRefId");
                cc.ToTable("CallCard");
            });
        }
    }
}
