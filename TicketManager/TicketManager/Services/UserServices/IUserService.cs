using Microsoft.AspNetCore.Identity;
using TicketManager.Data;

namespace TicketManager.Services.UserServices
{
    public interface IUserService : IService<AppUser, string>
    {
        IdentityRole GetUserRole(AppUser user);
    }
}