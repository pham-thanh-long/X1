using BusinessObjects.Models;
using DataAccess.Dto.Song;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface ISongRepository
    {
        List<SongDto> GetSongs();
        List<SongDto> GetTopSongsByListenCount(int artistId, int count);
        SongDto GetSong(int id);
        Song PlaySong(int songId);
        void AddSong(Song song);
        void EditSong(Song song);
        void DeleteSong(Song song);
    }
}
