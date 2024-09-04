using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollManagerAPI.Models.Entity.Users
{
    public class Owner : AppUser
    {
        [Precision(18, 2)]
        public decimal? OwnershipPercentage { get; set; }
        public string[]? InvestmentDetails { get; set; }
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }

        [ForeignKey(nameof(SubscriptionPlanId))]
        public int? SubscriptionPlanId { get; set; }
        public SubscriptionPlan? SubscriptionPlan { get; set; }
    }
}
