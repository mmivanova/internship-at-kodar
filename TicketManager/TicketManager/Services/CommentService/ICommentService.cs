using System.Collections.Generic;
using TicketManager.Data;
using TicketManager.Dtos;

namespace TicketManager.Services.CommentService
{
    public interface ICommentService : IService<Comment, int>
    {
        IEnumerable<CommentDto> GetCommentsByTicketId(int ticketId);
    }
}