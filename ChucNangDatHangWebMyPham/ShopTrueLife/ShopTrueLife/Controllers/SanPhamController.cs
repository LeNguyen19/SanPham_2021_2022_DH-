using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrueLife.Models.KetNoiLinq;
using ShopTrueLife.Models.POJO;

namespace ShopTrueLife.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();

        public ActionResult ChiTietSanPham(int maSP, int gia)
        {
            var sp = db.SanPhams.Where(s => s.ID_SanPham == maSP).Single();
            var cmt = from bl in db.BinhLuans
                      join ctbl in db.ChiTietBinhLuans on bl.ID_BinhLuan equals ctbl.ID_BinhLuan
                      join kh in db.KhachHangs on ctbl.ID_KhachHang equals kh.ID_KhachHang
                      where bl.ID_SanPham == maSP
                      select new { ctbl.ID, bl.ID_BinhLuan, bl.ID_SanPham, ctbl.NgayBinhLuan, ctbl.NoiDung, kh.HoTen_KH };
            List<TrangChiTietBinhLuan> ctcmt = new List<TrangChiTietBinhLuan>();
            foreach(var item in cmt)
            {
                TrangChiTietBinhLuan v = new TrangChiTietBinhLuan();
                v.iID = item.ID;
                v.iID_BinhLuan = item.ID_BinhLuan;
                v.iID_SanPham = item.ID_SanPham;
                v.sHoTenKH = item.HoTen_KH;
                v.sNoiDung = item.NoiDung;
                v.dNgayBinhLuan = item.NgayBinhLuan;
                ctcmt.Add(v);
            }
            var hinh = db.HinhAnhs.Where(h => h.ID_SanPham == maSP).ToList();
            List<HinhAnh> hinhanh = new List<HinhAnh>();
            foreach(var item in hinh)
            {
                HinhAnh haa = new HinhAnh();
                haa.DuongDanHinh = item.DuongDanHinh;
                haa.ID_SanPham = item.ID_SanPham;
                haa.TrangThai = item.TrangThai;
                hinhanh.Add(haa);
            }
            TrangChiTietSanPham tctsp = new TrangChiTietSanPham();
            tctsp.lsCMT = ctcmt;
            tctsp.iGiaBan = gia;
            tctsp.iID_SanPham = sp.ID_SanPham;
            tctsp.iSoLuong = sp.SoLuong;
            tctsp.lsDuongDan = hinhanh;
            tctsp.sMoTaSanPham = sp.MoTaSanPham;
            tctsp.sTenSanPham = sp.TenSanPham;
            tctsp.iTonKho = sp.SoLuong;
            return View(tctsp);
        }

        public ActionResult ChiTietSanPhamUser(int maSP, int gia)
        {
            var sp = db.SanPhams.Where(s => s.ID_SanPham == maSP).Single();
            var cmt = from bl in db.BinhLuans
                      join ctbl in db.ChiTietBinhLuans on bl.ID_BinhLuan equals ctbl.ID_BinhLuan
                      join kh in db.KhachHangs on ctbl.ID_KhachHang equals kh.ID_KhachHang
                      where bl.ID_SanPham == maSP
                      select new { ctbl.ID, bl.ID_BinhLuan, bl.ID_SanPham, ctbl.NgayBinhLuan, ctbl.NoiDung, kh.HoTen_KH };
            List<TrangChiTietBinhLuan> ctcmt = new List<TrangChiTietBinhLuan>();
            foreach (var item in cmt)
            {
                TrangChiTietBinhLuan v = new TrangChiTietBinhLuan();
                v.iID = item.ID;
                v.iID_BinhLuan = item.ID_BinhLuan;
                v.iID_SanPham = item.ID_SanPham;
                v.sHoTenKH = item.HoTen_KH;
                v.sNoiDung = item.NoiDung;
                v.dNgayBinhLuan = item.NgayBinhLuan;
                ctcmt.Add(v);
            }
            var hinh = db.HinhAnhs.Where(h => h.ID_SanPham == maSP).ToList();
            List<HinhAnh> hinhanh = new List<HinhAnh>();
            foreach (var item in hinh)
            {
                HinhAnh haa = new HinhAnh();
                haa.DuongDanHinh = item.DuongDanHinh;
                haa.ID_SanPham = item.ID_SanPham;
                haa.TrangThai = item.TrangThai;
                hinhanh.Add(haa);
            }
            TrangChiTietSanPham tctsp = new TrangChiTietSanPham();
            tctsp.lsCMT = ctcmt;
            tctsp.iGiaBan = gia;
            tctsp.iID_SanPham = sp.ID_SanPham;
            tctsp.iSoLuong = sp.SoLuong;
            tctsp.lsDuongDan = hinhanh;
            tctsp.sMoTaSanPham = sp.MoTaSanPham;
            tctsp.sTenSanPham = sp.TenSanPham;
            return View(tctsp);
        }
    }
}
