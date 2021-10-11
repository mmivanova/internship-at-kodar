using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
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

        public IEnumerable<Ticket> GetTicketsByUser(AppUser user)
        {
            var test = _context.Tickets
                .FromSqlRaw(@$"select Id, Description, IsPrivate, Image, ReceiverId, AppUserId, Name
                                from [dbo].[Tickets] 
                                where AppUserId = '{user.Id}'")
                .ToList();

            return test;
        }

        public IEnumerable<Ticket> GetInitialTickets(AppUser user)
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

        public IEnumerable<Ticket> GetOfficeManagersTickets()
        {
            var tickets = _context
                .Tickets
                .Where(t => t.ReceiverId.Equals(4))
                .ToList();

            return tickets;
        }

        public IEnumerable<Ticket> GetTechnicalManagersTickets()
        {
            var tickets = _context
                .Tickets
                .Where(t => t.ReceiverId.Equals(5))
                .ToList();

            return tickets;
        }
    }
}