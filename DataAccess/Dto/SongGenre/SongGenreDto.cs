using DataAccess.Dto.Genre;
using DataAccess.Dto.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto.SongGenres
{
    public class SongGenreDto
    {
        public int SongId { get; set; }
        public int GenreId { get; set; }
        public string? Description { get; set; }
        public GenreDto Genre { get; set; }
        public SongDto Song { get; set; }
    }
}
