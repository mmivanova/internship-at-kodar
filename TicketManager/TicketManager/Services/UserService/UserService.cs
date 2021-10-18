using Microsoft.AspNetCore.Identity;
using TicketManager.Data;
using TicketManager.Repositories.UserRepository;

namespace TicketManager.Services.UserService
{
    public class UserService : GenericService<AppUser, string>, IUserService
    {
        public UserService(IUserRepository repository) : base(repository)
        {
        }
    }
}