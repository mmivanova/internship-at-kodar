using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TicketManager.Areas.Identity.Data;
using TicketManager.Data;

namespace TicketManager.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly TicketManagerDbContext _dbContext;
        private readonly DbSet<AppUser> _table;

        public UserRepository(TicketManagerDbContext dbContext)
        {
            _dbContext = dbContext;
            _table = _dbContext.Set<AppUser>();
        }

        public void Add(AppUser user)
        {
            _table.Add(user);
            _dbContext.SaveChanges();
        }

        public IEnumerable<AppUser> GetAll()
        {
            return _table.ToList();
        }

        public AppUser GetById(int id)
        {
            return _table.Find(id);
        }

        public void Create(AppUser user)
        {
            throw new System.NotImplementedException();
        }

        public void Update(AppUser user)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
