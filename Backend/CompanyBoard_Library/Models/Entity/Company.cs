using CompanyBoard_Library.Models.Entity.EmployeeInfo;
using CompanyBoard_Library.Models.Entity.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyBoard_Library.Models.Entity
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }
        public string OwnerId { get; set; }

        [ForeignKey(nameof(OwnerId))]
        public Owner Owner { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
        public ICollection<Stakeholder>? Stakeholders { get; set; }
        public int? SubscriptionPlanId { get; set; }

        [Required]
        public string InviteCode { get; set; }

        [ForeignKey(nameof(SubscriptionPlanId))]
        public SubscriptionPlan? SubscriptionPlan { get; set; }
    }
}
