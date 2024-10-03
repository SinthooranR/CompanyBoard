﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PayrollManagerAPI.Data;
using PayrollManagerAPI.Models.Entity.EmployeeInfo;
using PayrollManagerAPI.Models.Entity.Users;
using PayrollManagerAPI.RepositoryPattern.Interface;

namespace PayrollManagerAPI.RepositoryPattern.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;

        public TicketRepository(DataContext dataContext, UserManager<AppUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public async Task<Ticket> createTicket(Ticket ticket)
        {
            _dataContext.Tickets.Add(ticket);
            _dataContext.SaveChanges();

            return ticket;
        }

        public async Task<ICollection<Ticket>> getTicketsByCompanyId(int companyId)
        {
            var tickets = await _dataContext.Tickets.Where(t => t.CompanyId == companyId).ToListAsync();
            return tickets;
        }

        public async Task<Ticket> updateTicket(Ticket ticket)
        {
            _dataContext.Tickets.Update(ticket);
            _dataContext.SaveChanges();

            return ticket;
        }
    }
}
