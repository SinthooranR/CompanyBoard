using PayrollManagerAPI.Data;
using PayrollManagerAPI.Models.Dto;
using PayrollManagerAPI.Models.Entity.EmployeeInfo;

namespace PayrollManagerAPI.Methods
{
    public class UpdateMapping
    {

        private readonly DataContext _dataContext;
        public UpdateMapping(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Ticket TicketDtoToMain(int ticketId, int companyId, TicketUpdateDto ticketUpdateDto)
        {
            var ticket = new Ticket()
            {
                Id = ticketId,
                Title = ticketUpdateDto.Title,
                Description = ticketUpdateDto.Description,
                AssignedDate = ticketUpdateDto.AssignedDate,
                DueDate = ticketUpdateDto.DueDate,
                EmployeeId = ticketUpdateDto.EmployeeId,
                CompanyId = companyId,
                Status = ticketUpdateDto.Status,
            };

            return ticket;
        }
    }
}
