using System.Collections.Generic;
using TicketManager.Infrastructure.Domain.Entities;

namespace TicketManager.Infrastructure.Repositories.CommentRepository
{
    public interface ICommentRepository : IRepository<Comment, int>
    {
        IEnumerable<Comment> GetCommentsByTicketId(int ticketId);
    }
}