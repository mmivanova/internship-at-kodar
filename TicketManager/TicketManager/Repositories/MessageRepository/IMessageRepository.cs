using System.Collections.Generic;
using TicketManager.Data;
using TicketManager.Dtos;

namespace TicketManager.Repositories.MessageRepository
{
    public interface IMessageRepository : IRepository<Message, int>
    {
        IEnumerable<MessageDto> GetMessagesByTicketId(int ticketId);
    }
}