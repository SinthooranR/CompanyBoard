using Microsoft.EntityFrameworkCore;

namespace PayrollManagerAPI.Models.Dto
{

    //All the Models used for the CREATE Operations DTOs are placed here

    public class OwnerCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    public class CompanyCreateDto
    {
        public string OwnerId { get; set; }
        public string CompanyName { get; set; }
    }


    public class StakeholderRegisterDto
    {
        public string OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string TypeOfStakeholder { get; set; }
        public string InvestmentDetails { get; set; }

        [Precision(18, 2)]
        public decimal EquityOwned { get; set; }
        public int CompanyId { get; set; }
    }

    public class EmployeeRegisterDto
    {
        public string OwnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Position { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public int? TeamId { get; set; }
        public int CompanyId { get; set; }
    }


    public class TicketCreateDto
    {
        public string UserId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        public DateTime AssignedDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public string EmployeeId { get; set; }

    }
}
