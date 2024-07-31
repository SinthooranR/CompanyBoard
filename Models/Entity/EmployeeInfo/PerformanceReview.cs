using Microsoft.EntityFrameworkCore;
using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Models.Entity.EmployeeInfo
{
    public class PerformanceReview
    {
        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }

        [Precision(18, 2)]
        public decimal ReviewScore { get; set; }
        public string[] Comments { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
