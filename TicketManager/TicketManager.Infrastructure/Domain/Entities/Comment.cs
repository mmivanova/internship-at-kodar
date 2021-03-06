using System;

namespace TicketManager.Infrastructure.Domain.Entities
{
    public class Comment
    {
        public int Id { get; }
        public string AppUserId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public byte[] Image { get; set; }
        public int TicketId { get; set; }
    }
}