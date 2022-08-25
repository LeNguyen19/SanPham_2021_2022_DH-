using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTrueLife.Areas.Admin.Models
{
    public class pojoSanPham
    {
        public int iID_SanPham { get; set; }
        public string sAnhBia { get; set; }
        public string sTenSanPham { get; set; }
        public int iSoLuong { get; set; }
        public string sMoTa { get; set; }
        public int iGiaBan { get; set; }
        public string sTenLoaiSanPham { get; set; }

        public pojoSanPham()
        {

        }
        public pojoSanPham(int _iID_SanPham, string _sAnhBia, string _sTenSanPham, int _iSoLuong, string _sMoTa, int _iGiaBan, string _sTenLoaiSanPham)
        {
            this.iID_SanPham = _iID_SanPham;
            this.sAnhBia = _sAnhBia;
            this.sTenSanPham = _sTenSanPham;
            this.iSoLuong = _iSoLuong;
            this.iGiaBan = _iGiaBan;
            this.sMoTa = _sMoTa;
            this.sTenLoaiSanPham = _sTenLoaiSanPham;
        }
    }
}