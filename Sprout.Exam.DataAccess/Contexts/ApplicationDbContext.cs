using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Sprout.Exam.DataAccess.Entities;


namespace Sprout.Exam.DataAccess.Contexts
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options,
                                    IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Employee>(entity =>
            {
                entity.ToTable(nameof(Employee));

                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Birthdate)
                    .IsRequired();
                entity.Property(e => e.Tin)
                    .HasColumnName("TIN")
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.EmployeeTypeId)
                    .IsRequired();
                entity.Property(e => e.IsDeleted)
                    .IsRequired(true);
            });

            base.OnModelCreating(builder);
        }
    }
}
