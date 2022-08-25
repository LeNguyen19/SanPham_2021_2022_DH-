using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PT_LichChay_Xe
    {
        public string MaLichChay_Xe { get; set; }
        public int TrangThai { get; set; }
        public string MaLichChay { get; set; }
        public string MaXe { get; set; }
        public string fl_NgayThem { get; set; }
        public string fl_NgaySua { get; set; }
        public int fl_Xoa { get; set; }

        public PT_LichChay_Xe()
        {

        }

        public PT_LichChay_Xe(string _MaLichChay_Xe, int _TrangThai, string _MaLichChay, string _MaXe, string _fl_NgayThem, string _fl_NgaySua, int _fl_Xoa)
        {
            this.MaLichChay_Xe = _MaLichChay_Xe;
            this.TrangThai = _TrangThai;
            this.MaLichChay = _MaLichChay;
            this.MaXe = _MaXe;
            this.fl_NgayThem = _fl_NgayThem;
            this.fl_NgaySua = _fl_NgaySua;
            this.fl_Xoa = _fl_Xoa;
        }
    }
}
