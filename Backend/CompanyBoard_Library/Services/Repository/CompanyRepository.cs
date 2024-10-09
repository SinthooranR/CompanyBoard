using CompanyBoard_Library.Data;
using CompanyBoard_Library.Models.Entity;
using CompanyBoard_Library.Models.Entity.Users;
using CompanyBoard_Library.RepositoryPattern.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CompanyBoard_Library.RepositoryPattern.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        public CompanyRepository(DataContext dataContext, UserManager<AppUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }


        public async Task<Company> CreateCompany(Company company)
        {
            Console.WriteLine(company);
            await _dataContext.Companies.AddAsync(company);
            await _dataContext.SaveChangesAsync();

            return company;

        }

        public async Task<Company> GetCompany(int companyId)
        {
            var company = await _dataContext.Companies.Where(c => c.Id == companyId).FirstOrDefaultAsync();
            return company;
        }

        public async Task<Company> GetCompanyByInvite(string inviteCode)
        {
            var company = await _dataContext.Companies.Where(c => c.InviteCode == inviteCode).FirstOrDefaultAsync();
            return company;
        }
    }
}
