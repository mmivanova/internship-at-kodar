using System;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketManager.Infrastructure.Domain.Entities;

namespace TicketManager.Infrastructure.Data
{
    public class TicketManagerDbContext : IdentityDbContext<AppUser>
    {
        public TicketManagerDbContext(DbContextOptions<TicketManagerDbContext> options)
            : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Receiver> Receivers { get; set; }
        public DbSet<Comment> Comments { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder
                .Entity<AppUser>()
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

            builder
                .Entity<Receiver>()
                .Property(p => p.Id)
                .HasConversion<int>();

            builder.Entity<Receiver>().HasData(
                Enum.GetValues(typeof(ReceiverId))
                    .Cast<ReceiverId>()
                    .Select(jt => new Receiver()
                    {
                        Id = jt,
                        Title = jt.ToString()
                    })
            );

            builder
                .Entity<Comment>()
                .HasKey(pk => pk.Id);

            builder.Entity<Ticket>()
                .HasMany(t => t.Comments)
                .WithOne();

            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}