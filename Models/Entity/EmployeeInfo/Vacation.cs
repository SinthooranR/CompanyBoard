using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Models.Entity.EmployeeInfo
{
    public class Vacation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
