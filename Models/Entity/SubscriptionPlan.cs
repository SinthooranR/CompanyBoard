using Microsoft.EntityFrameworkCore;
using PayrollManagerAPI.Models.Entity.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollManagerAPI.Models.Entity
{
    public class SubscriptionPlan
    {
        public int Id { get; set; }

        [Required]
        public string PlanType { get; set; }

        [Precision(18, 2)]
        public decimal MonthlyCost { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string? OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Owner? Owner { get; set; }
    }
}
