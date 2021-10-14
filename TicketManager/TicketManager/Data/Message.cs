using System;

namespace TicketManager.Data
{
    public class Message
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
        public byte[] Image { get; set; }
        public int TicketId { get; set; }
    }
}