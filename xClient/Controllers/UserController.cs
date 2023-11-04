using Microsoft.AspNetCore.Mvc;

namespace xClient.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
