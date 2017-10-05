using APIProject.Data.Configuration;
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

        public DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<MarketingPlan> MarketingPlans { get; set; }
        public virtual DbSet<MarketingPlanDate> MarketingPlanDates { get; set; }
        public virtual DbSet<MarketingResult> MarketingResults { get; set; }
        public virtual DbSet<MarketingStage> MarketingStages { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                  .Property(e => e.FirstName)
                  .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.TaxCode)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerType)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.MarketingResults)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.MarketingPlans)
                .WithMany(e => e.Customers)
                .Map(m => m.ToTable("MarketingPlanCustomerMapping").MapLeftKey("CustomerId").MapRightKey("MarketingPlanId"));

            modelBuilder.Entity<MarketingPlan>()
                .Property(e => e.ValidatedNote)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingPlan>()
                .Property(e => e.AcceptedNote)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingPlan>()
                .Property(e => e.ApproveNote)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingPlan>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingPlan>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingPlan>()
                .Property(e => e.TotalBudget)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingPlan>()
                .Property(e => e.EventScheduleFile)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingPlan>()
                .Property(e => e.TaskAssignFile)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingPlan>()
                .Property(e => e.BudgetFile)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingPlan>()
                .Property(e => e.LicenseFile)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingPlan>()
                .HasMany(e => e.MarketingPlanDates)
                .WithOptional(e => e.MarketingPlan)
                .HasForeignKey(e => e.PlanId);

            modelBuilder.Entity<MarketingPlan>()
                .HasMany(e => e.MarketingResults)
                .WithOptional(e => e.MarketingPlan)
                .HasForeignKey(e => e.PlanId);

            modelBuilder.Entity<MarketingResult>()
                .Property(e => e.CompanyName)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingResult>()
                .Property(e => e.ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingResult>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingResult>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingResult>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingStage>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MarketingStage>()
                .HasMany(e => e.MarketingPlans)
                .WithOptional(e => e.MarketingStage)
                .HasForeignKey(e => e.StageId);

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Staff>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.MiddleName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.MarketingPlans)
                .WithOptional(e => e.Staff)
                .HasForeignKey(e => e.CreatedById);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.MarketingPlans1)
                .WithOptional(e => e.Staff1)
                .HasForeignKey(e => e.AcceptedById);

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
