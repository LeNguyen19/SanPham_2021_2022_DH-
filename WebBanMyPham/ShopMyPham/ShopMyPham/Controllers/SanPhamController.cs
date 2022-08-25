using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyPham.Models.Entity;

namespace ShopMyPham.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/
        QL_MyPhamEntities3 db = new QL_MyPhamEntities3();
        public ActionResult ChiTietSanPham(int ma)
        {
            try
            {
                SanPham listSP = db.SanPham.Single(sp => sp.MaSP == ma);
                if (listSP == null)
                {
                    return HttpNotFound();
                }
                return View(listSP);
            }
            catch
            {
                return RedirectToAction("ViewTrangChu", "Home");
            }
        }
        public ActionResult MuaNgay()
        {
            var user = new ThongTin();
            if (Session["User"] != null)
            {
                user = Session["User"] as ThongTin;
            }
            if (user.Ma != 0)
            {
                return RedirectToAction("ViewSanPham", "Home");
            }
            return RedirectToAction("ViewSanPham", "Home");
        }
        public ActionResult ChiTietSanPham1(int ma)
        {
            try
            {
                SanPham listSP = db.SanPham.Single(sp => sp.MaSP == ma);
                if (listSP == null)
                {
                    return HttpNotFound();
                }
                return View(listSP);
            }
            catch
            {
                return RedirectToAction("ViewTrangChu", "Home");
            }
        }
        public ActionResult TimKiem(string ten)
        {
            //return View(db.SanPham.SqlQuery("select * from SanPham where TenSP like '%" + ten + "%'").ToList());
            return View(db.SanPham.Where(sp => sp.TenSP.Contains(ten)).ToList());
        }
        public ActionResult TimKiem1(string ten)
        {
            return View(db.SanPham.SqlQuery("select * from SanPham where TenSP like '%" + ten + "%'").ToList());
        }
    }
}
