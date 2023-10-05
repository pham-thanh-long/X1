using DataAccess.Dto.AlbumGenre;
using DataAccess.Dto.Artist;
using DataAccess.Dto.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto.Album
{
    public class AlbumDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Image { get; set; }
        public int ArtistId { get; set; }
        public ArtistDto Artist { get; set; }
        public List<AlbumGenreDto> AlbumGenres { get; set; } = new List<AlbumGenreDto>();
        public List<SongDto> Songs { get; set; } = new List<SongDto>();
    }
}
