using PayrollManagerAPI.Data;
using PayrollManagerAPI.Models.Dto;
using PayrollManagerAPI.Models.Entity;
using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Methods
{
    public class Mapping
    {
        private readonly DataContext _dataContext;
        public Mapping(DataContext dataContext)
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
                CompanyId = employeeDto.CompanyId,
                TeamId = employeeDto.TeamId,
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
                Owners = _dataContext.Owners.Where(o => o.Id == companyDto.OwnerId).ToList(),
                Employees = [],
                Stakeholders = [],
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

    }
}
