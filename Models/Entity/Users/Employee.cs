using Microsoft.EntityFrameworkCore;
using PayrollManagerAPI.Models.Entity.EmployeeInfo;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollManagerAPI.Models.Entity.Users
{
    public class Employee : AppUser
    {
        [Required]
        public string Position { get; set; }

        [Precision(18, 2)]

        public decimal Salary { get; set; }

        [Required]
        public DateTime HireDate { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Payroll>? Payrolls { get; set; }
        public ICollection<Vacation>? Vacations { get; set; }
        public ICollection<PerformanceReview>? PerformanceReviews { get; set; }
        public ICollection<Benefit>? Benefits { get; set; }
        public ICollection<Document>? Documents { get; set; }
        public int? TeamId { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }
    }
}
