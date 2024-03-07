using JobPortalAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace JobPortalAPI.Data.Context
{
    public class JobPortalContext : DbContext
    {
        public JobPortalContext(DbContextOptions<JobPortalContext> options)
        : base(options) { }

        public DbSet<ApplicationModel> Application { get; set; }
        public DbSet<CategoryRequestModel> Category { get; set; }
        public DbSet<CompanyModel> Company { get; set; }
        public DbSet<CompanyAddressModel> CompanyAddresse { get; set; }
        public DbSet<JobCategoryModel> JobCategory { get; set; }
        public DbSet<JobsModel> Job { get; set; }
        public DbSet<PersonModel> Peson { get; set; }
        public DbSet<PersonAddressModel> PersonAddresse { get; set; }
        public DbSet<PersonLoginInfoModel> PersonLogin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Enums config
            modelBuilder.Entity<ApplicationResponseModel>()
                .Property(t => t.Status)
                .HasConversion<int>();

            modelBuilder.Entity<CategoryRequestModel>()
                .Property(t => t.Accepted)
                .HasConversion<int>();

            modelBuilder.Entity<JobsModel>()
                .Property(t => t.WorkSchedule)
                .HasConversion<int>();

            // One to one
            modelBuilder.Entity<PersonModel>()
               .HasOne(a => a.Address)
               .WithOne(b => b.Person)
               .HasForeignKey<PersonAddressModel>(b => b.PersonID);

            modelBuilder.Entity<PersonModel>()
               .HasOne(a => a.Login)
               .WithOne(b => b.Person)
               .HasForeignKey<PersonLoginInfoModel>(b => b.PersonID);

            modelBuilder.Entity<ApplicationModel>()
               .HasOne(a => a.ApplicationResponse)
               .WithOne(b => b.Application)
               .HasForeignKey<ApplicationResponseModel>(b => b.ApplicationID);

            modelBuilder.Entity<CompanyModel>()
               .HasOne(a => a.Adress)
               .WithOne(b => b.Company)
               .HasForeignKey<CompanyAddressModel>(b => b.CompanyID);

            // Many to one
            modelBuilder.Entity<PersonModel>()
                .HasMany(e => e.Applications)
                .WithOne(e => e.Person)
                .HasForeignKey(e => e.PersonID)
                .IsRequired();

            modelBuilder.Entity<JobsModel>()
                .HasMany(e => e.Applications)
                .WithOne(e => e.Jobs)
                .HasForeignKey(e => e.JobID)
                .IsRequired();

            modelBuilder.Entity<CompanyModel>()
                .HasMany(e => e.Jobs)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyID)
                .IsRequired();

            modelBuilder.Entity<CompanyModel>()
                .HasMany(e => e.CategoryRequest)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyID)
                .IsRequired();

            // Many to many
            modelBuilder.Entity<PersonModel>()
                .HasMany(s => s.SavedJobs)
                .WithMany(c => c.people)
                .UsingEntity(j => j.ToTable("PeopleSavedJobs"));

            modelBuilder.Entity<JobsModel>()
                .HasMany(s => s.JobCategories)
                .WithMany(c => c.Jobs)
                .UsingEntity(j => j.ToTable("JobsCategory"));
        }

    }
}
