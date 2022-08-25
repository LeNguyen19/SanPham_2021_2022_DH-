using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class bllLichChay_Xe
    {
        dalLichChay_Xe dalLichChay_Xe = new dalLichChay_Xe();
        public bllLichChay_Xe()
        {

        }

        public List<LichChay_Xe> layListLichChay_XeNhoMaLichChay(string maLichChay)
        {
            return dalLichChay_Xe.layListLichChay_XeNhoMaLichChay(maLichChay);
        }

        public List<LichChay_Xe> layListLichChay_Xe()
        {
            return dalLichChay_Xe.layListLichChay_Xe();
        }

        public bool themLichChay_Xe(LichChay_Xe lcx)
        {
            return dalLichChay_Xe.themLichChay_Xe(lcx);
        }
        public bool xoaLichChay_Xe(string maLichChayXe)
        {
            return dalLichChay_Xe.xoaLichChay_Xe(maLichChayXe);
        }

        public bool suaLichChay_Xe(LichChay_Xe lcx)
        {
            return dalLichChay_Xe.suaLichChay_Xe(lcx);
        }

        public bool capNhatTrangThaiLichChay_Xe(string maLichChayXe)
        {
            return dalLichChay_Xe.capNhatTrangThaiLichChay_Xe(maLichChayXe);
        }
        public int laySoLuongLichChay_Xe()
        {
            return dalLichChay_Xe.laySoLuongLichChay_Xe();
        }
    }
}
