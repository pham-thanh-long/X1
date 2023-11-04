using BusinessObjects.Models;
using DataAccess.Dto.Album;
using DataAccess.Dto.Artist;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ArtistDAO
    {
        //Using Singleton Pattern
        private static ArtistDAO instance = null;
        private static readonly object instanceLock = new object();
        private ArtistDAO() { }
        public static ArtistDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new ArtistDAO();
                }
                return instance;
            }
        }


        public ArtistDto GetArtistById(int artistId)
        {
            using(var context = new xDbContext())
            {
            var artist = context.Artists
                .Where(a => a.Id == artistId)
                .Include(al => al.Albums)
                .Include(f => f.Follows)
                .Select(a => new ArtistDto
                {
                    Id = a.Id,
                    Name = a.Name,
                    Country = a.Country,
                    Image = a.Image,
                    FollowTotal = a.Follows.Count,
                    Albums = a.Albums.Select(album => new AlbumDto
                    {
                        Id = album.Id,
                        Title = album.Title,
                        Description = album.Description,
                        ReleaseDate = album.ReleaseDate,
                        Image = album.Image
                    }).ToList()
                })
                .SingleOrDefault();
            return artist;

            }
        }



    }
}
