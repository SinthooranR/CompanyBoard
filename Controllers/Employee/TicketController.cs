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
        private readonly CreateMapping _createMapping;
        private readonly UpdateMapping _updateMapping;
        public TicketController(DataContext dataContext, UserManager<AppUser> userManager, CreateMapping createMapping, UpdateMapping updateMapping)
        {
            _dataContext = dataContext;
            _userManager = userManager;
            _createMapping = createMapping;
            _updateMapping = updateMapping;
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

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
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
        public async Task<IActionResult> createTicket([FromBody] TicketCreateDto ticketCreateDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(ticketCreateDto.UserId);

                if (user == null)
                {
                    ModelState.AddModelError("", "User not registered");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var ticket = _createMapping.TicketDtoToMain(ticketCreateDto);

                _dataContext.Tickets.Add(ticket);
                _dataContext.SaveChanges();

                return Ok(ticket);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        //Used for Assigning Employee by ID and Updating Information
        [HttpPut]
        public async Task<IActionResult> updateTicket([FromQuery] int ticketId, [FromQuery] int companyId, [FromQuery] string userId, [FromBody] TicketUpdateDto ticketUpdateDto)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    ModelState.AddModelError("", "User not registered");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var ticket = _updateMapping.TicketDtoToMain(ticketId, companyId, ticketUpdateDto);

                _dataContext.Tickets.Update(ticket);
                _dataContext.SaveChanges();

                return Ok(ticket);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> deleteTicket([FromQuery] string userId, int ticketId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    ModelState.AddModelError("", "User not registered");
                }

                var ticket = _dataContext.Tickets.Where(t => t.Id == ticketId).FirstOrDefault();

                if (ticket == null)
                {
                    ModelState.AddModelError("", "No Ticket Found");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _dataContext.Tickets.Remove(ticket);
                _dataContext.SaveChanges();

                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
