using DataAccess.Dto.AlbumGenre;
using DataAccess.Dto.SongGenres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto.Genre
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<AlbumGenreDto> AlbumGenres { get; set; } = new List<AlbumGenreDto>();
        public List<SongGenreDto> SongGenres { get; set; } = new List<SongGenreDto>();
    }
}
