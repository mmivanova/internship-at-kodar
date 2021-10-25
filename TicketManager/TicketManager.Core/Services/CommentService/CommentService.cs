using System.Collections.Generic;
using System.Linq;
using TicketManager.Core.Dtos;
using TicketManager.Core.Mappers.CommentMapper;
using TicketManager.Infrastructure.Domain.Entities;
using TicketManager.Infrastructure.Repositories.CommentRepository;

namespace TicketManager.Core.Services.CommentService
{
    public class CommentService : GenericService<Comment, int>, ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly ICommentMapper _mapper;
        
        public CommentService(ICommentRepository repository, ICommentMapper mapper) : base(repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<CommentDto> GetCommentsByTicketId(int ticketId)
        {
            var comments = _repository
                .GetCommentsByTicketId(ticketId)
                .Select(comment => _mapper.MapCommentToDto(comment));
            
            return comments;
        }
    }
}