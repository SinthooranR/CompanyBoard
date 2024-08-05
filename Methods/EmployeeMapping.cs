using PayrollManagerAPI.Data;
using PayrollManagerAPI.Models.Dto;
using PayrollManagerAPI.Models.Entity.EmployeeInfo;

namespace PayrollManagerAPI.Methods
{
    public class EmployeeMapping
    {

        private readonly DataContext _dataContext;
        public EmployeeMapping(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Ticket TicketDtoToMain(TicketCreateDto ticketCreateDto)
        {
            var ticket = new Ticket()
            {
                Title = ticketCreateDto.Title,
                Description = ticketCreateDto.Description,
                AssignedDate = ticketCreateDto.AssignedDate,
                DueDate = ticketCreateDto.DueDate,
                EmployeeId = ticketCreateDto.EmployeeId,
                Status = "Todo"
            };

            return ticket;
        }

    }
}
