using DataAccess.Dto.Playlist;
using DataAccess.Dto.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto.PlaylistTracks
{
    public class PlaylistTrackDto
    {
        public int TrackNo { get; set; }
        public int PlaylistId { get; set; }
        public int SongId { get; set; }
        public PlaylistDto Playlist { get; set; }
        public SongDto Song { get; set; }
    }
}
