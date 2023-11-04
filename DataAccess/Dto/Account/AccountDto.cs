using DataAccess.Dto.Artist;
using DataAccess.Dto.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Dto.Account
{
    public class AccountDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<ArtistDto> Artists { get; set; } = new List<ArtistDto>();
        public List<UserDto> Users { get; set; } = new List<UserDto>();
    }
}
