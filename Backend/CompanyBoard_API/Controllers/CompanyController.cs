using CompanyBoard_Library.Data;
using CompanyBoard_Library.Methods;
using CompanyBoard_Library.Models.Dto;
using CompanyBoard_Library.Models.Entity.Users;
using CompanyBoard_Library.RepositoryPattern.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CompanyBoard_Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly CreateMapping _createMapping;
        private readonly UpdateMapping _updateMapping;
        private readonly ICompanyRepository _companyRepository;
        public CompanyController(DataContext dataContext, UserManager<AppUser> userManager, CreateMapping createMapping, UpdateMapping updateMapping, ICompanyRepository companyRepository)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _createMapping = createMapping;
            _updateMapping = updateMapping;
            _companyRepository = companyRepository;
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

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var companyMapping = _createMapping.CompanyDtoToMain(companyDto);

                await _companyRepository.CreateCompany(companyMapping);
                return Ok(companyMapping.CompanyName);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> getCompanyById([FromQuery] int id)
        {
            var company = await _companyRepository.GetCompany(id);


            if (company == null)
            {
                ModelState.AddModelError("", "This Company doesnt exist");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(company);
        }
    }
}
