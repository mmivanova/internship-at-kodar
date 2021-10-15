using TicketManager.Areas.Identity.Data;
using TicketManager.Data;

namespace TicketManager.Repositories.MessageRepository
{
    public class MessageRepository : GenericRepository<Message, int>, IMessageRepository
    {
        public MessageRepository(TicketManagerDbContext context) : base(context)
        {
        }
    }
}