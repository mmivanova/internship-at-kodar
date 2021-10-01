using System.Collections.Generic;
using TicketManager.Data;

namespace TicketManager.Services.TicketServices
{
    public interface ITicketService : IService<Ticket, int>
    {
        IEnumerable<Ticket> GetTicketsByUser(AppUser user);
    }
}