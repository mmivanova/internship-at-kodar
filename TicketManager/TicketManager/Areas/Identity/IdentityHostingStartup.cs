﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketManager.Areas.Identity.Data;
using TicketManager.Data;

[assembly: HostingStartup(typeof(TicketManager.Areas.Identity.IdentityHostingStartup))]
namespace TicketManager.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TicketManagerDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("TicketManagerDbContextConnection")));

                // changed AppUser to IdentityUser
                services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<TicketManagerDbContext>();
            });
        }
    }
}