using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TicketManager.Areas.Identity.Data;
using TicketManager.Data;
using TicketManager.Dtos;

namespace TicketManager.Repositories.MessageRepository
{
    public class MessageRepository : GenericRepository<Message, int>, IMessageRepository
    {
        private readonly TicketManagerDbContext _context;

        public MessageRepository(TicketManagerDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<MessageDto> GetMessagesByTicketId(int ticketId)
        {
            var messages = _context
                .Messages
                .Where(m => m.TicketId.Equals(ticketId))
                .Join(
                    _context.AppUsers,
                    message => message.AppUserId,
                    user => user.Id,
                    (message, user) => new MessageDto()
                    {
                        Id = message.Id,
                        AppUserId = message.AppUserId, 
                        Content = message.Content, 
                        Image = message.Image, 
                        AuthorName = string.Concat(user.FirstName, " ", user.LastName),
                        DateCreated = message.DateCreated
                    })
                .OrderBy(m => m.DateCreated);

            var sql = messages.ToQueryString();

            return messages.ToList();
        } 
    }
}