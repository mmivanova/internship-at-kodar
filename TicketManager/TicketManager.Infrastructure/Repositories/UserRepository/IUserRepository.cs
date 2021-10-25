using Microsoft.AspNetCore.Identity;
using TicketManager.Infrastructure.Domain.Entities;

namespace TicketManager.Infrastructure.Repositories.UserRepository
{
    public interface IUserRepository : IRepository<AppUser, string>
    {
        string GetAppUserNameById(string appUserId);
    }
}