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
    public class DonHangController : Controller
    {
        //
        // GET: /DonHang/
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();

        public ActionResult DanhSachDonHang()
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
            else
            {
                var dh = from hdbh in db.HoaDonBanHangs
                         join cthd in db.ChiTietHoaDonBanHangs on hdbh.ID_HoaDonBanHang equals cthd.ID_HoaDonBanHang
                         join sp in db.SanPhams on cthd.ID_SanPham equals sp.ID_SanPham
                         join ha in db.HinhAnhs on sp.ID_SanPham equals ha.ID_SanPham
                         where hdbh.TrangThai != 3 && ha.TrangThai == 1 && hdbh.ID_KhachHang.Equals(user.ID_KhachHang)
                         select new { hdbh.ID_HoaDonBanHang, cthd.ID_SanPham, sp.TenSanPham, ha.DuongDanHinh, cthd.Gia, cthd.SoLuong, hdbh.NgayMuaHang, hdbh.TrangThai };
                
                List<DonHang> lstDonHang = new List<DonHang>();
                foreach (var item in dh)
                {

                    DonHang s = new DonHang();
                    s.iMaDH = item.ID_HoaDonBanHang;
                    s.iMaSP = item.ID_SanPham;
                    s.sTenSP = item.TenSanPham;
                    s.sAnhBia = item.DuongDanHinh;
                    s.dDonGia = item.Gia;
                    s.iSoLuong = item.SoLuong;
                    s.dNgayDat = item.NgayMuaHang;
                    s.iTrangThai = item.TrangThai;
                    lstDonHang.Add(s);
                }
                return View(lstDonHang);
            }  
        }

        
    }
}
