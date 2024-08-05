using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayrollManagerAPI.Data;
using PayrollManagerAPI.Models.Dto;
using PayrollManagerAPI.Models.Entity.Users;
using PayrollManagerAPI.Services;

namespace PayrollManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenGenerator _tokenGenerator;
        public UserController(DataContext dataContext, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, TokenGenerator tokenGenerator)
        {
            _dataContext = dataContext;
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenGenerator = tokenGenerator;
        }


        [HttpGet]
        public async Task<IActionResult> getUsers()
        {
            var dataContext = _dataContext.Users.ToList();
            return Ok(dataContext);
        }


        [HttpPost("login")]
        public async Task<IActionResult> loginUser([FromBody] UserLoginDto userLoginDto)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(userLoginDto.Email);

                if (existingUser == null)
                {
                    ModelState.AddModelError("", "Email not found, please register");
                }

                var result = await _signInManager.PasswordSignInAsync(existingUser.UserName, userLoginDto.Password, false, false);

                if (result.Succeeded)
                {
                    var token = _tokenGenerator.GenerateToken(existingUser);

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
