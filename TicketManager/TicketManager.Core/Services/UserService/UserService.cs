using TicketManager.Infrastructure.Domain.Entities;
using TicketManager.Infrastructure.Repositories.UserRepository;

namespace TicketManager.Core.Services.UserService
{
    public class UserService : GenericService<AppUser, string>, IUserService
    {
        private readonly IUserRepository _repository;
        
        public UserService(IUserRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public string GetAppUserNameById(string appUserId)
        {
            return _repository.GetAppUserNameById(appUserId);
        }
    }
}