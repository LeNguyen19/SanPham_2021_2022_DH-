using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyPham.Models.Entity;

namespace ShopMyPham.Areas.Admin.Controllers
{
    public class NhanVienController : Controller
    {
        //
        // GET: /Admin/NhanVien/
        QL_MyPhamEntities3 db = new QL_MyPhamEntities3();
        public ActionResult ShowNhanVien()
        {
            return View(db.ThongTin.Where(tt => tt.ChucVu == 1).ToList());
        }
        [HttpGet]
        public ActionResult ThemNV()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemNV(ThongTin tt)
        {
            if (ModelState.IsValid)
            {
                db.ThemNV(tt.HoTen, tt.GioTinh, tt.DiaChi, tt.DienThoai, tt.Email, tt.TaiKhoan, tt.MatKhau);
                return RedirectToAction("ShowNhanVien", "NhanVien");
            }
            return View(tt);
        }
        public ActionResult XoaNV(int ma)
        {
            db.XoaKH(ma);
            return RedirectToAction("ShowNhanVien", "NhanVien");
        }
        [HttpGet]
        public ActionResult SuaNV(int ma)
        {
            ThongTin tt = db.ThongTin.Single(ttt => ttt.Ma == ma);
            if (tt == null)
            {
                return HttpNotFound();
            }
            return View(tt);
        }
        [HttpPost]
        public ActionResult SuaNV(ThongTin tt)
        {
            if (ModelState.IsValid)
            {
                db.SuaNV(tt.Ma, tt.HoTen, tt.GioTinh, tt.DiaChi, tt.DienThoai, tt.Email, tt.TaiKhoan, tt.MatKhau);
                return RedirectToAction("ShowNhanVien", "NhanVien");
            }
            return View(tt);
        }
    }
}
