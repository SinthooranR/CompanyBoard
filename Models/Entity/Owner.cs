using Microsoft.EntityFrameworkCore;

namespace PayrollManagerAPI.Models.Entity
{
    public class Owner
    {
        public int OwnerID { get; set; }
        public string? CompanyName { get; set; }

        [Precision(18, 2)]
        public decimal OwnershipPercentage { get; set; }
        public string[]? InvestmentDetails { get; set; }


        public string UserId { get; set; }
        public AppUser User { get; set; }

        public int? CompanyID { get; set; }
        public Company? Company { get; set; }
    }
}
