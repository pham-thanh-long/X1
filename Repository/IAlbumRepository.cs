using BusinessObjects.Models;
using DataAccess.Dto.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IAlbumRepository
    {
        AlbumDto GetAlbumByArtistAndId(int artistId, int albumId);
    }
}
