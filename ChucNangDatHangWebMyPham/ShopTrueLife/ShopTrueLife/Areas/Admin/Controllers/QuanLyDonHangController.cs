using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrueLife.Models.KetNoiLinq;
using ShopTrueLife.Areas.Admin.Models;
using ShopTrueLife.Models.POJO;
using ShopTrueLife.Models.DAO;
using Microsoft.VisualBasic;

namespace ShopTrueLife.Areas.Admin.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();
        //
        // GET: /Admin/QuanLyDonHang/

        public ActionResult QLDonHang()
        {
            List<pojoQLDonHang> lstDonHang = new List<pojoQLDonHang>();

            var dh = from hdbh in db.HoaDonBanHangs
                     where hdbh.TrangThai != 3 
                     select new { hdbh.ID_HoaDonBanHang, hdbh.ID_KhachHang, hdbh.NgayMuaHang, hdbh.TrangThai };

            foreach (var item in dh)
            {

                pojoQLDonHang s = new pojoQLDonHang();
                s.iMaDH = item.ID_HoaDonBanHang;
                s.iMaKH = item.ID_KhachHang;
                s.dNgayDat = item.NgayMuaHang;
                s.iTrangThai = item.TrangThai;
                lstDonHang.Add(s);
            }

            return View(lstDonHang);

        }

        public ActionResult CapNhatTrangThai(int ma)
        {
            DAODonHang d = new DAODonHang();
            if (d.CapNhatTrangThaiDonHang(ma))
            {
                return RedirectToAction("QLDonHang", "QuanLyDonHang");
            }
            return View(ma);
        }

        public ActionResult XemChiTietDonHang(int maDH)
        {


            var dh = from hdbh in db.HoaDonBanHangs
                     join cthd in db.ChiTietHoaDonBanHangs on hdbh.ID_HoaDonBanHang equals cthd.ID_HoaDonBanHang
                     join sp in db.SanPhams on cthd.ID_SanPham equals sp.ID_SanPham
                     join ha in db.HinhAnhs on sp.ID_SanPham equals ha.ID_SanPham
                     where ha.TrangThai == 1 && hdbh.ID_HoaDonBanHang==maDH
                     select new { hdbh.ID_HoaDonBanHang, hdbh.ID_KhachHang, cthd.ID_SanPham, sp.TenSanPham, ha.DuongDanHinh, cthd.Gia, cthd.SoLuong, hdbh.NgayMuaHang };

            List<pojoXemChiTietDonHang> lstCTDH = new List<pojoXemChiTietDonHang>();
            foreach (var item in dh)
            {
                pojoXemChiTietDonHang s = new pojoXemChiTietDonHang();
                s.iMaDH = item.ID_HoaDonBanHang;
                s.iMaKH = item.ID_KhachHang;
                s.iMaSP = item.ID_SanPham;
                s.sTenSP = item.TenSanPham;
                s.sAnhBia = item.DuongDanHinh;
                s.dDonGia = item.Gia;
                s.iSoLuong = item.SoLuong;
                s.dNgayDat = item.NgayMuaHang;
                lstCTDH.Add(s);
            }
            return View(lstCTDH);
            
        }
    }
}
