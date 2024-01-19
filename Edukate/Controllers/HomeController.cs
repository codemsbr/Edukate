using Edukate.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Edukate.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}