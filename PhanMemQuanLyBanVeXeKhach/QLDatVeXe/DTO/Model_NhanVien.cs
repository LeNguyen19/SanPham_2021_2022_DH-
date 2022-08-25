using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Model_NhanVien
    {
        public NhanVien NhanVien { get; set; }
        public LoaiNhanVien LoaiNhanVien { get; set; }
        public TaiKhoan TaiKhoan { get; set; }

        public Model_NhanVien(NhanVien _NhanVien, LoaiNhanVien _LoaiNhanVien, TaiKhoan _TaiKhoan)
        {
            this.NhanVien = _NhanVien;
            this.LoaiNhanVien = _LoaiNhanVien;
            this.TaiKhoan = _TaiKhoan;

        }

        public Model_NhanVien()
        {

        }
    }
}
