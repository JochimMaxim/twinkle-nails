using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Twinkle_test.Models;
using System.IO;

namespace Twinkle_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            var path1 = Path.Combine(_env.WebRootPath, "articles", "article1.html");
            var path2 = Path.Combine(_env.WebRootPath, "articles", "article2.html");
            var path3 = Path.Combine(_env.WebRootPath, "articles", "article3.html");
            var path4 = Path.Combine(_env.WebRootPath, "articles", "article4.html");

            var model = new List<string>
            {
                System.IO.File.ReadAllText(path1),
                System.IO.File.ReadAllText(path2),
                System.IO.File.ReadAllText(path3),
                System.IO.File.ReadAllText(path4)
            };

            return View(model);
        }

        public IActionResult UberUns()
        {
            return View();
        }

        public IActionResult Kontakt()
        {
            return View();
        }

        public IActionResult Preisliste()
        {
            return View();
        }

        public IActionResult Galerie()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

