
using DataAccess;
using DataAccess.Dto.Album;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AlbumRepository : IAlbumRepository
    {
    public AlbumDto GetAlbumByArtistAndId(int artistId, int albumId) => AlbumDAO.Instance.GetAlbumByArtistAndId(artistId, albumId);

    }
}
