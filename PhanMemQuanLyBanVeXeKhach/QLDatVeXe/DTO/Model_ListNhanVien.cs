using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Model_ListNhanVien
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string DienThoai { get; set; }
        public string CCCD { get; set; }
        public string DiaChi { get; set; }
        public string TenDangNhap { get; set; }
        public DateTime fl_NgayThem { get; set; }
        public DateTime? fl_NgaySua { get; set; }
        public int fl_Xoa { get; set; }
        public string TenLoaiNhanVien { get; set; }

        public Model_ListNhanVien()
        {

        }
        public Model_ListNhanVien(string _MaNhanVien, string _TenNhanVien, string _GioiTinh, DateTime _NgaySinh, string _DienThoai, string _CCCD, string _DiaChi, string _TenDangNhap, DateTime _fl_NgayThem, DateTime? _fl_NgaySua, int _fl_Xoa, string _TenLoaiNhanVien)
        {
            this.MaNhanVien = _MaNhanVien;
            this.TenNhanVien = _TenNhanVien;
            this.GioiTinh = _GioiTinh;
            this.NgaySinh = _NgaySinh;
            this.DienThoai = _DienThoai;
            this.CCCD = _CCCD;
            this.DiaChi = _DiaChi;
            this.TenDangNhap = _TenDangNhap;
            this.fl_NgayThem = _fl_NgayThem;
            this.fl_NgaySua = _fl_NgaySua;
            this.fl_Xoa = _fl_Xoa;
            this.TenLoaiNhanVien = _TenLoaiNhanVien;
        }
    }
}
