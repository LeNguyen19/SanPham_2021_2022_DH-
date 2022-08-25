using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyPham.Models.Entity;

namespace ShopMyPham.Areas.Admin.Controllers
{
    public class NhapHangController : Controller
    {
        //
        // GET: /Admin/NhapHang/
        QL_MyPhamEntities3 db = new QL_MyPhamEntities3();
        public ActionResult ShowNhapHang()
        {
            return View(db.NhapHang.ToList());
        }
        public ActionResult ChiTiet(int ma)
        {
            return View(db.ChiTietNhapHang.Where(ct => ct.MaNhapHang == ma).ToList());
        }
    }
}
