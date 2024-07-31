using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayrollManagerAPI.Data;
using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Controllers
{
    public class UserController : ControllerBase
    {

        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;
        public UserController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> getUsers()
        {
            var dataContext = _context.Users.ToList();
            return Ok(dataContext);
        }


    }
}
