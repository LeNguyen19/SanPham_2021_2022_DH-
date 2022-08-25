using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Model_LichChay_LoTrinh
    {
        public string MaLichChay { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public string GioKhoiHanh { get; set; }
        public string MaLoTrinh { get; set; }
        public string DiemDi { get; set; }
        public string DiemDen { get; set; }
        public string TenNhanVien { get; set; }
        public Model_LichChay_LoTrinh()
        {
            
        }

        public Model_LichChay_LoTrinh(string _MaLichChay, DateTime _NgayKhoiHanh, string _GioKhoiHanh, string _MaLoTrinh, string _DiemDi, string _DiemDen, string _TenNhanVien)
        {
            this.MaLichChay = _MaLichChay;
            this.NgayKhoiHanh = _NgayKhoiHanh;
            this.GioKhoiHanh = _GioKhoiHanh;
            this.MaLoTrinh = _MaLoTrinh;
            this.DiemDi = _DiemDi;
            this.DiemDen = _DiemDen;
            this.TenNhanVien = _TenNhanVien;
        }
    }
}
