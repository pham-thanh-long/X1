using DataAccess.Dto.Account;
using DataAccess.Dto.Follow;
using DataAccess.Dto.Playlist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Image { get; set; }
        public int AccountId { get; set; }
        public AccountDto Account { get; set; }
        public List<FollowDto> Follows { get; set; } = new List<FollowDto>();
        public List<PlaylistDto> Playlists { get; set; } = new List<PlaylistDto>();
    }
}
