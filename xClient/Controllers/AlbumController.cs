using Microsoft.AspNetCore.Mvc;

namespace xClient.Controllers
{
    public class AlbumController : Controller
    {

        [Route("/Artist-{artistId}/Album-{albumId}")]
        public IActionResult Index(int artistId, int albumId)
        {
            ViewBag.ArtistId = artistId;
            ViewBag.AlbumId = albumId;
            return View();
        }
    }
}
