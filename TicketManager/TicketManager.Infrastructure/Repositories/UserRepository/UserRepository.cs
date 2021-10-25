using Microsoft.AspNetCore.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketManager.Infrastructure.Domain.Entities;
using TicketManager.Infrastructure.Data;

namespace TicketManager.Infrastructure.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<AppUser, string>, IUserRepository
    {
        private readonly TicketManagerDbContext _context;
        public UserRepository(TicketManagerDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public string GetAppUserNameById(string appUserId)
        {
            var name = _context
                .AppUsers
                .Where(u => u.Id.Equals(appUserId))
                .Select(user => $"{user.FirstName} {user.LastName}")
                .FirstOrDefault();

            return name;
        }
    }
}