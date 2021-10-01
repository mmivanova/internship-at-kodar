using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TicketManager.Areas.Identity.Data;

namespace TicketManager.Repositories
{
    public class GenericRepository<T, PK> : IRepository<T, PK>
        where T : class
    {
        private readonly TicketManagerDbContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(TicketManagerDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        
        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(PK id)
        {
            return _table.Find(id);
        }

        public void Create(T t)
        {
            _table.Add(t);
            _context.SaveChanges();
        }

        public void Update(PK id)
        {
            var t = GetById(id);
            _table.Attach(t);
            _context.Entry(t).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(PK id)
        {
            var existing = GetById(id);
            _table.Remove(existing);
            _context.SaveChanges();
        }
    }
}