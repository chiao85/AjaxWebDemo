﻿using Microsoft.AspNetCore.Mvc;
using prjWebDemo.Models;
using System.Text;

namespace prjWebDemo.Controllers
{
    public class TestController : Controller
    {
        private readonly DemoContext _context;
        private readonly IWebHostEnvironment _host;
        public TestController(DemoContext context,IWebHostEnvironment host)
        {
            _context = context;
            _host = host;
        }

        public IActionResult Index(string name,string email,string address="taipei")
        {
            if(string.IsNullOrEmpty(name))
            {
                name = "訪客";
            }
            if (string.IsNullOrEmpty(email))
                email = "未輸入信箱";

            return Content($"Hello ,{name} !你的信箱為:{email},你的居住地在:{address}", "text/plain", Encoding.UTF8);
        }
        public IActionResult useMember(Member member,IFormFile file)
        {
            //檔案名稱
            string fileName = file.FileName;
            //檔案實際路徑
            string uploadFile = Path.Combine(_host.WebRootPath, "upload", fileName);
            //儲存圖片至upload資料夾
            using (var fileStream = new FileStream(uploadFile,FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            //將檔案名稱加進資料庫
            member.FileName = fileName;
            //圖片轉成二進位
            byte[]? imgByte = null;
            using (var memory = new MemoryStream())
            {
                file.CopyTo(memory);
                imgByte = memory.ToArray();
            }
            member.FileData = imgByte;
            //儲存進資料庫
            _context.Add(member);
            _context.SaveChanges();

                return Content($"{uploadFile}");
            //return Content($"Hello ,{member.Name} !你的信箱為:{member.Email},你的年齡為:{member.Age}", "text/plain", Encoding.UTF8);
        }
        public ActionResult TestAjax()
        {
            return View();
        }
        public ActionResult PostAjax()
        {
            return View();
        }
    }
}
