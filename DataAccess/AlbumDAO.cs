using BusinessObjects.Models;
using DataAccess.Dto.Album;
using DataAccess.Dto.Artist;
using DataAccess.Dto.Song;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AlbumDAO
    {
        //Using Singleton Pattern
        private static AlbumDAO instance = null;
        private static readonly object instanceLock = new object();
        private AlbumDAO() { }
        public static AlbumDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new AlbumDAO();
                }
                return instance;
            }
        }

        public AlbumDto GetAlbumByArtistAndId(int artistId, int albumId)
        {
            using (var context = new xDbContext())
            {
                return context.Albums
                    .Where(al => al.Id == albumId && al.ArtistId == artistId)
                    .Select(al => new AlbumDto
                    {
                        Id = al.Id,
                        Title = al.Title,
                        Description = al.Description,
                        ReleaseDate = al.ReleaseDate,
                        Image = al.Image,
                        ArtistId = al.ArtistId,
                        Artist = new ArtistDto
                        {
                            Id = al.Artist.Id,
                            Name = al.Artist.Name,
                        },
                        Songs = al.Songs.Select(song => new SongDto
                        {
                            Id = song.Id,
                            Name = song.Name,
                            Duration = song.Duration,
                            Image = song.Image,
                        }).ToList(),
                    })
                    .SingleOrDefault();
            }
        }




    }
}
