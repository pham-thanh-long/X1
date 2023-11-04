using DataAccess;
using DataAccess.Dto.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ArtistRepository : IArtistRepository
    {
        public ArtistDto GetArtistById(int artistId) => ArtistDAO.Instance.GetArtistById(artistId);
    }
}
