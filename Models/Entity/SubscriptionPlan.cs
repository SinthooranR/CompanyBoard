using Microsoft.EntityFrameworkCore;
using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Models.Entity
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }
        public string PlanType { get; set; }

        [Precision(18, 2)]
        public decimal MonthlyCost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? OwnerId { get; set; }
        public Owner? Owner { get; set; }
    }
}
