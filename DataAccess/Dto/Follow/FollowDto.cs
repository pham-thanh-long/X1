using DataAccess.Dto.Artist;
using DataAccess.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto.Follow
{
    public class FollowDto
    {
        public int UserId { get; set; }
        public int ArtistId { get; set; }
        public byte[] Timestamp { get; set; }
        public ArtistDto Artist { get; set; }
        public UserDto User { get; set; }
    }
}
