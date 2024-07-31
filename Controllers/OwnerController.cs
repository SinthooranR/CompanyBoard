using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayrollManagerAPI.Data;

namespace PayrollManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly DataContext _context;

        public OwnerController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("getOwners")]
        public async Task<IActionResult> getOwners()
        {
            var dataContext = _context.Owners.Include(o => o.Company).Include(o => o.User).ToList();
            return Ok(dataContext);
        }





    }
}
