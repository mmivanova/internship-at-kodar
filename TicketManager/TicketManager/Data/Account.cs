using System.ComponentModel.DataAnnotations;

namespace TicketManager.Data
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password{ get; set; }
    }
}