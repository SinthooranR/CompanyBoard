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
        private readonly CreateMapping _createMapping;
        private readonly UpdateMapping _updateMapping;
        public StakeholderController(DataContext dataContext, UserManager<AppUser> userManager, CreateMapping createMapping, UpdateMapping updateMapping)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _createMapping = createMapping;
            _updateMapping = updateMapping;
        }
    }
}
