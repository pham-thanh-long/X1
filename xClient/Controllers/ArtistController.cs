﻿using Microsoft.AspNetCore.Mvc;

namespace xClient.Controllers
{
    public class ArtistController : Controller
    {
        [Route("/[controller]/Artist-{id}")]
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
