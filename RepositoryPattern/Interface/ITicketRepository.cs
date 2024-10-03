using PayrollManagerAPI.Models.Entity.EmployeeInfo;

namespace PayrollManagerAPI.RepositoryPattern.Interface
{
    public interface ITicketRepository
    {

        Task<ICollection<Ticket>> getTicketsByCompanyId(int companyId);
        Task<Ticket> createTicket(Ticket ticket);
        Task<Ticket> updateTicket(Ticket ticket);

        //Task deleteTicket(string id);


    }
}
