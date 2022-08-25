using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Model_LichChay
    {
        public string MaLichChay { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public string GioKhoiHanh { get; set; }
        public string MaLoTrinh { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime fl_NgayThem { get; set; }
        public DateTime? fl_NgaySua { get; set; }

        public Model_LichChay()
        {

        }

        public Model_LichChay(string _MaLichChay, DateTime _NgayKhoiHanh, string _GioKhoiHanh, string _MaLoTrinh, string _TenNhanVien, DateTime _fl_NgayThem, DateTime? _fl_NgaySua)
        {
            this.MaLichChay = _MaLichChay;
            this.NgayKhoiHanh = _NgayKhoiHanh;
            this.GioKhoiHanh = _GioKhoiHanh;
            this.MaLoTrinh = _MaLoTrinh;
            this.TenNhanVien = _TenNhanVien;
            this.fl_NgayThem = _fl_NgayThem;
            this.fl_NgaySua = _fl_NgaySua;
        }
    }
}
