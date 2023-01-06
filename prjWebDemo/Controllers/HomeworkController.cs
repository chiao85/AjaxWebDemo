using Microsoft.AspNetCore.Mvc;

namespace prjWebDemo.Controllers
{
    public class HomeworkController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
