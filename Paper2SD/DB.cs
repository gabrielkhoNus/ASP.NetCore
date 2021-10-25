using Paper2SD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paper2SD
{
    public class DB
    {
        private DBContext dbContext;
        public DB (DBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Seed()
        {
            SeedGenre();
            SeedSong();
        }
        public void SeedGenre()
        {
            dbContext.Add(new Genre
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Pop"
            });
            dbContext.Add(new Genre
            {
                Id = Guid.NewGuid().ToString(),
                Name = "Classical"
            });
            dbContext.SaveChanges();
        }
        public void SeedSong()
        {
            Genre pop = dbContext.Genres.FirstOrDefault(x 
                => x.Name == "Pop");
            Genre classical = dbContext.Genres.FirstOrDefault(x
                  => x.Name == "Classical");
            dbContext.Add(new Song
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Fly Me To The Moon",
                Mins = 5,
                Secs = 42,
                GenreId=pop.Id
            });
            dbContext.Add(new Song {
                Id = Guid.NewGuid().ToString(),
                Title ="Canon in D",
                Mins=5,
                Secs=11,
                GenreId=classical.Id
            });
            dbContext.Add(new Song
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Let It Be",
                Mins = 5,
                Secs = 58,
                GenreId = pop.Id
            });
            dbContext.Add(new Song
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Somewhere Out There",
                Mins = 4,
                Secs = 48,
                GenreId = pop.Id
            });
            dbContext.Add(new Song
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Hallelujah",
                Mins = 4,
                Secs = 15,
                GenreId = classical.Id
            });
            dbContext.SaveChanges();
        }
        
    }
}
