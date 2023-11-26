using AutoMapper;
using BusinessObjects.Models;
using DataAccess.Dto.Album;
using DataAccess.Dto.Artist;
using DataAccess.Dto.Song;
using DataAccess.Dto.Album;


namespace xAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Song, SongDto>().ReverseMap();

            CreateMap<Artist, ArtistDto>().ReverseMap();

            CreateMap<Album, AlbumDto>().ReverseMap();
        }
    }
}
