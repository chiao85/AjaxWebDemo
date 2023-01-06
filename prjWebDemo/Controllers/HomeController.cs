using Microsoft.AspNetCore.Mvc;
using prjWebDemo.Models;
using System.Diagnostics;

namespace prjWebDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly dbDemoContext _context;

        public HomeController(ILogger<HomeController> logger, dbDemoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult Member()
        {
            return View(_context.TPatients);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}