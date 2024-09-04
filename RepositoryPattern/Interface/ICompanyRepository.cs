using PayrollManagerAPI.Models.Entity;

namespace PayrollManagerAPI.RepositoryPattern.Interface
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompany(int companyId);

        Task<Company> CreateCompany(Company company);
    }
}
