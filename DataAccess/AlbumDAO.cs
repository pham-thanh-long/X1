﻿using System;
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
    }
}
