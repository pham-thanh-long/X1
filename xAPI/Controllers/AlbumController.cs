using AutoMapper;
using DataAccess.Dto.Album;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace xAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAlbumRepository _albumRepository;


        public AlbumController(IMapper mapper, IAlbumRepository repository)
        {
            _mapper = mapper;
            _albumRepository = repository;
        }

        [HttpGet("{artistId}/{albumId}")]
        public IActionResult GetAlbum(int artistId, int albumId)
        {
            var album = _albumRepository.GetAlbumByArtistAndId(artistId, albumId);

            if (album == null)
            {
                return NotFound();
            }

            var albumDTO = _mapper.Map<AlbumDto>(album);

            return Ok(albumDTO);
        }
    }
}
