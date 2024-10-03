using PayrollManagerAPI.Data;
using PayrollManagerAPI.Models.Dto;
using PayrollManagerAPI.Models.Entity;
using PayrollManagerAPI.Models.Entity.EmployeeInfo;
using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Methods
{
    public class CreateMapping
    {
        private readonly DataContext _dataContext;
        public CreateMapping(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Owner OwnerDtotoMain(OwnerCreateDto ownerDto)
        {
            var owner = new Owner()
            {
                FirstName = ownerDto.FirstName,
                LastName = ownerDto.LastName,
                Phone = ownerDto.Phone,
                Address = ownerDto.Address,
                City = ownerDto.City,
                Country = ownerDto.Country,
                UserName = ownerDto.Email,
                Email = ownerDto.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                AccountStatus = true,
                Roles = ["Owner", "Admin"]
            };

            return owner;
        }

        public Employee EmployeeDtoToMain(EmployeeRegisterDto employeeDto)
        {
            var employee = new Employee()
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                Phone = employeeDto.Phone,
                Address = employeeDto.Address,
                City = employeeDto.City,
                Country = employeeDto.Country,
                UserName = employeeDto.Email,
                Email = employeeDto.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                AccountStatus = true,
                Roles = ["Employee"],
                Position = employeeDto.Position,
                Salary = employeeDto.Salary,
                HireDate = employeeDto.HireDate,
                Benefits = [],
                Documents = [],
                CompanyId = _dataContext.Companies.Where(c => c.InviteCode == employeeDto.InviteCode).FirstOrDefault().Id,

                //This is to deal with Swagger's default setup
                TeamId = employeeDto.TeamId == 0 ? null : employeeDto.TeamId,
                PerformanceReviews = [],
                Tickets = [],
                Vacations = [],
                Payrolls = [],
            };

            return employee;
        }

        public Company CompanyDtoToMain(CompanyCreateDto companyDto)
        {
            var company = new Company()
            {
                CompanyName = companyDto.CompanyName,
                OwnerId = companyDto.OwnerId,
                Employees = [],
                Stakeholders = [],
                Tickets = [],
                InviteCode = Guid.NewGuid().ToString("N").Substring(0, 10),
                SubscriptionPlan = new SubscriptionPlan()
                {
                    StartDate = DateTime.UtcNow,
                    OwnerId = companyDto.OwnerId,
                    MonthlyCost = 0.00M,
                    Owner = _dataContext.Owners.Where(o => o.Id == companyDto.OwnerId).FirstOrDefault(),
                    PlanType = "Free"
                }
            };

            return company;
        }

        public Ticket TicketDtoToMain(TicketCreateDto ticketCreateDto)
        {
            var ticket = new Ticket()
            {
                Title = ticketCreateDto.Title,
                Description = ticketCreateDto.Description,
                AssignedDate = ticketCreateDto.AssignedDate,
                DueDate = ticketCreateDto.DueDate,
                EmployeeId = ticketCreateDto.EmployeeId,
                CompanyId = ticketCreateDto.CompanyId,
                Status = "Todo"
            };

            return ticket;
        }
    }
}
