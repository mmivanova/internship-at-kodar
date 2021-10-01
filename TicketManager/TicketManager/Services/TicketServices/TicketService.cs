using System.Collections.Generic;
using System.Linq;
using TicketManager.Data;
using TicketManager.Repositories;

namespace TicketManager.Services.TicketServices
{
    public class TicketService : GenericService<Ticket, int>, ITicketService
    {
        public TicketService(IRepository<Ticket, int> repository) : base(repository)
        {
        }

        public IEnumerable<Ticket> GetTicketsByUser(AppUser user)
        {
            var ticketsByUser = GetAll().Where(t => t.AppUserId.Equals(user.Id));
            return ticketsByUser;
        }
    }
}