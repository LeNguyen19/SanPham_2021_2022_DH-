using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PT_LoTrinh
    {
        public string MaLoTrinh { get; set; }
        public string DiemDi { get; set; }
        public string DiemDen { get; set; }
        public int QuangDuong { get; set; }
        public int GiaVe { get; set; }
        public string fl_NgayThem { get; set; }
        public string fl_NgaySua { get; set; }
        public int fl_Xoa { get; set; }

        public PT_LoTrinh()
        {

        }

        public PT_LoTrinh(string _MaLoTrinh, string _DiemDi, string _DiemDen, int _QuangDuong, int _GiaVe, string _fl_NgayThem, string _fl_NgaySua, int _fl_Xoa)
        {
            this.MaLoTrinh = _MaLoTrinh;
            this.DiemDi = _DiemDi;
            this.DiemDen = _DiemDen;
            this.QuangDuong = _QuangDuong;
            this.GiaVe = _GiaVe;
            this.fl_NgayThem = _fl_NgayThem;
            this.fl_NgaySua = _fl_NgaySua;
            this.fl_Xoa = _fl_Xoa;
        }
    }
}
