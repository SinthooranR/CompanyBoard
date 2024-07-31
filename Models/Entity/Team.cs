using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Models.Entity
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
