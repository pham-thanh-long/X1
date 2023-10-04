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
    }
}
