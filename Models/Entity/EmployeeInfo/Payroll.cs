using Microsoft.EntityFrameworkCore;
using PayrollManagerAPI.Models.Entity.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollManagerAPI.Models.Entity.EmployeeInfo
{
    public class Payroll
    {
        public int Id { get; set; }
        public DateTime PayDate { get; set; }

        [Precision(18, 2)]
        public decimal Amount { get; set; }
        public int CompanyId { get; set; }
        public string EmployeeId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }
    }
}
