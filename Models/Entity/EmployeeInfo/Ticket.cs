using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Models.Entity.EmployeeInfo
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
