using Microsoft.AspNetCore.Mvc;
using Paper2SD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paper2SD.Controllers
{
    public class SearchController : Controller
    {
        private DBContext dbContext;
        public SearchController(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Duration()
        {
            List<Song> songs = new List<Song>();
            List<Genre> genre = new List<Genre>();
            
            songs = dbContext.Songs.Where(x => x.Id != null).OrderByDescending(x => x.Mins).ToList();
            foreach (Song song in songs)
            {
                genre.Add(dbContext.Genres.FirstOrDefault(x => x.Id == song.GenreId));
            }
            
            ViewData["genre"] = genre;
            ViewData["songs"] = songs;
            return View();
        }

        [HttpPost]
        public IActionResult Duration(string mins, string secs)
        {
            List<Song> songs = new List<Song>();
            List<Genre> genre = new List<Genre>();

            int min = int.Parse(mins);
            int sec = int.Parse(secs);
            songs = dbContext.Songs.Where(x => x.Mins >= min
                && x.Secs >= sec).OrderByDescending(x => x.Mins).ThenByDescending(x => x.Secs).ToList();
            foreach (Song song in songs)
            {
                genre.Add(dbContext.Genres.FirstOrDefault(x => x.Id == song.GenreId));
            }
           
            ViewData["genre"] = genre;
            ViewData["songs"] = songs;
            return View();
        }
    }
}
