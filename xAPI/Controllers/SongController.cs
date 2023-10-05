using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System.Net.Http;

namespace xAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly ISongRepository repository;

        public SongController(IHttpClientFactory httpClientFactory, ISongRepository repository)
        {
            _httpClient = httpClientFactory.CreateClient();
            this.repository = repository;
        }

        [HttpGet("play-song/{songId}")]
        public async Task<IActionResult> PlaySong(int songId)
        {
            try
            {
                Song song = repository.PlaySong(songId);
                if (song == null)
                {
                    return NotFound();
                }
                var url = $"https://drive.google.com/uc?export=download&id={song.FileId}";
                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();
                return File(stream, "audio/mp3");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
