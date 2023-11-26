using BusinessObjects.Models;
using DataAccess.Dto.Account;
using DataAccess.Dto.Artist;
using DataAccess.Dto.Follow;
using DataAccess.Dto.Playlist;
using DataAccess.Dto.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserDAO
    {
        //Using Singleton Pattern
        private static UserDAO instance = null;
        private static readonly object instanceLock = new object();
        private UserDAO() { }
        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new UserDAO();
                }
                return instance;
            }
        }


        public UserDto GetUserById(int id)
        {
            using (var context = new xDbContext())
            {
                var user = context.Users.Where(u => u.Id == id)
                    .Include(fl => fl.Follows)
                    .Include(ac => ac.Account)
                    .Select(us => new UserDto
                    {
                        Id = us.Id,
                        Name = us.Name,
                        Account = us.Account != null ? new AccountDto // Thay thế AccountDto bằng tên DTO tương ứng
                        {
                            // Map các thuộc tính của Account vào DTO tương ứng
                            Id = us.Id,
                            Email = us.Account.Email,
                            Password = us.Account.Password
                        } : null,
                        Follows = (List<FollowDto>)us.Follows.Select(us => new FollowDto
                        {
                            ArtistId = us.ArtistId,
                            Artist = us.Artist != null ? new ArtistDto
                            {
                                Id = us.ArtistId,
                                Name = us.Artist.Name,
                                Image = us.Artist.Image
                            } : null,
                            Timestamp = us.Timestamp,
                        }),
                        Country = us.Country,
                        Image = us.Image,
                    });

                return (UserDto)user;
            } 
        }

/*        public UserDto GetPlaylistByUserId(int userId)
        {
            using(var context = new xDbContext())
            {
                
            }
        }*/

    }
}
