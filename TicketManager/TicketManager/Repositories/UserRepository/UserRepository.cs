using System.Linq;
using Microsoft.AspNetCore.Identity;
using TicketManager.Areas.Identity.Data;
using TicketManager.Data;

namespace TicketManager.Repositories.UserRepository
{
    public class UserRepository : GenericRepository<AppUser, string>, IUserRepository
    {
        private readonly TicketManagerDbContext _context;
        public UserRepository(TicketManagerDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public IdentityRole GetUserRole(AppUser user)
        {
            var userRole = _context.AppUsers
                .Join(
                    _context.UserRoles,
                    appUser => appUser.Id,
                    role => role.UserId,
                    (userResult, role) => new
                    {
                        UserId = userResult.Id,
                        role.RoleId,
                    }
                )
                .Join(
                    _context.Roles,
                    userRole => userRole.RoleId,
                    role => role.Id,
                    (userRole, role) => new IdentityRole()
                    {
                        Id = role.Id,
                        Name = role.Name,
                        NormalizedName = role.NormalizedName,
                        ConcurrencyStamp = role.ConcurrencyStamp
                    }
                ).FirstOrDefault();

            return userRole;
        }
    }
}