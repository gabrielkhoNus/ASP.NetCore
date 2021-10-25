using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Paper2SD.Models
{
    public class Genre
    {
        public Genre()
        {
            Song = new List<Song>();
        }
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Song>Song { get; set; }
    }
}
