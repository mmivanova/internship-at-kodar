using TicketManager.Areas.Identity.Data;
using TicketManager.Data;

namespace TicketManager.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<AppUser, string>, IUserRepository
    {
        public UserRepository(TicketManagerDbContext dbContext) : base(dbContext)
        {
        }
    }
}