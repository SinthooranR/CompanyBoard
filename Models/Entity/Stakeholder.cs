using Microsoft.EntityFrameworkCore;

namespace PayrollManagerAPI.Models.Entity
{
    public class Stakeholder
    {
        public int StakeholderID { get; set; }
        public string StakeholderType { get; set; }
        public string CompanyName { get; set; }
        public string InvestmentDetails { get; set; }

        [Precision(18, 2)]
        public decimal EquityOwned { get; set; }

        [Precision(18, 2)]
        public decimal InvestmentAmount { get; set; }
        public DateTime InvestmentDate { get; set; }
        public string[] Notes { get; set; }
        public string Status { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public int CompanyID { get; set; }
        public Company Company { get; set; }
    }
}
