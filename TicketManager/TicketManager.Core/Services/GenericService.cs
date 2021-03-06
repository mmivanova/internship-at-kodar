using System.Collections.Generic;
using TicketManager.Infrastructure.Repositories;

namespace TicketManager.Core.Services
{
    public class GenericService<T, PK> : IService<T,PK> 
        where T : class
    {
        private readonly IRepository<T, PK> _repository;

        protected GenericService(IRepository<T, PK> repository)
        {
            _repository = repository;
        }
        
        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual T GetById(PK id)
        {
            return _repository.GetById(id);
        }

        public virtual void Create(T t)
        {
            _repository.Create(t);
        }

        public virtual void Update(PK id)
        {
            _repository.Update(id);
        }

        public virtual void Delete(PK id)
        {
            _repository.Delete(id);
        }
    }
}