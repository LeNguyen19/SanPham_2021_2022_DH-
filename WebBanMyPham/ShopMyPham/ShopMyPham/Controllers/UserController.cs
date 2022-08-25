using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyPham.Models.Entity;
using System.Web.Helpers;
using ShopMyPham.Models.Entity;
using ShopMyPham.Models.POJO;
using ShopMyPham.Models.ChatMail;

namespace ShopMyPham.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        QL_MyPhamEntities3 db = new QL_MyPhamEntities3();
        public ActionResult TrangChuUser()
        {
            var listSP = db.SanPham.Take(12).ToList();
            return View(listSP);
        }

        public ActionResult SanPhamUser()
        {
            var listSP = db.SanPham.ToList();
            return View(listSP);
        }

        public ActionResult GioiThieuUser()
        {
            return View();
        }
        [HttpGet]
        public ActionResult LienHeUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LienHeUser(string body)
        {
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/ChatMail/newPhanHoi.html"));
            content = content.Replace("{{Noidung}}", body);
            new comon().SendMail("soiconguoiyeu123@gmail.com", "Phản hồi từ khách hàng", content);
            ViewBag.msg = "Gửi mail thành công!";
            return View();
        }
        
        
        public ActionResult UuDaiUser()
        {
            return View();
        }
    }
}
