using CompanyBoard_Library.Data;
using CompanyBoard_Library.Models.Dto;
using CompanyBoard_Library.Models.Entity;
using CompanyBoard_Library.Models.Entity.EmployeeInfo;
using CompanyBoard_Library.Models.Entity.Users;




namespace CompanyBoard_Library.Methods
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
                PhoneNumber = ownerDto.Phone,
                Address = ownerDto.Address,
                City = ownerDto.City,
                Country = ownerDto.Country,
                UserName = ownerDto.Email,
                Email = ownerDto.Email,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                AccountStatus = true,
                Roles = ["Owner", "Admin"],
            };

            return owner;
        }

        public Employee EmployeeDtoToMain(EmployeeCreateDto employeeDto)
        {
            var employee = new Employee()
            {
                FirstName = employeeDto.FirstName,
                LastName = employeeDto.LastName,
                PhoneNumber = employeeDto.Phone,
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
