using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Paper2SD.Models
{
    public class Song
    {
        public Song ()
        {
            Id = new Guid().ToString();
        }
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public int Mins { get; set; }
        public int Secs { get; set; }
        public virtual string GenreId { get; set; }
        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }
    }
}
