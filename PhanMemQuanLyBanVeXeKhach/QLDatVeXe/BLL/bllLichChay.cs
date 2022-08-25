using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class bllLichChay
    {
        dalLichChay dalLichChay = new dalLichChay();
        public bllLichChay()
        {

        }
        public List<string> layGioLichChay(DateTime ngayKhoiHanh, string maLoTrinh)
        {
            return dalLichChay.layGioLichChay(ngayKhoiHanh, maLoTrinh);
        }

        public string layMaLichChay(DateTime ngayKhoiHanh, string maLoTrinh, string gioKhoiHanh)
        {
            return dalLichChay.layMaLichChay(ngayKhoiHanh, maLoTrinh, gioKhoiHanh);
        }

        public bool themLichChay(LichChay lc)
        {
            return dalLichChay.themLichChay(lc);
        }

        public bool xoaLichChay(string maLichChay)
        {
            return dalLichChay.xoaLichChay(maLichChay);
        }

        public bool suaLichChay(LichChay lc)
        {
            return dalLichChay.suaLichChay(lc);
        }

        public List<Model_LichChay> xuatListLichChayNV()
        {
            return dalLichChay.xuatListLichChayNV();
        }

        public List<Model_LichChay_LoTrinh> xuatListLichChay_LoTrinh()
        {
            return dalLichChay.xuatListLichChay_LoTrinh();
        }
    }
}
