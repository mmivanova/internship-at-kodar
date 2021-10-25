using TicketManager.Core.Dtos;
using TicketManager.Infrastructure.Domain.Entities;

namespace TicketManager.Core.Mappers.CommentMapper
{
    public interface ICommentMapper
    {
        public CommentDto MapCommentToDto(Comment comment);
    }
}