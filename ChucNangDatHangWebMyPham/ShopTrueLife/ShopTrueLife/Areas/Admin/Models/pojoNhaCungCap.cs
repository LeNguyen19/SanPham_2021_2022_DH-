using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopTrueLife.Models.KetNoiLinq;

namespace ShopTrueLife.Areas.Admin.Models
{
    public class pojoNhaCungCap
    {
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();
        public int iID_NCC { get; set; }
        public string sTenNhaCungCap { get; set; }
        public string sDiaChi { get; set; }
        public string sSDT { get; set; }

        public pojoNhaCungCap()
        {

        }

        public pojoNhaCungCap(int _iID_NCC, string _sTenNhaCungCap, string _sDiaChi)
        {
            this.iID_NCC = _iID_NCC;
            this.sTenNhaCungCap = _sTenNhaCungCap;
            this.sDiaChi = _sDiaChi;
            List<string> d = db.DienThoai_NhaCungCaps.Where(s => s.ID_NhaCungCap.Equals(_iID_NCC)).Select(k => k.SoDienThoai).ToList();
            this.sSDT = "";
            foreach(string i in d)
            {
                sSDT = sSDT + " - " + i;
            }
        }
    }
}