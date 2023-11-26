using DataAccess.Dto.Account;
using DataAccess.Dto.Album;
using DataAccess.Dto.Follow;
using DataAccess.Dto.PerformsOnSong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto.Artist
{
    public class ArtistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Country { get; set; }
        public string? Image { get; set; }
        public int AccountId { get; set; }
        public int FollowTotal { get; set; }
        public AccountDto Account { get; set; }
        public List<AlbumDto> Albums { get; set; } = new List<AlbumDto>();
        public List<FollowDto> Follows { get; set; } = new List<FollowDto>();
        public List<PerformsOnSongDto> PerformsOnSongs { get; set; } = new List<PerformsOnSongDto>();
    }
}
