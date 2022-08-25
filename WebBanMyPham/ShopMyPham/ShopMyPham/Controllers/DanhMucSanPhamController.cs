using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyPham.Models.Entity;

namespace ShopMyPham.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        //
        // GET: /DanhMucSanPham/
        QL_MyPhamEntities3 db = new QL_MyPhamEntities3();
        public ActionResult DanhMucSP()
        {
            var listDMSP = db.LoaiSanPham.OrderBy(cd => cd.TenLoaiSP).ToList();
            return View(listDMSP);
        }
        public ActionResult SanPhamTheoLoai(int ma)
        {
            var spTheoMa = db.SanPham.Where(sp => sp.MaLoaiSP == ma).OrderBy(sp => sp.GiaBan).ToList();
            if (spTheoMa.Count == 0)
            {
                ViewBag.SanPham = "Không có sản phẩm nào thuộc danh mục này !";
            }
            return View(spTheoMa);
        }
        public ActionResult DanhMucSP1()
        {
            var listDMSP = db.LoaiSanPham.OrderBy(cd => cd.TenLoaiSP).ToList();
            return View(listDMSP);
        }
        public ActionResult SanPhamTheoLoai1(int ma)
        {
            var spTheoMa = db.SanPham.Where(sp => sp.MaLoaiSP == ma).OrderBy(sp => sp.GiaBan).ToList();
            if (spTheoMa.Count == 0)
            {
                ViewBag.SanPham = "Không có sản phẩm nào thuộc danh mục này !";
            }
            return View(spTheoMa);
        }
    }
}
