using System.Collections.Generic;
using TicketManager.Infrastructure.Domain.Entities;

namespace TicketManager.Infrastructure.Repositories.TicketRepository
{
    public interface ITicketRepository : IRepository<Ticket, int>
    {
        IEnumerable<Ticket> GetDevelopersTickets(AppUser user);
        IEnumerable<Ticket> GetManagersTickets(int roleId);
    }
}