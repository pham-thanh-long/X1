using BusinessObjects.Models;
using DataAccess;
using DataAccess.Dto.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SongRepository : ISongRepository
    {
        public void AddSong(Song song) => SongDAO.Instance.AddSong(song);

        public void DeleteSong(Song song) => SongDAO.Instance.DeleteSong(song);

        public void EditSong(Song song) => SongDAO.Instance.EditSong(song); 

        public SongDto GetSong(int id) => SongDAO.Instance.GetSong(id);

        public List<SongDto> GetSongs() => SongDAO.Instance.GetSongs();

        public List<SongDto> GetTopSongsByListenCount(int artistId, int count) => SongDAO.Instance.GetTopSongsByListenCount(artistId, count);

        public Song PlaySong(int songId) => SongDAO.Instance.PlaySong(songId);
    }
}
