using CompanyBoard_Library.Models.Entity.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyBoard_Library.Models.Entity.EmployeeInfo
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
