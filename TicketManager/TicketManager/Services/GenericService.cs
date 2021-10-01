using System.Collections.Generic;
using TicketManager.Repositories;

namespace TicketManager.Services
{
    public class GenericService<T, PK> : IService<T,PK> 
        where T : class
    {
        private readonly IRepository<T, PK> _repository;

        protected GenericService(IRepository<T, PK> repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public T GetById(PK id)
        {
            return _repository.GetById(id);
        }

        public void Create(T t)
        {
            _repository.Create(t);
        }

        public void Update(PK id)
        {
            _repository.Update(id);
        }

        public void Delete(PK id)
        {
            _repository.Delete(id);
        }
    }
}