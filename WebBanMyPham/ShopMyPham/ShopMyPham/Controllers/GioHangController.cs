using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopMyPham.Models.Entity;
using ShopMyPham.Models.POJO;
using ShopMyPham.Models.DAO;
using ShopMyPham.Models.ChatMail;

namespace ShopMyPham.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        QL_MyPhamEntities3 db = new QL_MyPhamEntities3();
        TaiKhoanDAO tk = new TaiKhoanDAO();
        //phương thức lấy giỏ hàng
        public List<GioHang> LayGioHang()
        {
            List<GioHang> lstGH = Session["GioHang"] as List<GioHang>;
            if (lstGH == null)
            {
                lstGH = new List<GioHang>();
                Session["GioHang"] = lstGH;
            }
            return lstGH;
        }
        //xây dựng phương thức thêm vào giỏ hàng
        public ActionResult ThemGioHang(int ma)
        {
            List<GioHang> lstGH = LayGioHang();
            GioHang SanPham = lstGH.Find(sp => sp.iMaSP == ma);
            if (SanPham == null)
            {
                SanPham = new GioHang(ma);
                lstGH.Add(SanPham);
                return RedirectToAction("SanPhamUser", "User");
            }
            else
            {
                SanPham.iSoLuong++;
                return RedirectToAction("SanPhamUser", "User");
            }
        }
        //phương thức tính tổng số lượng
        private int TongSoLuong()
        {
            int tsl = 0;
            List<GioHang> lstGH = Session["GioHang"] as List<GioHang>;
            if (lstGH != null)
            {
                tsl = lstGH.Sum(sp => sp.iSoLuong);
            }
            return tsl;
        }
        //tính tổng thành tiền
        public double TongThanhTien()
        {
            double ttt = 0;
            List<GioHang> lstGH = Session["GioHang"] as List<GioHang>;
            if (lstGH != null)
            {
                ttt += lstGH.Sum(sp => sp.dThanhTien);
            }
            return ttt;
        }
        //xây dựng trang giỏ hàng
        public ActionResult GioHang()
        {
            var user = new ThongTin();
            if (Session["User"] != null)
            {
                user = Session["User"] as ThongTin;
            }
            //if(user.Ma ==0)
            //{
            //    return RedirectToAction("ViewSanPham", "SanPham");
            //}
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("SanPhamUser", "User");
            }
            List<GioHang> lisGH = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongThanhTien = TongThanhTien();
            return View(lisGH);
        }
        public ActionResult XoaGioHang(int MaSP)
        {
            List<GioHang> lstGH = LayGioHang();
            GioHang sp = lstGH.Single(s => s.iMaSP == MaSP);

            if (sp != null)
            {
                lstGH.RemoveAll(s => s.iMaSP == MaSP);
                return RedirectToAction("GioHang", "GioHang");
            }
            if (lstGH.Count == 0)
            {
                return RedirectToAction("SanPhamUser", "User");
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult XoaGioHang_All()
        {
            List<GioHang> lstGH = LayGioHang();
            if (lstGH != null)
            {
                lstGH.Clear();
                return RedirectToAction("SanPhamUser", "User");
            }
            if (lstGH.Count == 0)
            {
                return RedirectToAction("SanPhamUser", "User");
            }
            return RedirectToAction("SanPhamUser", "User");
        }
        public ActionResult CapNhatGioHang(int MaSP, FormCollection f)
        {
            List<GioHang> lstGH = LayGioHang();
            GioHang sp = lstGH.Single(s => s.iMaSP == MaSP);
            if (sp != null)
            {
                sp.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        public ActionResult DatHang()
        {
            List<GioHang> lstGH = LayGioHang();
            var user = new ThongTin();
            if (Session["User"] != null)
            {
                user = Session["User"] as ThongTin;
            }
            int countDH = db.DonHang.Where(dh => dh.MaKH == user.Ma && dh.NgayDat.Day == DateTime.Now.Day && dh.NgayDat.Month == DateTime.Now.Month && dh.NgayDat.Year == DateTime.Now.Year).Count();
            if(countDH == 0)
            {
                db.ThemDonHang(DateTime.Now,user.Ma);
                DonHang dhh = db.DonHang.Single(dh => dh.MaKH == user.Ma && dh.NgayDat.Day == DateTime.Now.Day && dh.NgayDat.Month == DateTime.Now.Month && dh.NgayDat.Year == DateTime.Now.Year);
                foreach(GioHang item in lstGH)
                {
                    db.ThemChiTietDonHang(dhh.MaDonHang, item.iMaSP, item.iSoLuong, item.dDonGia);
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/ChatMail/newMail.html"));

                content = content.Replace("{{CustomerName}}", user.HoTen);
                content = content.Replace("{{Phone}}", user.DienThoai);
                content = content.Replace("{{Email}}", user.Email);
                content = content.Replace("{{Address}}", user.DiaChi);
                content = content.Replace("{{Total}}", TongThanhTien().ToString("N0"));

                new comon().SendMail(user.Email, "Đơn hàng mới từ T&L Shop", content);
                return RedirectToAction("XoaGioHang_All", "GioHang");
            }
            else
            {
                DonHang dhh = db.DonHang.Single(dh => dh.MaKH == user.Ma && dh.NgayDat.Day == DateTime.Now.Day && dh.NgayDat.Month == DateTime.Now.Month && dh.NgayDat.Year == DateTime.Now.Year);
                foreach (GioHang item in lstGH)
                {
                    int countCTDH = db.ChiTietDonHang.Where(dh => dh.MaDonHang == dhh.MaDonHang && dh.MaSP == item.iMaSP).Count();
                    if (countCTDH == 0)
                    {
                        db.ThemChiTietDonHang(dhh.MaDonHang, item.iMaSP, item.iSoLuong, item.dDonGia);
                    }
                    else
                    {
                        ChiTietDonHang ctdhh = db.ChiTietDonHang.Single(dh => dh.MaDonHang == dhh.MaDonHang && dh.MaSP == item.iMaSP);
                        db.SuaChiTietDonHang(dhh.MaDonHang, item.iMaSP, item.iSoLuong+ctdhh.SoLuong);
                    }
                }
                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/ChatMail/newMail.html"));

                content = content.Replace("{{CustomerName}}", user.HoTen);
                content = content.Replace("{{Phone}}", user.DienThoai);
                content = content.Replace("{{Email}}", user.Email);
                content = content.Replace("{{Address}}", user.DiaChi);
                content = content.Replace("{{Total}}", TongThanhTien().ToString("N0"));

                new comon().SendMail(user.Email, "Đơn hàng mới từ T&L Shop", content);
                return RedirectToAction("XoaGioHang_All", "GioHang");
            }
        }
    }
}
