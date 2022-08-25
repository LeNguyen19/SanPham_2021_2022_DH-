using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopTrueLife.Models.KetNoiLinq;

namespace ShopTrueLife.Models.POJO
{
    public class GioHang
    {
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();

        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sAnhBia { get; set; }
        public int dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien { get { return iSoLuong * dDonGia; } }
        //khởi tạo giỏ hàng
        public GioHang(int MaSP)
        {
            this.iMaSP = MaSP;
            SanPham s = db.SanPhams.Single(sp => sp.ID_SanPham == MaSP);
            this.sTenSP = s.TenSanPham;
            this.sAnhBia = db.HinhAnhs.Where(ha => ha.ID_SanPham.Equals(MaSP) && ha.TrangThai.Equals(1)).Select(sa => sa.DuongDanHinh).SingleOrDefault();
            this.dDonGia = s.GiaBan;
            this.iSoLuong = 1;
        }
    }
}