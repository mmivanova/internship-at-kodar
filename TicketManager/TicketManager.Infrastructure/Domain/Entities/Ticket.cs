using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketManager.Infrastructure.Domain.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        
        public byte[] Image { get; set; }

        [ForeignKey("Id")] 
        public string AppUserId { get; set; }

        [Required]
        [EnumDataType(typeof(ReceiverId))]
        [Display(Name = "Receiver")]
        public ReceiverId ReceiverId { get; set; }

        public List<Comment> Comments { get; set; }
    }
}