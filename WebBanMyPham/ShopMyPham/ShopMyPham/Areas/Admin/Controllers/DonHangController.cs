using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyPham.Models.Entity;

namespace ShopMyPham.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        //
        // GET: /Admin/DonHang/

        QL_MyPhamEntities3 db = new QL_MyPhamEntities3();
        public ActionResult ShowDonHang()
        {
            return View(db.DonHang.ToList());
        }
        public ActionResult Detail(int ma)
        {
            return View(db.ChiTietDonHang.Where(ct => ct.MaDonHang == ma).ToList());
        }
        public ActionResult DTT(int ma)
        {
            db.UpdateDHDaGiaoHang(ma);
            return RedirectToAction("ShowDonHang", "DonHang");
        }

    }
}
