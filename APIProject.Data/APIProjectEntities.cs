using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIProject.Data
{
    public class APIProjectEntities : DbContext
    {
        public APIProjectEntities() : base("APIProjectEntities") { }

        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<MarketingPlan> MarketingPlans { get; set; }
        public virtual DbSet<MarketingPlanDate> MarketingPlanDates { get; set; }
        public virtual DbSet<MarketingResult> MarketingResults { get; set; }
        public virtual DbSet<MarketingStage> MarketingStages { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarketingStage>()
                 .HasMany(e => e.MarketingPlans)
                 .WithOptional(e => e.MarketingStage)
                 .HasForeignKey(e => e.StageId);

            modelBuilder.Entity<MarketingStage>()
                .HasMany(e => e.MarketingStage1)
                .WithOptional(e => e.MarketingStage2)
                .HasForeignKey(e => e.NextStageId);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.MarketingPlans)
                .WithOptional(e => e.Staff)
                .HasForeignKey(e => e.CreatedById);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.MarketingPlans1)
                .WithOptional(e => e.Staff1)
                .HasForeignKey(e => e.UpdatedById);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.MarketingPlans2)
                .WithOptional(e => e.Staff2)
                .HasForeignKey(e => e.ValidatedById);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.MarketingPlans3)
                .WithOptional(e => e.Staff3)
                .HasForeignKey(e => e.ApprovedById);
        }
    }
}
