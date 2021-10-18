using System.Collections.Generic;
using TicketManager.Data;

namespace TicketManager.Services.MessageService
{
    public interface IMessageService : IService<Message, int>
    {
        IEnumerable<Message> GetMessagesByTicketId(int ticketId);

        string GetMessageAuthor(int messageId);
    }
}