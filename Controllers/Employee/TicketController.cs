using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PayrollManagerAPI.Data;
using PayrollManagerAPI.Methods;
using PayrollManagerAPI.Models.Dto;
using PayrollManagerAPI.Models.Entity.Users;

namespace PayrollManagerAPI.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        private readonly EmployeeMapping _employeeMapping;
        public TicketController(DataContext dataContext, UserManager<AppUser> userManager, EmployeeMapping employeeMapping)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _employeeMapping = employeeMapping;
        }

        [HttpGet]
        public async Task<IActionResult> getTicketByEmployeeId(string employeeId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(employeeId);

                if (user == null)
                {
                    ModelState.AddModelError("", "Employee not registered");
                }

                var tickets = _dataContext.Tickets.Where(t => t.EmployeeId == employeeId).ToList();

                return Ok(tickets);
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> createTicket(TicketCreateDto ticketCreateDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(ticketCreateDto.UserId);

                if (user == null)
                {
                    ModelState.AddModelError("", "User not registered");
                }

                var ticket = _employeeMapping.TicketDtoToMain(ticketCreateDto);

                _dataContext.Tickets.Add(ticket);
                _dataContext.SaveChanges();

                return Ok(ticket);

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ticketCreateDto);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
