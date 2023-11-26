using DataAccess.Dto.Artist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IArtistRepository
    {
        ArtistDto GetArtistById(int artistId);
    }
}
