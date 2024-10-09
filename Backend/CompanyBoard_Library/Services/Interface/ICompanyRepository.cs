

using CompanyBoard_Library.Models.Entity;

namespace CompanyBoard_Library.RepositoryPattern.Interface
{
    public interface ICompanyRepository
    {
        Task<Company> GetCompany(int companyId);

        Task<Company> GetCompanyByInvite(string inviteCode);

        Task<Company> CreateCompany(Company company);
    }
}
