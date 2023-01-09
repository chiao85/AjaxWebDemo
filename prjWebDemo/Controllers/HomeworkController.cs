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
       
		public ActionResult city()
		{
			var cityName = _context.Addresses.Select(c => c.City).Distinct();

			return Json(cityName);
		}
		//以城市名稱讀取鄉鎮
		public ActionResult site(string city)
		{
			var site = _context.Addresses.Where(c => c.City == city).Select(s => s.SiteId).Distinct();
			return Json(site);
		}
		//以鄉鎮名稱讀取路名
		public ActionResult road(string site)
		{
			var road = _context.Addresses.Where(s => s.SiteId == site).Select(r => r.Road).Distinct();
			return Json(road);
		}
		public IActionResult List()
		{
			return View();
		}
		public ActionResult signUp()
		{
			return View();
		}
		public ActionResult fetch()
		{
			return View();
		}
	}
}
