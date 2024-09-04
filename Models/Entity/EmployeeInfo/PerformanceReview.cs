using Microsoft.EntityFrameworkCore;
using PayrollManagerAPI.Models.Entity.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollManagerAPI.Models.Entity.EmployeeInfo
{
    public class PerformanceReview
    {
        public int Id { get; set; }
        public DateTime ReviewDate { get; set; }

        [Precision(18, 2)]
        [Required]
        public decimal ReviewScore { get; set; }
        public string[] Comments { get; set; }
        public string EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}
