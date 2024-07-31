using Microsoft.EntityFrameworkCore;
using PayrollManagerAPI.Models.Entity.EmployeeInfo;

namespace PayrollManagerAPI.Models.Entity.Users
{
    public class Employee : AppUser
    {
        public string Position { get; set; }

        [Precision(18, 2)]
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Payroll>? Payrolls { get; set; }
        public ICollection<Vacation>? Vacations { get; set; }
        public ICollection<PerformanceReview>? PerformanceReviews { get; set; }
        public ICollection<Benefit>? Benefits { get; set; }
        public ICollection<Document>? Documents { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
