using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Models.Entity
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Owner>? Owners { get; set; }
        public ICollection<Employee>? Employees { get; set; }
        public ICollection<Stakeholder>? Stakeholders { get; set; }

        public int? SubscriptionPlanId { get; set; }
        public SubscriptionPlan? SubscriptionPlan { get; set; }
    }
}
