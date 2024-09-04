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
    }
}
