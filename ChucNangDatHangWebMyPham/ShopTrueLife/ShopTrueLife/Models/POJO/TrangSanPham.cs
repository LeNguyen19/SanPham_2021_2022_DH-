using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTrueLife.Models.POJO
{
    public class TrangSanPham
    {
        public int iID_SanPham { get; set; }
        public string sAnhBia { get; set; }
        public string sTenSanPham { get; set; }
        public int iGiaBan { get; set; }
        public int iGiaDaGiam { get; set; }

        public TrangSanPham()
        {

        }
        public TrangSanPham(int _iID_SanPham, string _sAnhBia, string _sTenSanPham, int _iGiaBan, int _iGiaDaGiam)
        {
            this.iID_SanPham = _iID_SanPham;
            this.sAnhBia = _sAnhBia;
            this.sTenSanPham = _sTenSanPham;
            this.iGiaBan = _iGiaBan;
            this.iGiaDaGiam = _iGiaDaGiam;
        }

    }
}