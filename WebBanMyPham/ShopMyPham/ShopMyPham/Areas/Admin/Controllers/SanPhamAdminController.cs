using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyPham.Models.Entity;

namespace ShopMyPham.Areas.Admin.Controllers
{
    public class SanPhamAdminController : Controller
    {
        //
        // GET: /Admin/SanPhamAdmin/

        QL_MyPhamEntities3 db = new QL_MyPhamEntities3();
        public ActionResult SanPhamAdmin()
        {
            return View(db.SanPham.ToList());
        }
        [HttpGet]
        public ActionResult SuaSP(int ma)
        {
            SanPham sp = db.SanPham.Single(sppp => sppp.MaSP == ma);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        [HttpPost]
        public ActionResult SuaSP(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                db.SuaSanPham(sp.MaSP, sp.TenSP, sp.GiaBan, sp.MoTa, sp.AnhBia, sp.SoLuongTon, sp.MaNCC, sp.MaLoaiSP);
                return RedirectToAction("SanPhamAdmin", "SanPhamAdmin");
            }
            return View(sp);
        }
        [HttpGet]
        public ActionResult ThemSP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemSP(SanPham sp)
        {
            if (ModelState.IsValid)
            {
                var user = new ThongTin();
                if (Session["UserAdmin"] != null)
                {
                    user = Session["UserAdmin"] as ThongTin;
                }
                int countNH = db.NhapHang.Where(dh => dh.MaNV == user.Ma && dh.NgayNhap.Day == DateTime.Now.Day && dh.NgayNhap.Month == DateTime.Now.Month && dh.NgayNhap.Year == DateTime.Now.Year).Count();

                if (countNH==0)
                {
                    db.ThemSanPham(sp.TenSP, sp.GiaBan, sp.MoTa, sp.AnhBia, sp.SoLuongTon, sp.MaNCC, sp.MaLoaiSP);
                    db.ThemNhapHang(DateTime.Now, sp.MaNCC, user.Ma); 
                    NhapHang dhh = db.NhapHang.Single(dh => dh.MaNV == user.Ma && dh.NgayNhap.Day == DateTime.Now.Day && dh.NgayNhap.Month == DateTime.Now.Month && dh.NgayNhap.Year == DateTime.Now.Year);

                    SanPham sp1 = db.SanPham.Single(spp => spp.TenSP == sp.TenSP && spp.MaNCC == sp.MaNCC && spp.MaLoaiSP == sp.MaLoaiSP);
                    db.ThemChiTietNhapHang(dhh.MaNhapHang, sp1.MaSP, sp.SoLuongTon, sp.GiaBan);
                }
                else
                {
                    db.ThemSanPham(sp.TenSP, sp.GiaBan, sp.MoTa, sp.AnhBia, sp.SoLuongTon, sp.MaNCC, sp.MaLoaiSP);
                    NhapHang dhh = db.NhapHang.Single(dh => dh.MaNV == user.Ma && dh.NgayNhap.Day == DateTime.Now.Day && dh.NgayNhap.Month == DateTime.Now.Month && dh.NgayNhap.Year == DateTime.Now.Year);
                    SanPham sp1 = db.SanPham.Single(spp => spp.TenSP == sp.TenSP && spp.MaNCC == sp.MaNCC && spp.MaLoaiSP == sp.MaLoaiSP);

                    db.ThemChiTietNhapHang(dhh.MaNhapHang, sp1.MaSP, sp.SoLuongTon, sp.GiaBan);
                }
                return RedirectToAction("ThemSP", "SanPhamAdmin");
            }
            return View(sp);
        }
    }
}
