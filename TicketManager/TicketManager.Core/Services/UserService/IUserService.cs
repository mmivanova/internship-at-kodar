using TicketManager.Infrastructure.Domain.Entities;

namespace TicketManager.Core.Services.UserService
{
    public interface IUserService : IService<AppUser, string>
    {
        string GetAppUserNameById(string appUserId);
    }
}