using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Model_ListTaiKhoan
    {
        public string MaNguoiDung { get; set; }
        public string TenNguoiDung { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public int MaLoaiTaiKhoan { get; set; }
        public string TenLoaiTaiKhoan { get; set; }

        public Model_ListTaiKhoan()
        {

        }

        public Model_ListTaiKhoan(string _MaNguoiDung, string _TenNguoiDung, string _TenDangNhap, string _MatKhau, int _MaLoaiTaiKhoan, string _TenLoaiTaiKhoan)
        {
            this.MaNguoiDung = _MaNguoiDung;
            this.TenNguoiDung = _TenNguoiDung;
            this.TenDangNhap = _TenDangNhap;
            this.MatKhau = _MatKhau;
            this.MaLoaiTaiKhoan = _MaLoaiTaiKhoan;
            this.TenLoaiTaiKhoan = _TenLoaiTaiKhoan;
        }
    }
}
