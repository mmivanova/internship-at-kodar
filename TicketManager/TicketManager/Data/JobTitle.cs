using Microsoft.Build.Framework;

namespace TicketManager.Data
{
    public class JobTitle
    {
        public JobTitleId Id { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}
