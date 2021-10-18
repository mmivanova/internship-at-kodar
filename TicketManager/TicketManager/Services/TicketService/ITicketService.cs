using System.Collections.Generic;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using TicketManager.Data;

namespace TicketManager.Services.TicketService
{
    public interface ITicketService : IService<Ticket, int>
    {
        IEnumerable<Ticket> GetTicketsForUser(AppUser user);
    }
}