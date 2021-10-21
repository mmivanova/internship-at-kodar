using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketManager.Areas.Identity.Data;
using TicketManager.Data;
using TicketManager.Dtos;

namespace TicketManager.Repositories.CommentRepository
{
    public class CommentRepository : GenericRepository<Comment, int>, ICommentRepository
    {
        private readonly TicketManagerDbContext _context;

        public CommentRepository(TicketManagerDbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<CommentDto> GetCommentsByTicketId(int ticketId)
        {
            var comments = _context
                .Comments
                .Where(m => m.TicketId.Equals(ticketId))
                .Join(
                    _context.AppUsers,
                    comment => comment.AppUserId,
                    user => user.Id,
                    (comment, user) => new CommentDto()
                    {
                        Id = comment.Id,
                        AppUserId = comment.AppUserId, 
                        Content = comment.Content, 
                        Image = comment.Image, 
                        AuthorName = string.Concat(user.FirstName, " ", user.LastName),
                        DateCreated = comment.DateCreated
                    })
                .OrderBy(c => c.DateCreated);

            var sql = comments.ToQueryString();

            return comments.ToList();
        } 
    }
}