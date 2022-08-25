using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyPham.Models.Entity;
using ShopMyPham.Models.DAO;
using Facebook;
using System.Configuration;

namespace ShopMyPham.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /KhachHang/
        QL_MyPhamEntities3 db = new QL_MyPhamEntities3();
        TaiKhoanDAO tk = new TaiKhoanDAO();
        [HttpGet]
        public ActionResult ViewDangNhap()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ViewDangNhap(string TaiKhoan, string MatKhau)
        {
            if(TaiKhoan == string.Empty && MatKhau == string.Empty)
            {
                ViewBag.BaoLoi = "Tài khoản mật khẩu của bạn trống!";
                return View();
            }
            else if(TaiKhoan == string.Empty && MatKhau != string.Empty)
            {
                ViewBag.BaoLoi = "Tài khoản của bạn trống!";
                return View();
            }
            else if(TaiKhoan != string.Empty && MatKhau == string.Empty)
            {
                ViewBag.BaoLoi = "Mật khẩu của bạn trống!";
                return View();
            }
            else
            {
                var model = tk.login(TaiKhoan, MatKhau);
                if (model != null)
                {
                    if (model.ChucVu == 1)
                    {
                        Session["UserAdmin"] = model;
                        return RedirectToAction("ThongKe", "Admin");
                    }
                    else
                    {
                        Session["User"] = model;
                        var model1 = tk.DH(model.Ma, DateTime.Now);
                        Session["DH"] = model1;
                        return RedirectToAction("TrangChuUser", "User");
                    }
                }
                else
                {
                    ViewBag.BaoLoi = "Tài khoản mật khẩu của bạn không chính xác!";
                    return View();
                }
            }
        }
        [HttpGet]
        public ActionResult ViewDangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ViewDangKy(ThongTin tt)
        {
            if (ModelState.IsValid)
            {
                if (db.ThongTin.Where(t => t.TaiKhoan == tt.TaiKhoan).Count() != 0)
                {
                    ViewBag.LoiDangKy = "Đăng ký thất bại!";
                    return View();
                }
                tt.ChucVu = 0;
                db.ThongTin.Add(tt);
                db.SaveChanges();
                return RedirectToAction("ViewDangNhap", "KhachHang");
            }
            return View();
        }
        public ActionResult HoSo(int ma)
        {
            var user = new ThongTin();
            if (Session["User"] != null)
            {
                user = Session["User"] as ThongTin;
            }
            if(user.Ma == 0)
            {
                return RedirectToAction("ViewDangNhap", "KhachHang");
            }
            var hoSoKH = db.ThongTin.Single(hs => hs.Ma == ma);
            return View(hoSoKH);
        }
        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("ViewDangNhap", "KhachHang");
        }
        [HttpGet]
        public ActionResult SuaKH(int ma)
        {
            ThongTin tt = db.ThongTin.Single(ttt => ttt.Ma == ma);
            if (tt == null)
            {
                return HttpNotFound();
            }
            return View(tt);
        }
        [HttpPost]
        public ActionResult SuaKH(ThongTin tt)
        {
            if (ModelState.IsValid)
            {
                db.SuaKH(tt.Ma, tt.HoTen, tt.GioTinh, tt.DiaChi, tt.DienThoai, tt.Email, tt.TaiKhoan, tt.MatKhau);
                return RedirectToAction("TrangChuUser", "User");
            }
            return View(tt);
        }


    }
}
