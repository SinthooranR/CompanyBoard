using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Repository.Interface
{
    public interface IUserRepository
    {
        Task<Owner> CreateOwner(Owner owner, string password);

        Task<Employee> CreateEmployee(Employee employee, string password);

        Task<Employee> GetEmployeeById(string employeeId);

        Task<ICollection<Employee>> GetEmployeesByCompany(int companyId);

        Task<AppUser> CheckUserByEmail(string email);

        Task<AppUser> CheckUserById(string userId);


    }
}
