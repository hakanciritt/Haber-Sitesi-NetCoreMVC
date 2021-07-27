using Microsoft.AspNetCore.Mvc;
using System;

namespace HaberSitesiASP.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
