using CompanyBoard_Library.Data;
using CompanyBoard_Library.Methods;
using CompanyBoard_Library.Models.Dto;
using CompanyBoard_Library.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CompanyBoard_Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly CreateMapping _createMapping;
        private readonly UpdateMapping _updateMapping;
        private readonly ResponseMapping _responseMapping;
        private readonly IUserRepository _userRepository;
        public OwnerController(DataContext dataContext, CreateMapping createMapping, UpdateMapping updateMapping, ResponseMapping responseMapping, IUserRepository userRepository)
        {
            _dataContext = dataContext;
            _createMapping = createMapping;
            _updateMapping = updateMapping;
            _responseMapping = responseMapping;
            _userRepository = userRepository;
        }

        [HttpGet("id")]
        //[ProducesResponseType(typeof(OwnerCreateDto), 200)]
        public async Task<IActionResult> getOwnerById([FromQuery] string id)
        {
            var owner = _dataContext.Owners.Where(o => o.Id == id).FirstOrDefault();

            if (owner == null)
            {
                ModelState.AddModelError("", "Owner doesnt exist");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newOwner = _responseMapping.ownerResponse(owner);
            return Ok(newOwner);
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


                var newResOwner = _responseMapping.ownerResponse(newOwner);

                return Ok(newResOwner);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
