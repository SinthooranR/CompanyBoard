using Microsoft.AspNetCore.Mvc;
using PayrollManagerAPI.Data;

namespace PayrollManagerAPI.Controllers
{
    public class UserController : ControllerBase
    {

        private readonly DataContext _context;
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

        [HttpPost]
        public async Task<IActionResult> registerUser()
        {
            return Ok("Registered");
        }


    }
}
