using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TicketManager.Data;

namespace TicketManager.Repositories.TicketRepository
{
    public interface ITicketRepository : IRepository<Ticket, int>
    {
        IEnumerable<Ticket> GetDevelopersTickets(AppUser user);
        IEnumerable<Ticket> GetManagersTickets(int roleId);
    }
}