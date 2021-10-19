using System;

namespace TicketManager.Dtos
{
    public class MessageDto
    {
        public int  Id { get; set; }
        public byte[] Image { get; set; }
        public string AppUserId { get; set; }
        public string AuthorName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Content { get; set; }
    }
}