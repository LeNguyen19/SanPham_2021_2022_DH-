using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrueLife.Models.KetNoiLinq;
using ShopTrueLife.Models.POJO;
using ShopTrueLife.Models.DAO;
using Microsoft.VisualBasic;

namespace ShopTrueLife.Controllers
{
    public class KhachHangController : Controller
    {
        //
        // GET: /KhachHang/
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();
        ShopTrueLife.Models.DAO.TaiKhoan tk = new ShopTrueLife.Models.DAO.TaiKhoan();

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(string TaiKhoan, string MatKhau)
        {
            var model1 = tk.loginKhachHang(TaiKhoan, MatKhau);
            var model2 = tk.loginNhanVien(TaiKhoan, MatKhau);
            if (model1 != null)
            {
                Session["User"] = model1;
                return RedirectToAction("UserTrangChu", "User");
            }
            else if (model2 != null)
            {
                Session["UserAdmin"] = model2;
                return RedirectToAction("ThongKe", "Admin");
            }
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(string HoTen, string GioiTinh, string DiaChi, string Email, string SoDienThoai, string TenDangNhap, string MatKhau, string NhapLaiMatKhau)
        {
            try
            {
                var tk = db.BangTamTaiKhoans.Where(t => t.TenDangNhap.CompareTo(TenDangNhap) == 0).SingleOrDefault();
                if(tk == null)
                {
                    if(MatKhau.CompareTo(NhapLaiMatKhau)==0)
                    {
                        BangTamTaiKhoan tk1 = new BangTamTaiKhoan();
                        tk1.TenDangNhap = TenDangNhap;
                        tk1.MatKhau = MatKhau;

                        db.BangTamTaiKhoans.InsertOnSubmit(tk1);

                        KhachHang kh = new KhachHang();
                        kh.HoTen_KH = HoTen;
                        kh.GioiTinh = GioiTinh;
                        kh.DiaChi = DiaChi;
                        kh.Email = Email;
                        kh.TenDangNhap = TenDangNhap;
                        kh.MatKhau = MatKhau;
                        db.KhachHangs.InsertOnSubmit(kh);

                        var itemKH = db.KhachHangs.Where(itkh => itkh.Email.CompareTo(Email) == 0).SingleOrDefault();
                        DienThoai_KhachHang dtkh = new DienThoai_KhachHang();
                        dtkh.SoDienThoai = SoDienThoai;
                        dtkh.ID_KhachHang = itemKH.ID_KhachHang;
                        db.DienThoai_KhachHangs.InsertOnSubmit(dtkh);

                        db.SubmitChanges();
                        return RedirectToAction("DangNhap", "KhachHang");
                    }
                    else
                    {
                        ViewBag.LoiDangKy = "Đăng ký thất bại! Mật khẩu và nhập lại mật khẩu không trùng khớp.";
                    }
                }
                else
                {
                    ViewBag.LoiDangKy = "Đăng ký thất bại! Lỗi trùng tên đăng nhập";
                }
            }
            catch(Exception)
            {
                ViewBag.LoiDangKy = "Đăng ký thất bại!";
            }
            return View();
        }
        public ActionResult HoSo(int id_KhachHang)
        {
            var user = new KhachHang();
            if (Session["User"] != null)
            {
                user = Session["User"] as KhachHang;
            }
            //Nếu chưa có thông tin của Khách Hàng thì đến trang đăng nhập cho Khách Hàng đăng nhập
            if (user == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            var hoSoKH = db.KhachHangs.Single(hs => hs.ID_KhachHang == id_KhachHang);
            return View(hoSoKH);
        }
        
    }
}
