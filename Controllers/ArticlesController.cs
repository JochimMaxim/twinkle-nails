using Microsoft.AspNetCore.Mvc;
using Twinkle_test.Models;

namespace Twinkle_test.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IWebHostEnvironment _env;

        public ArticlesController(IWebHostEnvironment env)
        {
            _env = env;
        }

        // Главная (Hauptseite)
        public IActionResult Index()
        {
            var articles = new List<ArticleModel>
        {
            new ArticleModel { Id = 1, Title = "Die Geschichte der künstlichen Fingernägel", FileName = "article1.html" },
            new ArticleModel { Id = 2, Title = "Künstliche Nägel im Alltag", FileName = "article2.html" },
            new ArticleModel { Id = 3, Title = "Häufige Fehler bei der Nagelpflege", FileName = "article3.html" }
        };

            return View(articles);
        }

        // Просмотр статьи
        public IActionResult Read(int id)
        {
            var article = GetArticles().FirstOrDefault(a => a.Id == id);
            if (article == null) return NotFound();

            var filePath = Path.Combine(_env.WebRootPath, "articles", article.FileName);
            if (!System.IO.File.Exists(filePath)) return NotFound();

            var content = System.IO.File.ReadAllText(filePath);
            ViewData["Title"] = article.Title;
            ViewData["Content"] = content;

            return View("Article");
        }

        private List<ArticleModel> GetArticles()
        {
            return new List<ArticleModel>
        {
            new ArticleModel { Id = 1, Title = "Die Geschichte der künstlichen Fingernägel", FileName = "article1.html" },
            new ArticleModel { Id = 2, Title = "Künstliche Nägel im Alltag", FileName = "article2.html" },
            new ArticleModel { Id = 3, Title = "Häufige Fehler bei der Nagelpflege", FileName = "article3.html" }
        };
        }
    }

}
