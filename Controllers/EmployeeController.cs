using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayrollManagerAPI.Data;
using PayrollManagerAPI.Methods;
using PayrollManagerAPI.Models.Dto;
using PayrollManagerAPI.Models.Entity.Users;
using PayrollManagerAPI.Repository.Interface;
using PayrollManagerAPI.RepositoryPattern.Interface;

namespace PayrollManagerAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly CreateMapping _createMapping;
        private readonly UpdateMapping _updateMapping;
        private readonly ResponseMapping _responseMapping;
        private readonly IUserRepository _userRepository;
        private readonly ICompanyRepository _companyRepository;

        public EmployeeController(DataContext dataContext, UserManager<AppUser> userManager, CreateMapping createMapping, UpdateMapping updateMapping, ResponseMapping responseMapping, IUserRepository userRepository, ICompanyRepository companyRepository)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _createMapping = createMapping;
            _updateMapping = updateMapping;
            _responseMapping = responseMapping;
            _userRepository = userRepository;
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getEmployees([FromQuery] int companyId)
        {
            try
            {
                var employees = await _userRepository.GetEmployeesByCompany(companyId);
                var newEmployees = employees.Select(e => _responseMapping.employeeResponse(e)).ToList();
                return Ok(newEmployees);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("employeeId")]
        public async Task<IActionResult> getEmployeeById([FromQuery] string employeeId)
        {
            try
            {
                var employee = await _userRepository.GetEmployeeById(employeeId);

                if (employee == null)
                {
                    ModelState.AddModelError("", "No Employee Data Found");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newEmployee = _responseMapping.employeeResponse(employee);

                return Ok(newEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> registerEmployee([FromBody] EmployeeRegisterDto employeeDto)
        {
            try
            {

                var checkCompany = await _companyRepository.GetCompanyByInvite(employeeDto.InviteCode);

                if (checkCompany == null)
                {
                    ModelState.AddModelError("", "Invalid Invite Code");
                }

                var checkEmailExists = await _userRepository.CheckUserByEmail(employeeDto.Email);
                Ok(checkEmailExists);
                if (checkEmailExists != null)
                {
                    ModelState.AddModelError("", "Email already exists, use another one");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newEmployee = _createMapping.EmployeeDtoToMain(employeeDto);


                await _userRepository.CreateEmployee(newEmployee, employeeDto.Password);

                return Ok(newEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
