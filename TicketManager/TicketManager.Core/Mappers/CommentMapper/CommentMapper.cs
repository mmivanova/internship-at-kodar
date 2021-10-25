using TicketManager.Core.Dtos;
using TicketManager.Core.Services.UserService;
using TicketManager.Infrastructure.Domain.Entities;

namespace TicketManager.Core.Mappers.CommentMapper
{
    public class CommentMapper : ICommentMapper
    {
        private readonly IUserService _userService;

        public CommentMapper(IUserService userService)
        {
            _userService = userService;
        }

        public CommentDto MapCommentToDto(Comment comment)
        {
            var commentDto = new CommentDto
            {
                Id = comment.Id,
                AppUserId = comment.AppUserId,
                Content = comment.Content,
                DateCreated = comment.DateCreated,
                Image = comment.Image,
                AuthorName = _userService.GetAppUserNameById(comment.AppUserId)
            };

            return commentDto;
        }
    }
}