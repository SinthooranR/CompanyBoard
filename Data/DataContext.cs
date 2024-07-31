using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PayrollManagerAPI.Models.Entity;
using PayrollManagerAPI.Models.Entity.EmployeeInfo;
using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Data
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Stakeholder> Stakeholders { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<PerformanceReview> PerformanceReviews { get; set; }
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Team> Teams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>()
                .HasOne(o => o.Company)
                .WithMany(c => c.Owners)
                .HasForeignKey(o => o.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Stakeholder>()
                .HasOne(s => s.Company)
                .WithMany(c => c.Stakeholders)
                .HasForeignKey(s => s.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Employee)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payroll>()
                .HasOne(p => p.Employee)
                .WithMany(e => e.Payrolls)
                .HasForeignKey(p => p.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vacation>()
                .HasOne(v => v.Employee)
                .WithMany(e => e.Vacations)
                .HasForeignKey(v => v.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PerformanceReview>()
                .HasOne(pr => pr.Employee)
                .WithMany(e => e.PerformanceReviews)
                .HasForeignKey(pr => pr.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Benefit>()
                .HasOne(b => b.Employee)
                .WithMany(e => e.Benefits)
                .HasForeignKey(b => b.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Document>()
                .HasOne(d => d.Employee)
                .WithMany(e => e.Documents)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Team)
                .WithMany(t => t.Employees)
                .HasForeignKey(e => e.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Owner>()
                .HasOne(o => o.SubscriptionPlan)
                .WithOne(sp => sp.Owner)
                .HasForeignKey<SubscriptionPlan>(sp => sp.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
