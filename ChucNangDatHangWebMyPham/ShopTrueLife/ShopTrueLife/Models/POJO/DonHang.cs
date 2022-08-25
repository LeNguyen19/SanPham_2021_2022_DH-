using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopTrueLife.Models.KetNoiLinq;

namespace ShopTrueLife.Models.POJO
{
    public class DonHang
    {
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();

        public int iMaDH { get; set; }
        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sAnhBia { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double dThanhTien { get { return iSoLuong * dDonGia; } }
        public DateTime dNgayDat { get; set; }
        public int iTrangThai { get; set; }
        
        public DonHang()
        { }

        public DonHang(int _iMaDH, int _iMaSP, string  _sTenSP, string _sAnhBia, double _dDonGia, int _iSoLuong, DateTime _dNgayDat, int _iTrangThai)
        {
            this.iMaDH = _iMaDH;
            this.iMaSP = _iMaSP;
            this.sTenSP = _sTenSP;
            this.sAnhBia = _sAnhBia;
            this.dDonGia = _dDonGia;
            this.dNgayDat = _dNgayDat;
            this.iTrangThai = _iTrangThai;
        }
        
    }
}