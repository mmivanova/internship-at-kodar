using System.Collections.Generic;
using TicketManager.Data;
using TicketManager.Dtos;
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

        public IEnumerable<MessageDto> GetMessagesByTicketId(int ticketId)
        {
            return _repository.GetMessagesByTicketId(ticketId);
        }
    }
}