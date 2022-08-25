using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopTrueLife.Models.KetNoiLinq;

namespace ShopTrueLife.Areas.Admin.Models
{
    public class pojoXemChiTietDonHang
    {
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();

        public int iMaDH { get; set; }
        public int iMaKH { get; set; }
        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien { get { return iSoLuong * dDonGia; } }
        public DateTime dNgayDat { get; set; }
        
        public pojoXemChiTietDonHang()
        { }

        public pojoXemChiTietDonHang(int _iMaDH, int _iMaKH, int _iMaSP, string _sTenSP, string _sAnhBia, double _dDonGia, int _iSoLuong, DateTime _dNgayDat, int _iTrangThai)
        {
            this.iMaDH = _iMaDH;
            this.iMaKH = _iMaKH;
            this.iMaSP = _iMaSP;
            this.sTenSP = _sTenSP;
            this.sAnhBia = _sAnhBia;
            this.dDonGia = _dDonGia;
            this.iSoLuong = _iSoLuong;
            this.dNgayDat = _dNgayDat;

        }
    }
}