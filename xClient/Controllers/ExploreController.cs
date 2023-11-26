using Microsoft.AspNetCore.Mvc;

namespace xClient.Controllers
{
    public class ExploreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
