using CompanyBoard_Library.Data;
using CompanyBoard_Library.Models.Entity.Users;
using CompanyBoard_Library.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CompanyBoard_Library.Services.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(DataContext dataContext, UserManager<AppUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public async Task<AppUser> CheckUserByEmail(string email)
        {
            var user = await _dataContext.Users.Where(o => o.Email == email).FirstOrDefaultAsync();

            return user;
        }

        public async Task<AppUser> CheckUserById(string userId)
        {
            var user = _dataContext.Users.Where(o => o.Id == userId).FirstOrDefault();

            return user;
        }

        public async Task<Owner> CreateOwner(Owner owner, string password)
        {
            var result = await _userManager.CreateAsync(owner, password);

            if (result.Succeeded)
            {
                return owner;
            }
            else
            {
                throw new Exception("Unknown Error " + result.Errors.Select(e => e.Description));
            }
        }

        public async Task<Employee> CreateEmployee(Employee employee, string password)
        {
            var result = await _userManager.CreateAsync(employee, password);

            if (result.Succeeded)
            {
                return employee;
            }
            else
            {
                throw new Exception("Unknown Error " + result.Errors.Select(e => e.Description));
            }
        }


        public async Task<Employee> GetEmployeeById(string employeeId)
        {
            var employee = await _dataContext.Employees.Where(e => e.Id == employeeId).FirstOrDefaultAsync();
            return employee;
        }

        public async Task<ICollection<Employee>> GetEmployeesByCompany(int companyId)
        {
            var employee = await _dataContext.Employees.Where(c => c.CompanyId == companyId).ToListAsync();
            return employee;
        }
    }
}
