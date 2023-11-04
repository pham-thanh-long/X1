using AutoMapper;
using DataAccess.Dto.Artist;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace xAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository artistRepository;
        private readonly IMapper mapper;

        public ArtistController(IArtistRepository artistRepository, IMapper mapper)
        {
            this.artistRepository = artistRepository;
            this.mapper = mapper;
        }

        [Authorize]
        [HttpGet("{artistId}")]
        public IActionResult GetArtist(int artistId)
        {
            try
            {
                var artist = artistRepository.GetArtistById(artistId);

                if (artist != null)
                {
                    var artistDto = mapper.Map<ArtistDto>(artist);
                    return Ok(artistDto);
                }
                else
                {
                    return NotFound("Artist not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred: " + ex.Message);
            }
        }


    }
}
