using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTrueLife.Models.POJO
{
    public class TrangChiTietBinhLuan
    {
        public int iID { get; set; }
        public int iID_BinhLuan { get; set; }
        public int iID_SanPham { get; set; }
        public DateTime dNgayBinhLuan { get; set; }
        public string sNoiDung { get; set; }
        public string sHoTenKH { get; set; }

        public TrangChiTietBinhLuan()
        {

        }

        public TrangChiTietBinhLuan(int _iID, int _iID_BinhLuan, int _iID_SanPham, DateTime _dNgayBinhLuan, string _sNoiDung, string _sHoTenKH)
        {
            this.iID = _iID;
            this.iID_BinhLuan = _iID_BinhLuan;
            this.iID_SanPham = _iID_SanPham;
            this.dNgayBinhLuan = _dNgayBinhLuan;
            this.sNoiDung = _sNoiDung;
            this.sHoTenKH = _sHoTenKH;
        }
    }
}