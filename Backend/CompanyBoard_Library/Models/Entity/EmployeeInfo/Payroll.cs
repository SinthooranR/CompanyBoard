using CompanyBoard_Library.Models.Entity.Users;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyBoard_Library.Models.Entity.EmployeeInfo
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
