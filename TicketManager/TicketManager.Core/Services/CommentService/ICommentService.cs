using System.Collections.Generic;
using TicketManager.Core.Dtos;
using TicketManager.Infrastructure.Domain.Entities;

namespace TicketManager.Core.Services.CommentService
{
    public interface ICommentService : IService<Comment, int>
    {
        IEnumerable<CommentDto> GetCommentsByTicketId(int ticketId);
    }
}