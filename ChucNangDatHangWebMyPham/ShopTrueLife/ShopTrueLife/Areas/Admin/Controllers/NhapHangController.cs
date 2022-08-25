using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrueLife.Models.KetNoiLinq;
using ShopTrueLife.Areas.Admin.Models;

namespace ShopTrueLife.Areas.Admin.Controllers
{
    public class NhapHangController : Controller
    {
        //
        // GET: /Admin/NhapHang/
        mdNhapHang nh = new mdNhapHang();
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();

        public ActionResult ShowSanPham()
        {
            return View(nh.xuatListSanPham());
        }

        [HttpGet]
        public ActionResult SuaSanPham(int ma)
        {
            SanPham s = nh.xuatSanPham(ma);
            if (s == null)
            {
                return HttpNotFound();
            }
            return View(s);
        }
        [HttpPost]
        public ActionResult SuaSanPham(SanPham sp)
        {
            if(ModelState.IsValid)
            {
                nh.suaSanPham(sp);
                return RedirectToAction("ShowSanPham", "NhapHang");
            }
            return View();
        }

        public ActionResult ThemSanPham(string TenSanPham, string SoLuong, string GiaNhap, string MaLoaiSP, string MaNCC, string MoTaSanPham)
        {
            if (ModelState.IsValid)
            {
                var user = new NhanVien();
                if (Session["UserAdmin"] != null)
                {
                    user = Session["UserAdmin"] as NhanVien;
                }

                if (TenSanPham == null || SoLuong == null || MaLoaiSP == null || MaNCC == null || GiaNhap == null)
                {
                    return View();
                }
                else
                {
                    int maHDNH = nh.kiemTraMaHoaDonNhap(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, int.Parse(MaNCC));
                    if (maHDNH != 0)
                    {
                        int maSP = nh.kiemTraSanPham(TenSanPham, int.Parse(MaLoaiSP));
                        if (maSP != 0)
                        {
                            nh.tangSLSanPham(maSP, int.Parse(SoLuong));
                            ChiTietHoaDonNhapHang cthd = new ChiTietHoaDonNhapHang();
                            cthd.ID_HoaDonNhapHang = maHDNH;
                            cthd.ID_SanPham = maSP;
                            cthd.SoLuong = int.Parse(SoLuong);
                            cthd.Gia = int.Parse(GiaNhap);
                            nh.themChiTietDonNhapHang(cthd);
                        }
                        else
                        {
                            SanPham sp = new SanPham();
                            sp.TenSanPham = TenSanPham;
                            sp.SoLuong = int.Parse(SoLuong);
                            sp.GiaBan = int.Parse(GiaNhap);
                            sp.MoTaSanPham = MoTaSanPham;
                            sp.ID_LoaiSanPham = int.Parse(MaLoaiSP);
                            nh.themSanPham(sp);

                            int layMaSP = nh.kiemTraSanPham(TenSanPham, int.Parse(MaLoaiSP));
                            ChiTietHoaDonNhapHang cthd = new ChiTietHoaDonNhapHang();
                            cthd.ID_HoaDonNhapHang = maHDNH;
                            cthd.ID_SanPham = layMaSP;
                            cthd.SoLuong = int.Parse(SoLuong);
                            cthd.Gia = int.Parse(GiaNhap);
                            nh.themChiTietDonNhapHang(cthd);
                        }
                        return RedirectToAction("ThemSanPham", "NhapHang");
                    }
                    else
                    {
                        HoaDonNhapHang hdnh = new HoaDonNhapHang();
                        hdnh.NgayNhapHang = DateTime.Now;
                        hdnh.TrangThai = 0;
                        hdnh.ID_NhanVien = user.ID_NhanVien;
                        hdnh.ID_NhaCungCap = int.Parse(MaNCC);
                        nh.themDonNhapHang(hdnh);

                        int maHDNHn = nh.kiemTraMaHoaDonNhap(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, int.Parse(MaNCC));

                        int maSPn = nh.kiemTraSanPham(TenSanPham, int.Parse(MaLoaiSP));
                        if (maSPn != 0)
                        {
                            nh.tangSLSanPham(maSPn, int.Parse(SoLuong));
                            ChiTietHoaDonNhapHang cthd = new ChiTietHoaDonNhapHang();
                            cthd.ID_HoaDonNhapHang = maHDNHn;
                            cthd.ID_SanPham = maSPn;
                            cthd.SoLuong = int.Parse(SoLuong);
                            cthd.Gia = int.Parse(GiaNhap);
                            nh.themChiTietDonNhapHang(cthd);
                        }
                        else
                        {
                            SanPham sp = new SanPham();
                            sp.TenSanPham = TenSanPham;
                            sp.SoLuong = int.Parse(SoLuong);
                            sp.GiaBan = int.Parse(GiaNhap);
                            sp.MoTaSanPham = MoTaSanPham;
                            sp.ID_LoaiSanPham = int.Parse(MaLoaiSP);
                            nh.themSanPham(sp);

                            int layMaSP = nh.kiemTraSanPham(TenSanPham, int.Parse(MaLoaiSP));
                            ChiTietHoaDonNhapHang cthd = new ChiTietHoaDonNhapHang();
                            cthd.ID_HoaDonNhapHang = maHDNHn;
                            cthd.ID_SanPham = layMaSP;
                            cthd.SoLuong = int.Parse(SoLuong);
                            cthd.Gia = int.Parse(GiaNhap);
                            nh.themChiTietDonNhapHang(cthd);
                        }
                        return RedirectToAction("ThemSanPham", "NhapHang");
                    }
                }

            }
            return View();
        }

        public ActionResult ShowLoaiSanPham()
        {
            return View(nh.xuatListLoaiSanPham());
        }

        public ActionResult ThemHinhSanPham(string MaSP, string Hinh)
        {
            if (ModelState.IsValid)
            {
                if(MaSP == null || Hinh == null)
                {
                    return View();
                }
                if (nh.kiemTraHinhAnh(int.Parse(MaSP)) > 0)
                {
                    HinhAnh ha = new HinhAnh();
                    ha.ID_SanPham = int.Parse(MaSP);
                    ha.DuongDanHinh = Hinh;
                    ha.TrangThai = 0;
                    nh.ThemHinhAnh(ha);
                }
                else
                {
                    HinhAnh ha = new HinhAnh();
                    ha.ID_SanPham = int.Parse(MaSP);
                    ha.DuongDanHinh = Hinh;
                    ha.TrangThai = 1;
                    nh.ThemHinhAnh(ha);
                }
                return RedirectToAction("ShowSanPham", "NhapHang");
            }
            return View();
        }
    }
}
