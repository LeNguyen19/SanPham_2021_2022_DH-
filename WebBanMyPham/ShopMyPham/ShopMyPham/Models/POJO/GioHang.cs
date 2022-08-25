using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopMyPham.Models.Entity;

namespace ShopMyPham.Models.POJO
{
    public class GioHang
    {
        QL_MyPhamEntities3 db = new QL_MyPhamEntities3();
        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sAnhBia { get; set; }
        public int dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien { get { return iSoLuong * dDonGia; } }
        //khởi tạo giỏ hàng
        public GioHang(int MaSP)
        {
            iMaSP = MaSP;
            SanPham s = db.SanPham.Single(sp => sp.MaSP == iMaSP);
            sTenSP = s.TenSP;
            sAnhBia = s.AnhBia;
            dDonGia = s.GiaBan;
            iSoLuong = 1;
        }
    }
}