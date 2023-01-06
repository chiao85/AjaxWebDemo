using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace prjWebDemo.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return Content("Hello Content", "text/plain", Encoding.UTF8);
        }
        public ActionResult TestAjax()
        {
            return View();
        }
    }
}
