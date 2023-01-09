using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Xml.Linq;

namespace prjWebDemo.Controllers
{
    public class HomeworkController : Controller
    {
        private readonly DemoContext _context;
        public HomeworkController(DemoContext context)
        {
            _context = context;
        }
        public ActionResult content(string Name)
        {
            var member = _context.Members.FirstOrDefault(m => m.Name.ToLower() == Name.ToLower());
            if (member != null)
                return Content("此會員名稱已被註冊!", "text/plain", Encoding.UTF8);
            return Content($"註冊成功!歡迎新會員:{Name}", "text/plain", Encoding.UTF8);
        }
        public IActionResult List()
        {
            return View();
        }
        public ActionResult signUp()
        {
            return View();
        }
    }
}
