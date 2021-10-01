using TicketManager.Data;
using TicketManager.Repositories;

namespace TicketManager.Services.UserServices
{
    public class UserService : GenericService<AppUser, string>, IUserService
    {
        public UserService(IRepository<AppUser, string> repository) : base(repository)
        {
        }
    }
}