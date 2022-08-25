using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopMyPham.Models.Entity;

namespace ShopMyPham.Models.DAO
{
    public class TaiKhoanDAO
    {
        private QL_MyPhamEntities3 db = new QL_MyPhamEntities3();
        public ThongTin login(string user, string pass)
        {
            var model = db.ThongTin.Where(t => t.TaiKhoan.CompareTo(user) == 0 && t.MatKhau.CompareTo(pass) == 0).SingleOrDefault();
            return model;
        }
        public DonHang DH(int ma, DateTime ngay)
        {
            var model = db.DonHang.Where(dhh => dhh.MaKH == ma && dhh.NgayDat.Day == ngay.Day && dhh.NgayDat.Month == ngay.Month && dhh.NgayDat.Year == ngay.Year && dhh.TinhTrangGiaoHang == 0 && dhh.DaThanhToan == 0
                || dhh.MaKH == ma && dhh.NgayDat.Day == ngay.Day && dhh.NgayDat.Month == ngay.Month && dhh.NgayDat.Year == ngay.Year && dhh.TinhTrangGiaoHang == 0 && dhh.DaThanhToan == 1).SingleOrDefault();
            return model;
        }
    }
}