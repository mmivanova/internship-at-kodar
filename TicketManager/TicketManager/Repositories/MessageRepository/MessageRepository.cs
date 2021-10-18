using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketManager.Areas.Identity.Data;
using TicketManager.Data;

namespace TicketManager.Repositories.MessageRepository
{
    public class MessageRepository : GenericRepository<Message, int>, IMessageRepository
    {
        private readonly TicketManagerDbContext _context;

        public MessageRepository(TicketManagerDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Message> GetMessagesByTicketId(int ticketId)
        {
            var messages = _context
                .Messages
                .FromSqlRaw(@$"select Id, AppUserId, Content, DateCreated, Image, TicketId
                                from [dbo].[Messages] 
                                where TicketId = '{ticketId}'")
                .ToList();

            return messages;
        }

        public string GetMessageAuthor(int messageId)
        {
            var name = _context
                .AppUsers
                .FromSqlRaw($@"select u.FirstName, u.LastName
                               from [dbo].[Messages] m
                               inner join [dbo].[AspNetUsers] u
                               on m.AppUserId = u.Id
                               where m.Id = {messageId}")
                .Select(user => new
                {
                    Name = $"{user.FirstName} {user.LastName}"
                })
                .First();

            return name.Name;
        }
    }
}