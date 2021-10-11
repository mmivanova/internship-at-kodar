using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManager.Data
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        
        public byte[] Image { get; set; }

        [ForeignKey("Id")]
        public string AppUserId { get; set; }
        
        [Required]
        [EnumDataType(typeof(ReceiverId))]
        public ReceiverId ReceiverId { get; set; }
    }
}