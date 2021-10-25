using System.ComponentModel.DataAnnotations;

namespace TicketManager.Infrastructure.Domain.Entities
{
    public class JobTitle
    {
        public JobTitleId Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
