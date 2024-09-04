using PayrollManagerAPI.Models.Entity.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollManagerAPI.Models.Entity.EmployeeInfo
{
    public class Benefit
    {
        public int Id { get; set; }

        [Required]
        public string BenefitType { get; set; }

        [Required]
        public string Description { get; set; }
        public string EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}
