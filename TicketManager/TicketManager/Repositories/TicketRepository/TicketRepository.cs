using TicketManager.Areas.Identity.Data;
using TicketManager.Data;

namespace TicketManager.Repositories.TicketRepository
{
    public class TicketRepository : GenericRepository<Ticket, int>, ITicketRepository
    {
        public TicketRepository(TicketManagerDbContext context) : base(context)
        {
        }
    }
}