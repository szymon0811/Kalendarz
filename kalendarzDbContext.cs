using Kalendarz.Models;
using Microsoft.EntityFrameworkCore;


namespace Kalendarz
{
    public class kalendarzDbContext : DbContext
    {
        public kalendarzDbContext(DbContextOptions<kalendarzDbContext> options) : base(options) 
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> eventTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventType>().HasData(
                new EventType { Id = 1, Name = "Urodziny" },
                new EventType { Id = 2, Name = "Spotkanie" },
                new EventType { Id = 3, Name = "Praca" },
                new EventType { Id = 4, Name = "Dom" },
                new EventType { Id = 5, Name = "Inne" }
                );
        }
    }
}
