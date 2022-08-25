using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PT_LichChay
    {
        public string MaLichChay { get; set; }
        public string NgayKhoiHanh { get; set; }
        public string GioKhoiHanh { get; set; }
        public string MaLoTrinh { get; set; }
        public string MaNhanVien { get; set; }
        public string fl_NgayThem { get; set; }
        public string fl_NgaySua { get; set; }
        public int fl_Xoa { get; set; }

        public PT_LichChay()
        {

        }

        public PT_LichChay(string _MaLichChay, string _NgayKhoiHanh, string _GioKhoiHanh, string _MaLoTrinh, string _MaNhanVien, string _fl_NgayThem, string _fl_NgaySua, int _fl_Xoa)
        {
            this.MaLichChay = _MaLichChay;
            this.NgayKhoiHanh = _NgayKhoiHanh;
            this.GioKhoiHanh = _GioKhoiHanh;
            this.MaLoTrinh = _MaLoTrinh;
            this.MaNhanVien = _MaNhanVien;
            this.fl_NgayThem = _fl_NgayThem;
            this.fl_NgaySua = _fl_NgaySua;
            this.fl_Xoa = _fl_Xoa;
        }
    }
}
