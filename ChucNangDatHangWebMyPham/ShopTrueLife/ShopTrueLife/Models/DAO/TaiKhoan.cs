using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopTrueLife.Models.KetNoiLinq;

namespace ShopTrueLife.Models.DAO
{
    public class TaiKhoan
    {
        private QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();

        public KhachHang loginKhachHang(string TaiKhoan, string MatKhau)
        {
            return db.KhachHangs.Where(tkkh => tkkh.TenDangNhap.CompareTo(TaiKhoan) == 0 && tkkh.MatKhau.CompareTo(MatKhau) == 0).SingleOrDefault();
        }

        public NhanVien loginNhanVien(string TaiKhoan, string MatKhau)
        {
            return db.NhanViens.Where(tkkh => tkkh.TenDangNhap.CompareTo(TaiKhoan) == 0 && tkkh.MatKhau.CompareTo(MatKhau) == 0).SingleOrDefault();
        }
    }
}