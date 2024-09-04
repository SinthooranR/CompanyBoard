using Microsoft.AspNetCore.Mvc;
using PayrollManagerAPI.Data;
using PayrollManagerAPI.Methods;
using PayrollManagerAPI.Models.Dto;
using PayrollManagerAPI.Repository.Interface;

namespace PayrollManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly CreateMapping _createMapping;
        private readonly UpdateMapping _updateMapping;
        private readonly IUserRepository _userRepository;
        public OwnerController(DataContext dataContext, CreateMapping createMapping, UpdateMapping updateMapping, IUserRepository userRepository)
        {
            _dataContext = dataContext;
            _createMapping = createMapping;
            _updateMapping = updateMapping;
            _userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(OwnerCreateDto), 200)]
        public async Task<IActionResult> getOwners()
        {
            var owners = _dataContext.Owners.ToList();
            return Ok(owners);
        }


        [HttpPost]
        public async Task<IActionResult> registerOwner([FromBody] OwnerCreateDto ownerDto)
        {
            try
            {
                var checkEmailExists = await _userRepository.CheckUserByEmail(ownerDto.Email);

                if (checkEmailExists != null)
                {
                    ModelState.AddModelError("", "Email already exists, use another one");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newOwner = _createMapping.OwnerDtotoMain(ownerDto);

                await _userRepository.CreateOwner(newOwner, ownerDto.Password);

                return Ok(newOwner);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

    }
}
