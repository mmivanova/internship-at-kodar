using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using TicketManager.Data;
using TicketManager.Repositories.TicketRepository;

namespace TicketManager.Services.TicketServices
{
    public class TicketService : GenericService<Ticket, int>, ITicketService
    {
        private readonly ITicketRepository _repository;

        public TicketService(ITicketRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Ticket> GetTicketsByUser(AppUser user)
        {
            var ticketsByUser = _repository.GetTicketsByUser(user);
            return ticketsByUser;
        }

        public IEnumerable<Ticket> GetTicketsByUserRole(IdentityRole role)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ticket> GetTicketsForUser(AppUser user)
        {
            List<Ticket> tickets;
            
            if (user.Email.Equals("admin@admin.com"))
            {
                tickets = GetAll().ToList();
                return tickets;
            }
            
            tickets = _repository.GetInitialTickets(user).ToList();

            if (user.JobTitleId.Equals(4))
            {
                tickets.AddRange(_repository.GetOfficeManagersTickets());
            }
            else if (user.JobTitleId.Equals(5))
            {
                tickets.AddRange(_repository.GetTechnicalManagersTickets());
            }

            return tickets;
        }

        public override Ticket GetById(int id)
        {
            var ticket = base.GetById(id);
            if (ticket != null) return ticket;
            Console.WriteLine("Ticket is null");
            return null;
        }
    }
}