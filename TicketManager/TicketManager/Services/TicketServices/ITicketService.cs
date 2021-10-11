using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TicketManager.Data;

namespace TicketManager.Services.TicketServices
{
    public interface ITicketService : IService<Ticket, int>
    {
        IEnumerable<Ticket> GetTicketsByUser(AppUser user);
        IEnumerable<Ticket> GetTicketsForUser(AppUser user);

        IEnumerable<Ticket> GetTicketsByUserRole(IdentityRole role);
    }
}