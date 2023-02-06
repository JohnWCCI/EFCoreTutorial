using EFCoreTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace EFCoreTutorial.Context
{
    public class MusicContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //ToDo Change this to point to the correct server
            var connectionString = @"Data Source=localhost;Initial Catalog=MusicTesting;Integrated Security=True;Encrypt=False";

            
            optionsBuilder.UseSqlServer(connectionString);                          

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
                                 new Artist { Id = 1, FirstName = "Johnny", LastName = "Cash" },
                                 new Artist { Id = 2, FirstName = "Jimmy", LastName = "Buffet" },
                                 new Artist { Id = 3, FirstName = "Home", LastName = "Free" });

            modelBuilder.Entity<Song>().HasData(
                                new Song { Id = 1, Title = "Your Heartless", ArtistId = 1 },
                                new Song { Id = 2, Title = "Ride Bikes", ArtistId = 1 },
                                new Song { Id = 3, Title = "Your Heartless", ArtistId = 1 },
                                new Song { Id = 4, Title = "Wayfaring Stranger", ArtistId = 1 },
                                new Song { Id = 5, Title = "Son of a Sailor", ArtistId = 2 },
                                new Song { Id = 6, Title = "Sea Shanty", ArtistId = 3 },
                                new Song { Id = 7, Title = "Island", ArtistId = 2 });

            modelBuilder.Entity<Genre>().HasData(
                                new Genre { Id = -1, GenreName = "None" },
                                new Genre { Id = 1, GenreName = "Rock and Roll" },
                                new Genre { Id = 2, GenreName = "R&B" },
                                new Genre { Id = 3, GenreName = "Country" });
        }

        public DbSet<Song> Songs { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}
