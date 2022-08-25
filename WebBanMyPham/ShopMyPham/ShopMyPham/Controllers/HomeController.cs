using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyPham.Models.Entity;

namespace ShopMyPham.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        QL_MyPhamEntities3 db = new QL_MyPhamEntities3();
        public ActionResult ViewTrangChu()
        {
            var listSP = db.SanPham.Take(12).ToList();
            return View(listSP);
        }
        public ActionResult ViewSanPham()
        {
            var listSP = db.SanPham.ToList();
            return View(listSP);
        }
        public ActionResult ViewGioiThieu()
        {
            return View();
        }

        public ActionResult ViewLienHe()
        {
            return View();
        }

        public ActionResult ViewUuDai()
        {
            return View();
        }
    }
}
