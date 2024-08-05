using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayrollManagerAPI.Data;
using PayrollManagerAPI.Methods;
using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StakeholderController : ControllerBase
    {

        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly Mapping _mapping;

        public StakeholderController(DataContext dataContext, UserManager<AppUser> userManager, Mapping mapping, ILogger<EmployeeController> logger)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _mapping = mapping;
        }
    }
}
