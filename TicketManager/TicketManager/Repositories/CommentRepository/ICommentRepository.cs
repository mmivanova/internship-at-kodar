using System.Collections.Generic;
using TicketManager.Data;
using TicketManager.Dtos;

namespace TicketManager.Repositories.CommentRepository
{
    public interface ICommentRepository : IRepository<Comment, int>
    {
        IEnumerable<CommentDto> GetCommentsByTicketId(int ticketId);
    }
}