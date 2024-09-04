using PayrollManagerAPI.Models.Entity.Users;
using System.ComponentModel.DataAnnotations;

namespace PayrollManagerAPI.Models.Entity
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
