using TicketManager.Data;
using TicketManager.Repositories;
using TicketManager.Repositories.MessageRepository;

namespace TicketManager.Services.MessageService
{
    public class MessageService : GenericService<Message, int>, IMessageService
    {
        public MessageService(IMessageRepository repository) : base(repository)
        {
        }
    }
}