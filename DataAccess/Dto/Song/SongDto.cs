using BusinessObjects.Models;
using DataAccess.Dto.Album;
using DataAccess.Dto.PerformsOnSong;
using DataAccess.Dto.PlaylistTracks;
using DataAccess.Dto.SongGenres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto.Song
{
    public class SongDto
    {
        public int Id { get; set; }
        public string FileId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Duration { get; set; } = null!;
        public string? Image { get; set; }
        public string? Image2 { get; set; }
        public int ListenCount { get; set; }
        public int AlbumId { get; set; }
        public AlbumDto Album { get; set; } = null!;
        public List<PerformsOnSongDto> PerformsOnSongs { get; set; } = new List<PerformsOnSongDto>();
/*        public List<PlaylistTrackDto> PlaylistTracks { get; set; } = new List<PlaylistTrackDto>();
        public List<SongGenreDto> SongGenres { get; set; } = new List<SongGenreDto>();*/
    }
}
