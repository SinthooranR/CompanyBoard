using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PayrollManagerAPI.Models.Entity;

namespace PayrollManagerAPI.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Stakeholder> Stakeholders { get; set; }
        public DbSet<Company> Companies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //For Users 
            modelBuilder.Entity<Owner>()
                .HasOne(o => o.User)
                .WithOne()
                .HasForeignKey<Owner>(o => o.UserId);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<Employee>(e => e.UserId);

            modelBuilder.Entity<Stakeholder>()
                .HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Stakeholder>(s => s.UserId);


            //For Companies 
            modelBuilder.Entity<Company>()
                .HasMany(c => c.Employees)
                .WithOne(e => e.Company)
                .HasForeignKey(e => e.CompanyID);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Stakeholders)
                .WithOne(s => s.Company)
                .HasForeignKey(s => s.CompanyID);

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Owners)
                .WithOne(o => o.Company)
                .HasForeignKey(o => o.CompanyID);
        }
    }
}
