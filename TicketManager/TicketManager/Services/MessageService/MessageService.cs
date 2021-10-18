using System.Collections.Generic;
using TicketManager.Data;
using TicketManager.Repositories.MessageRepository;

namespace TicketManager.Services.MessageService
{
    public class MessageService : GenericService<Message, int>, IMessageService
    {
        private readonly IMessageRepository _repository;
        public MessageService(IMessageRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Message> GetMessagesByTicketId(int ticketId)
        {
            return _repository.GetMessagesByTicketId(ticketId);
        }

        public string GetMessageAuthor(int messageId)
        {
            return _repository.GetMessageAuthor(messageId);
        }
    }
}