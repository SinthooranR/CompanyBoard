using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayrollManagerAPI.Data;
using PayrollManagerAPI.Methods;
using PayrollManagerAPI.Models.Dto;
using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly Mapping _mapping;

        public CompanyController(DataContext dataContext, UserManager<AppUser> userManager, Mapping mapping)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _mapping = mapping;
        }

        [HttpPost]
        public async Task<IActionResult> createCompany(CompanyCreateDto companyDto)
        {
            try
            {

                var user = await _userManager.FindByIdAsync(companyDto.OwnerId);

                if (user == null)
                {
                    ModelState.AddModelError("", "This Owner doesnt exist");
                }

                var companyMapping = _mapping.CompanyDtoToMain(companyDto);

                _dataContext.Companies.Add(companyMapping);
                _dataContext.SaveChanges();

                return Ok(companyMapping);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }


        }
    }
}
