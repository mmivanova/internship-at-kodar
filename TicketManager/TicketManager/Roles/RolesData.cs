using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using TicketManager.Areas.Identity.Data;

namespace TicketManager.Roles
{
    public static class RolesData
    {
        private static readonly string[] Roles = { "Administrator", "Manager", "Developer" };

        public static async Task SeedRoles(IServiceProvider serviceProvider)
        {
            using var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var dbContext = serviceScope.ServiceProvider.GetService<TicketManagerDbContext>();

            if (dbContext != null && !dbContext.UserRoles.Any())
            {
                var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    
                foreach (var role in Roles.Where(r=> r != "Administrator"))
                {
                    if (!await roleManager.RoleExistsAsync(role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
            }
        }
    }
}