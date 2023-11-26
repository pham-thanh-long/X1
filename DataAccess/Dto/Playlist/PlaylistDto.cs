using BusinessObjects.Models;
using DataAccess.Dto.Artist;
using DataAccess.Dto.PlaylistTracks;
using DataAccess.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto.Playlist
{
    public class PlaylistDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int UserId { get; set; }
        public ICollection<PlaylistTrackDto> PlaylistTracks { get; set; } = new List<PlaylistTrackDto>();
        public UserDto User { get; set; } = null!;
    }
}
