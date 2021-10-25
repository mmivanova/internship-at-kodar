using System.Collections.Generic;
using TicketManager.Infrastructure.Domain.Entities;

namespace TicketManager.Core.Services.TicketService
{
    public interface ITicketService : IService<Ticket, int>
    {
        IEnumerable<Ticket> GetTicketsForUser(AppUser user);
    }
}