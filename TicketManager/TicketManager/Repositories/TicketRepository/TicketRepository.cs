using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketManager.Areas.Identity.Data;
using TicketManager.Data;

namespace TicketManager.Repositories.TicketRepository
{
    public class TicketRepository : GenericRepository<Ticket, int>, ITicketRepository
    {
        private readonly TicketManagerDbContext _context;

        public TicketRepository(TicketManagerDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Ticket> GetDevelopersTickets(AppUser user)
        {
            var tickets = _context
                .Tickets
                .FromSqlRaw(@$"select Id, Description, IsPrivate, Image, ReceiverId, AppUserId, Name
                                from [dbo].[Tickets] 
                                where AppUserId = '{user.Id}'
                                union 
                                select Id, Description, IsPrivate, Image, ReceiverId, AppUserId, Name
                                from [dbo].[Tickets]
                                where IsPrivate = 'false';")
                .ToList();

            return tickets;
        }

        public IEnumerable<Ticket> GetManagersTickets(int roleId)
        {
            //TODO ValidateId(roleId);
            
            var tickets = _context
                .Tickets
                .FromSqlRaw(@$"select Id, Description, IsPrivate, Image, ReceiverId, AppUserId, Name
                                from [dbo].[Tickets] 
                                where ReceiverId = {roleId}")
                .ToList();

            return tickets;
        }
    }
}