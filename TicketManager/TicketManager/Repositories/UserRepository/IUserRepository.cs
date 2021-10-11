using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using TicketManager.Data;

namespace TicketManager.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<AppUser, string>
    {
        IdentityRole GetUserRole(AppUser user);
    }
}