using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyBoard_Library.Models.Entity.Users
{
    public class Stakeholder : AppUser
    {
        [Required]
        public string TypeOfStakeholder { get; set; }
        public string InvestmentDetails { get; set; }

        [Precision(18, 2)]
        public decimal EquityOwned { get; set; }
        public int? CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company? Company { get; set; }
    }
}
