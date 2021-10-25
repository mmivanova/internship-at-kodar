using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketManager.Areas.Identity;
using TicketManager.Infrastructure.Data;
using TicketManager.Infrastructure.Domain.Entities;

[assembly: HostingStartup(typeof(IdentityHostingStartup))]

namespace TicketManager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<TicketManagerDbContext>(options =>
                    SqlServerDbContextOptionsExtensions.UseSqlServer(options,
                        context.Configuration.GetConnectionString("Default")));
                
                services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<TicketManagerDbContext>();
            });
        }
    }
}