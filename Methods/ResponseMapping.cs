using PayrollManagerAPI.Data;
using PayrollManagerAPI.Models.Dto;
using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Methods
{
    public class ResponseMapping
    {
        private readonly DataContext _dataContext;

        public ResponseMapping(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public GetEmployee employeeResponse(Employee employee)
        {
            return new GetEmployee()
            {
                Id = employee.Id,
                AccountStatus = employee.AccountStatus,
                Address = employee.Address,
                City = employee.City,
                Country = employee.Country,
                CompanyId = employee.CompanyId,
                CreatedAt = employee.CreatedAt,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                HireDate = employee.HireDate,
                Phone = employee.Phone,
                Position = employee.Position,
                Roles = employee.Roles,
                Salary = employee.Salary,
                TeamId = employee.TeamId,
                UpdatedAt = employee.UpdatedAt,
            };
        }

        public GetOwner ownerResponse(Owner owner)
        {
            return new GetOwner()
            {
                Id = owner.Id,
                AccountStatus = owner.AccountStatus,
                Address = owner.Address,
                City = owner.City,
                Country = owner.Country,
                CompanyId = _dataContext.Companies.Where(c => c.OwnerId == owner.Id).FirstOrDefault()?.Id,
                CreatedAt = owner.CreatedAt,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Phone = owner.Phone,
                Roles = owner.Roles,
                UpdatedAt = owner.UpdatedAt,
                InvestmentDetails = owner.InvestmentDetails,
                OwnershipPercentage = owner.OwnershipPercentage,
                SubscriptionPlanId = _dataContext.SubscriptionPlans.Where(s => s.OwnerId == owner.Id).FirstOrDefault()?.Id,
            };
        }
    }
}
