using System.Collections.Generic;
using TicketManager.Data;
using TicketManager.Dtos;

namespace TicketManager.Services.MessageService
{
    public interface IMessageService : IService<Message, int>
    {
        IEnumerable<MessageDto> GetMessagesByTicketId(int ticketId);
    }
}