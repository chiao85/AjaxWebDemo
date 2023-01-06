using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace prjWebDemo.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                name = "訪客";
            }

            return Content($"Hello ,{name} !", "text/plain", Encoding.UTF8);
        }
        public ActionResult TestAjax()
        {
            return View();
        }
    }
}
