using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopTrueLife.Models.KetNoiLinq;

namespace ShopTrueLife.Models.POJO
{
    public class TrangChiTietSanPham
    {
        public List<TrangChiTietBinhLuan> lsCMT { get; set; }
        public List<HinhAnh> lsDuongDan { get; set; }
        public int iID_SanPham { get; set; }
        public string sTenSanPham { get; set; }
        public int iSoLuong { get; set; }
        public int iGiaBan { get; set; }
        public string sMoTaSanPham { get; set; }

        public int iTonKho { get; set; }

        public TrangChiTietSanPham()
        {

        }
        public TrangChiTietSanPham(List<TrangChiTietBinhLuan> _lsCMT, List<HinhAnh> _lsDuongDan, int _iID_SanPham, string _sTenSanPham, int _iSoLuong, int _iGiaBan, string _sMoTaSanPham, int _iTonKho)
        {
            this.lsCMT = _lsCMT;
            this.lsDuongDan = _lsDuongDan;
            this.iID_SanPham = _iID_SanPham;
            this.sTenSanPham = _sTenSanPham;
            this.iSoLuong = _iSoLuong;
            this.iGiaBan = _iGiaBan;
            this.sMoTaSanPham = _sMoTaSanPham;
            this.iTonKho = _iTonKho;
        }
    }
}