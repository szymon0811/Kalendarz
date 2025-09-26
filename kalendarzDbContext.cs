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
        public DbSet<Tor> Tory { get; set; }
        public DbSet<Kierowca> Kierowcy { get; set; }
        public DbSet<Zestawienie> Zestawienia { get; set; }
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
            modelBuilder.Entity<Kierowca>().HasData(
                new Kierowca { Id = 1, Imie = "Valterri", Nazwisko = "Botas"},
                new Kierowca { Id = 2, Imie = "Esteban", Nazwisko = "Okon" },
                new Kierowca { Id = 3, Imie = "Sebastian", Nazwisko = "Vetel" },
                new Kierowca { Id = 4, Imie = "Robert", Nazwisko = "Kubica" });
            modelBuilder.Entity<Tor>().HasData(
                new Tor { Id = 1, Nazwa = "Moroco Grand Prix"},
                new Tor { Id = 2, Nazwa = "Paris Grand Prix" },
                new Tor { Id = 3, Nazwa = "Sydney Grand Prix" });
        }
    }
}
