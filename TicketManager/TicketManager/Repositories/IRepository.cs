using System.Collections.Generic;

namespace TicketManager.Repositories
{
    public interface IRepository<T, PK>
        where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(PK id);
        void Create(T t);
        void Update(T t);
        void Delete(PK id);
    }
}