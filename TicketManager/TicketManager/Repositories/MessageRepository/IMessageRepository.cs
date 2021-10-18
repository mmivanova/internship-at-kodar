using System.Collections.Generic;
using TicketManager.Data;

namespace TicketManager.Repositories.MessageRepository
{
    public interface IMessageRepository : IRepository<Message, int>
    {
        IEnumerable<Message> GetMessagesByTicketId(int ticketId);
        string GetMessageAuthor(int messageId);
    }
}