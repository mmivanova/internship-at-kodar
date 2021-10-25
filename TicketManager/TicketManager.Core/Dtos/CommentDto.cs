using System;

namespace TicketManager.Core.Dtos
{
    public class CommentDto
    {
        public int  Id { get; set; }
        public byte[] Image { get; set; }
        public string AppUserId { get; set; }
        public string AuthorName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
    }
}