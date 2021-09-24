using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TicketManager.Areas.Identity.Data;
using TicketManager.Data;

namespace TicketManager.Repositories.UserRepository
{
    public class UserRepository
    {
        private readonly TicketManagerDbContext _dbContext;
        private DbSet<AppUser> _table;

        public UserRepository(TicketManagerDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<AppUser>();
        }
        
        public async Task<AppUser> GetUserById(int id)
        {
            var user = await _table.FindAsync(id);
            return user;
        }

        public void Add(AppUser user)
        {
            _table.Add(user);
            _dbContext.SaveChanges();
        }
        
    }
}
