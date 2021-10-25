using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketManager.Infrastructure.Areas.Identity.Data;

namespace TicketManager.Infrastructure.Repositories
{
    public class GenericRepository<T, PK> : IRepository<T, PK>
        where T : class
    {
        private readonly TicketManagerDbContext _context;
        private readonly DbSet<T> _table;

        protected GenericRepository(TicketManagerDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        
        public virtual IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public virtual T GetById(PK id)
        {
            return _table.Find(id);
        }

        public virtual void Create(T t)
        {
            _table.Add(t);
            _context.SaveChanges();
        }

        public virtual void Update(PK id)
        {
            var t = GetById(id);
            _table.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(PK id)
        {
            var existing = GetById(id);
            _table.Remove(existing);
            _context.SaveChanges();
        }
    }
}