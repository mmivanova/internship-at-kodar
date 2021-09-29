using System.Collections.Generic;
using TicketManager.Data;
using TicketManager.Repositories.TicketRepository;

namespace TicketManager.Services.TicketServices
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;

        public TicketService(ITicketRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<Ticket> GetAll()
        {
            return _repository.GetAll();
        }

        public Ticket GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Create(Ticket ticket)
        {
            _repository.Create(ticket);
        }

        public void Update(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}