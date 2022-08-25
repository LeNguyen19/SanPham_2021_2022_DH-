using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopTrueLife.Models.KetNoiLinq;

namespace ShopTrueLife.Areas.Admin.Models
{
    public class pojoQLDonHang
    {
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();

        public int iMaDH { get; set; }
        public int iMaKH { get; set; }
        public DateTime dNgayDat { get; set; }
        
        public int iTrangThai { get; set; }
        
        public pojoQLDonHang()
        { }

        public pojoQLDonHang(int _iMaDH, int _iMaKH, DateTime _dNgayDat, int _iTrangThai)
        {
            this.iMaDH = _iMaDH;
            this.iMaKH = _iMaKH;
            this.dNgayDat = _dNgayDat;
            this.iTrangThai = _iTrangThai;
        }
    }
}