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
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly Mapping _mapping;

        public EmployeeController(DataContext dataContext, UserManager<AppUser> userManager, Mapping mapping, ILogger<EmployeeController> logger)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _mapping = mapping;
        }

        [HttpGet]
        public IActionResult getEmployees()
        {
            var employees = _dataContext.Employees.ToList();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> registerEmployee([FromBody] EmployeeRegisterDto employeeDto)
        {
            try
            {

                var checkOwner = _dataContext.Owners.Where(o => o.Id == employeeDto.OwnerId).FirstOrDefault();

                if (checkOwner == null || checkOwner.Roles.Contains("Admin"))
                {
                    ModelState.AddModelError("", "Invalid Owner");
                }

                var checkCompany = _dataContext.Companies.Where(c => c.Id == employeeDto.CompanyId).FirstOrDefault();

                if (checkCompany == null)
                {
                    ModelState.AddModelError("", "Company doesn't exist");
                }

                var checkEmailExists = _dataContext.Users.Where(u => u.Email == employeeDto.Email).ToList();

                if (checkEmailExists.Any())
                {
                    ModelState.AddModelError("", "Email already exists, use another one");
                }

                var newEmployee = _mapping.EmployeeDtoToMain(employeeDto);

                var result = await _userManager.CreateAsync(newEmployee, employeeDto.Password);

                if (result.Succeeded)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
