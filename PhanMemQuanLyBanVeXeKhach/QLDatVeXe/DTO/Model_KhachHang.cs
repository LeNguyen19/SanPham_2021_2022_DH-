using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Model_KhachHang
    {
        public string MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public string GioiTinh { get; set; }
        public string NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public string TenDangNhap { get; set; }
        public string fl_NgayThem { get; set; }
        public string fl_NgaySua { get; set; }
        public int fl_Xoa { get; set; }

        public Model_KhachHang(string _MaKhachHang, string _TenKhachHang, string _GioiTinh, string _NgaySinh, string _DienThoai, string _CCCD, string _DiaChi, string _TenDangNhap, string _fl_NgayThem, string _fl_NgaySua, int _fl_Xoa)
        {
            this.MaKhachHang = _MaKhachHang;
            this.TenKhachHang = _TenKhachHang;
            this.GioiTinh = _GioiTinh;
            this.NgaySinh = _NgaySinh;
            this.DienThoai = _DienThoai;
            this.CCCD = _CCCD;
            this.DiaChi = _DiaChi;
            this.TenDangNhap = _TenDangNhap;
            this.fl_NgaySua = _fl_NgaySua;
            this.fl_NgayThem = _fl_NgayThem;
            this.fl_Xoa = _fl_Xoa;
        }
        public Model_KhachHang()
        {

        }
    }
}
