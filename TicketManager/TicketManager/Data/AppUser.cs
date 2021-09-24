using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TicketManager.Data
{
    public class AppUser : IdentityUser
    {
        [Required]
        public Account Account { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        [EnumDataType(typeof(JobTitleId))]
        public JobTitleId JobTitleId { get; set; }
    }
}