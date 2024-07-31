using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollManagerAPI.Data;
using PayrollManagerAPI.Methods;
using PayrollManagerAPI.Models.Dto;
using PayrollManagerAPI.Models.Entity.Users;
using PayrollManagerAPI.Services;

namespace PayrollManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenGenerator _tokenGenerator;
        private readonly Mapping _mapping;

        public OwnerController(DataContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenGenerator tokenGenerator, Mapping mapping)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
            _mapping = mapping;
        }

        [HttpGet("getOwners")]
        public async Task<IActionResult> getOwners()
        {
            var dataContext = _context.Owners.Include(o => o.Company).ToList();
            return Ok(dataContext);
        }


        [HttpPost]
        public async Task<IActionResult> registerOwner([FromBody] OwnerDto ownerDto)
        {
            try
            {
                var checkEmailExists = _context.Owners.Where(o => o.Email == ownerDto.Email).ToList();

                if (checkEmailExists.Any())
                {
                    ModelState.AddModelError("", "Email already exists, use another one");
                }

                var newOwner = _mapping.OwnerDtotoMain(ownerDto);

                var result = await _userManager.CreateAsync(newOwner, ownerDto.Password);

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



        [HttpPost("login")]
        public async Task<IActionResult> loginOwner([FromBody] OwnerLoginDto ownerLoginDto)
        {
            try
            {
                var existingOwner = await _userManager.FindByEmailAsync(ownerLoginDto.Email);

                if (existingOwner == null)
                {
                    ModelState.AddModelError("", "Email not found, please register");
                }

                var result = await _signInManager.PasswordSignInAsync(existingOwner.UserName, ownerLoginDto.Password, false, false);

                if (result.Succeeded)
                {
                    var token = _tokenGenerator.GenerateToken(existingOwner);

                    Response.Cookies.Append("token", token, new CookieOptions
                    {
                        SameSite = SameSiteMode.None,
                        Secure = true,
                        Path = "/",
                        IsEssential = true
                    });


                    return Ok(new { Token = token });
                }
                else
                {
                    return BadRequest("Login failed: Invalid credentials.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }



    }
}
