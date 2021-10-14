using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using TicketManager.Data;
using TicketManager.Repositories.TicketRepository;
using static System.Drawing.Image;

namespace TicketManager.Services.TicketServices
{
    public class TicketService : GenericService<Ticket, int>, ITicketService
    {
        private readonly ITicketRepository _repository;

        public TicketService(ITicketRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IEnumerable<Ticket> GetTicketsForUser(AppUser user)
        {
            List<Ticket> tickets;
            
            if (user.Email.Equals("admin@admin.com"))
            {
                tickets = GetAll().ToList();
                return tickets;
            }

            tickets = user.JobTitleId switch
            {
                JobTitleId.OfficeManager => _repository.GetManagersTickets(4).ToList(),
                JobTitleId.TechnicalManager => _repository.GetManagersTickets(5).ToList(),
                _ => _repository.GetDevelopersTickets(user).ToList()
            };

            return tickets;
        }

        public Image ConvertByteArrayToImage(byte[] byteArray)
        {
            using var ms = new MemoryStream(byteArray);
            var returnImage = new ImageConverter().ConvertFrom(byteArray) as Image;
            return returnImage;
        }
        
        public byte[] ConvertImageToByteArray(Image image)
        {
            using var ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            return ms.ToArray();
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