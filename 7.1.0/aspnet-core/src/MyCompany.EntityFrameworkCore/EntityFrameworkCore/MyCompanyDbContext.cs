using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using MyCompany.Authorization.Roles;
using MyCompany.Authorization.Users;
using MyCompany.MultiTenancy;
using Abp.Localization;



namespace MyCompany.EntityFrameworkCore
{
    public class MyCompanyDbContext : AbpZeroDbContext<Tenant, Role, User, MyCompanyDbContext>
    {
        public DbSet<Employee> Employees { get; set; }
        /* Define a DbSet for each entity of the application */

        
        public MyCompanyDbContext(DbContextOptions<MyCompanyDbContext> options)
            : base(options)
        {
     
        }

        // add these lines to override max length of property
        // we should set max length smaller than the PostgreSQL allowed size (10485760)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationLanguageText>()
                .Property(p => p.Value)
                .HasMaxLength(100); // any integer that is smaller than 10485760
        }
    }
}
