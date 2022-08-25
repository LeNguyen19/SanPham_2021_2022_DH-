using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Model_TaiKhoan
    {
        public int MaLoaiTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string TenDangNhap { get; set; }
        public string fl_NgaySua { get; set; }
        public string fl_NgayThem { get; set; }
        public int fl_Xoa { get; set; }

        public Model_TaiKhoan()
        {

        }
        public Model_TaiKhoan(int _MaLoaiTaiKhoan, string _MatKhau, string _TenDangNhap, string _fl_NgaySua, string _fl_NgayThem, int _fl_Xoa)
        {
            this.MaLoaiTaiKhoan = _MaLoaiTaiKhoan;
            this.MatKhau = _MatKhau;
            this.TenDangNhap = _TenDangNhap;
            this.fl_NgaySua = _fl_NgaySua;
            this.fl_NgayThem = _fl_NgayThem;
            this.fl_Xoa = _fl_Xoa;
        }
    }
}
