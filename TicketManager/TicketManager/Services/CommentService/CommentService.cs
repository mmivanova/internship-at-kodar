using System.Collections.Generic;
using TicketManager.Data;
using TicketManager.Dtos;
using TicketManager.Repositories.CommentRepository;

namespace TicketManager.Services.CommentService
{
    public class CommentService : GenericService<Comment, int>, ICommentService
    {
        private readonly ICommentRepository _repository;
        public CommentService(ICommentRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<CommentDto> GetCommentsByTicketId(int ticketId)
        {
            return _repository.GetCommentsByTicketId(ticketId);
        }
    }
}