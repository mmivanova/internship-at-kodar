using Microsoft.AspNetCore.Identity;
using TicketManager.Data;
using TicketManager.Repositories;
using TicketManager.Repositories.UserRepository;

namespace TicketManager.Services.UserServices
{
    public class UserService : GenericService<AppUser, string>, IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IdentityRole GetUserRole(AppUser user)
        {
            var userRole = _repository.GetUserRole(user);
            return userRole;
        }
    }
}