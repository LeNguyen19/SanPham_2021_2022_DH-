using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyPham.Models.Entity;

namespace ShopMyPham.Areas.Admin.Controllers
{
    public class KhachController : Controller
    {
        //
        // GET: /Admin/Khach/
        QL_MyPhamEntities3 db = new QL_MyPhamEntities3();
        public ActionResult ShowKhachHang()
        {
            return View(db.ThongTin.Where(tt => tt.ChucVu == 0).ToList());
        }
        public ActionResult XoaKH(int ma)
        {
            if (db.DonHang.Where(dh => dh.MaKH == ma).Count() != 0)
            {
                return HttpNotFound();
            }
            db.XoaKH(ma);
            return RedirectToAction("ShowKhachHang", "Khach");
        }
        [HttpGet]
        public ActionResult SuaKhachHang(int ma)
        {
            ThongTin tt = db.ThongTin.Single(ttt => ttt.Ma == ma);
            if (tt == null)
            {
                return HttpNotFound();
            }
            return View(tt);
        }
        [HttpPost]
        public ActionResult SuaKhachHang(ThongTin tt)
        {
            if (ModelState.IsValid)
            {
                db.SuaKH(tt.Ma, tt.HoTen, tt.GioTinh, tt.DiaChi, tt.DienThoai, tt.Email, tt.TaiKhoan, tt.MatKhau);
                return RedirectToAction("ShowKhachHang", "Khach");
            }
            return View(tt);
        }
    }
}
