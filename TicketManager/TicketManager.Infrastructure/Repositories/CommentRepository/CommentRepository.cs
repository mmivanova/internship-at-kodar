using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketManager.Infrastructure.Domain.Entities;
using TicketManager.Infrastructure.Data;

namespace TicketManager.Infrastructure.Repositories.CommentRepository
{
    public class CommentRepository : GenericRepository<Comment, int>, ICommentRepository
    {
        private readonly TicketManagerDbContext _context;

        public CommentRepository(TicketManagerDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Comment> GetCommentsByTicketId(int ticketId)
        {
            var comments = _context
                .Comments
                .FromSqlRaw($@"select Id, AppUserId, Content, DateCreated, Image, TicketId
                                from [dbo].[Comments]
                                where TicketId = {ticketId}
                                order by DateCreated")
                .ToList();

            return comments;
        }
    }
}