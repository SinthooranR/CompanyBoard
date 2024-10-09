using CompanyBoard_Library.Models.Entity;
using CompanyBoard_Library.Models.Entity.EmployeeInfo;
using CompanyBoard_Library.Models.Entity.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CompanyBoard_Library.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
        public DbSet<Stakeholder> Stakeholders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
            .HasOne(e => e.Company)
            .WithMany(c => c.Employees)
            .HasForeignKey(e => e.CompanyId)
            .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Stakeholder>()
            .HasOne(s => s.Company)
            .WithMany(c => c.Stakeholders)
            .HasForeignKey(s => s.CompanyId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
