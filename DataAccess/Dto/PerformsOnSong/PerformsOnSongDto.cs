using DataAccess.Dto.Artist;
using DataAccess.Dto.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto.PerformsOnSong
{
    public class PerformsOnSongDto
    {
        public int SongId { get; set; }
        public int ArtistId { get; set; }
        public bool IsMainArtist { get; set; }
        public ArtistDto Artist { get; set; }
        public SongDto Song { get; set; }
    }
}
