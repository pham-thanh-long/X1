using DataAccess.Dto.Album;
using DataAccess.Dto.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto.AlbumGenre
{
    public class AlbumGenreDto
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public string? Description { get; set; }
        public AlbumDto Album { get; set; }
        public GenreDto Genre { get; set; }
    }
}
