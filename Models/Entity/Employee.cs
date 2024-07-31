using Microsoft.EntityFrameworkCore;

namespace PayrollManagerAPI.Models.Entity
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }

        [Precision(18, 2)]
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }

        [Precision(18, 2)]
        public decimal[] Performance { get; set; }
        public string[] AssignedTasks { get; set; }

        public string WorkType { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
