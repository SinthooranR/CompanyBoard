using Microsoft.AspNetCore.Identity;

namespace PayrollManagerAPI.Models.Entity.Users
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string[] Roles { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool AccountStatus { get; set; }
    }
}
