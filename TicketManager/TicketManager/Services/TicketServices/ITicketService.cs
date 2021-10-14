using System.Collections.Generic;
using System.Drawing;
using Microsoft.AspNetCore.Identity;
using TicketManager.Data;

namespace TicketManager.Services.TicketServices
{
    public interface ITicketService : IService<Ticket, int>
    {
        IEnumerable<Ticket> GetTicketsForUser(AppUser user);
        Image ConvertByteArrayToImage(byte[] byteArray);
        byte[] ConvertImageToByteArray(Image image);
    }
}