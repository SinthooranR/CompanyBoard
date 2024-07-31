using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Models.Entity.EmployeeInfo
{
    public class Benefit
    {
        public int Id { get; set; }
        public string BenefitType { get; set; }
        public string Description { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
