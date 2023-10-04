using BusinessObjects.Models;
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

        public List<Song> GetSongs()
        {
            using (var context = new xDbContext())
            {
                return context.Songs.ToList();
            }
        }

        public Song GetSong(int id)
        {
            using (var context = new xDbContext())
            {
                return context.Songs.SingleOrDefault(s => s.Id == id);
            }
        }

    }
}
