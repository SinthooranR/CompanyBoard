using Microsoft.EntityFrameworkCore;

namespace PayrollManagerAPI.Models.Entity.Users
{
    public class Stakeholder : AppUser
    {
        public string TypeOfStakeholder { get; set; }
        public string InvestmentDetails { get; set; }

        [Precision(18, 2)]
        public decimal EquityOwned { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
