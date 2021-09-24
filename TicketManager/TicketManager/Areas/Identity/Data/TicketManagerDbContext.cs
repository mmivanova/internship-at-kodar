using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace TicketManager.Data
{
    public class TicketManagerDbContext : IdentityDbContext<AppUser>
    {
        public TicketManagerDbContext(DbContextOptions<TicketManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<AppUser>()
                .HasKey(pk => pk.Id);

            builder
                .Entity<Account>()
                .HasKey(pk => pk.Id);

            builder
                .Entity<Ticket>()
                .HasKey(pk => pk.Id);

            builder
                .Entity<JobTitle>()
                .HasKey(pk => pk.Id);

            builder
                .Entity<JobTitle>()
                .Property(p => p.Id)
                .HasConversion<int>();

            builder.Entity<JobTitle>().HasData(
                Enum.GetValues(typeof(JobTitleId))
                         .Cast<JobTitleId>()
                         .Select(jt => new JobTitle()
                         {
                             Id = jt,
                             Name = jt.ToString()
                         })
                );


            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("name=ConnectionStrings:TicketManagerDbContextConnection");
        }

    }
}
