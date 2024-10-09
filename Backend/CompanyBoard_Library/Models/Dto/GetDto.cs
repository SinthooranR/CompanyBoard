namespace CompanyBoard_Library.Models.Dto
{
    public class GetDto
    {

    }

    public class GetIdentityUser
    {

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string[] Roles { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool AccountStatus { get; set; }
    }

    public class GetEmployee : GetIdentityUser
    {
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public int CompanyId { get; set; }

    }

    public class GetOwner : GetIdentityUser
    {
        public decimal? OwnershipPercentage { get; set; }
        public string[]? InvestmentDetails { get; set; }
        public int? CompanyId { get; set; }
        public int? SubscriptionPlanId { get; set; }
    }
}
