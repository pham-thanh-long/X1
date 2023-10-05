using BusinessObjects.Models;
using DataAccess.Dto.Album;
using DataAccess.Dto.Artist;
using DataAccess.Dto.PerformsOnSong;
using DataAccess.Dto.PlaylistTracks;
using DataAccess.Dto.Song;
using DataAccess.Dto.SongGenres;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SongDAO
    {
        //Using Singleton Pattern
        private static SongDAO instance = null;
        private static readonly object instanceLock = new object();
        private SongDAO() { }
        public static SongDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                        instance = new SongDAO();
                }
                return instance;
            }
        }

        public List<SongDto> GetSongs()
        {
            using (var context = new xDbContext())
            {
                return context.Songs.Select(song => new SongDto
                {
                    Id = song.Id,
                    FileId = song.FileId,
                    Name = song.Name,
                    Duration = song.Duration,
                    Image = song.Image,
                    Image2 = song.Image2,
                    ListenCount = song.ListenCount,
                    AlbumId = song.AlbumId,
                    Album = new AlbumDto
                    {
                        Id = song.AlbumId,
                        Title = song.Album.Title,

                    },
                    PerformsOnSongs = song.PerformsOnSongs.Select(performer => new PerformsOnSongDto
                    {
                        ArtistId = performer.ArtistId,
                        IsMainArtist = performer.IsMainArtist,
                        Artist = new ArtistDto { Id = performer.Artist.Id, Name = performer.Artist.Name },
                        Song = new SongDto { Id = performer.Song.Id, Name = performer.Song.Name }
                    }).ToList(),
                }).ToList();
            }
        }

        public SongDto GetSong(int id)
        {

            using (var context = new xDbContext())
            {
                var song = context.Songs.FirstOrDefault(s => s.Id == id);
                if (song != null)
                {
                    var songDto = new SongDto
                    {
                        Id = song.Id,
                        FileId = song.FileId,
                        Name = song.Name,
                        Duration = song.Duration,
                        Image = song.Image,
                        Image2 = song.Image2,
                        ListenCount = song.ListenCount,
                        AlbumId = song.Album.Id,
                        Album = new AlbumDto
                        {
                            Id = song.Album.Id,
                            Title = song.Album.Title,
                        },
                        PerformsOnSongs = song.PerformsOnSongs.Select(performer => new PerformsOnSongDto
                        {
                            ArtistId = performer.Artist.Id,
                            IsMainArtist = performer.IsMainArtist,
                            Artist = new ArtistDto { Id = performer.Artist.Id, Name = performer.Artist.Name },
                            Song = new SongDto { Id = performer.Song.Id, Name = performer.Song.Name }
                        }).ToList()
                    };
                    return songDto;
                }
                return null;
            }
        }

        public Song PlaySong(int songId)
        {
            using(var context = new xDbContext())
            {
                return context.Songs.FirstOrDefault(s => s.Id == songId);
            }
        }

        public void AddSong(Song song)
        {
            using (var context = new xDbContext())
            {
                context.Songs.Add(song);
                context.SaveChanges();
            }
        }

        public void EditSong(Song song)
        {
            using (var context = new xDbContext())
            {
                context.Entry<Song>(song).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public void DeleteSong(Song song)
        {
            using (var context = new xDbContext())
            {
                context.Songs.Remove(song);
                context.SaveChanges();
            }
        }
    }
}
