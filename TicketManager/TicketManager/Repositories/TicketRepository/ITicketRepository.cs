using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TicketManager.Data;

namespace TicketManager.Repositories.TicketRepository
{
    public interface ITicketRepository : IRepository<Ticket, int>
    {
        IEnumerable<Ticket> GetTicketsByUser(AppUser user);
        IEnumerable<Ticket> GetInitialTickets(AppUser user);
        IEnumerable<Ticket> GetOfficeManagersTickets();
        IEnumerable<Ticket> GetTechnicalManagersTickets();
    }
}