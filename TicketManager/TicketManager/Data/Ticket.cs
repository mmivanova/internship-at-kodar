using System.Drawing;

namespace TicketManager.Data
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsPrivate { get; set; }
        //public Image Image { get; set; }
    }
}