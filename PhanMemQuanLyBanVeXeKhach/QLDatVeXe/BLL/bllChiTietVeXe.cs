using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class bllChiTietVeXe
    {
        dalChiTietVeXe dalChiTietVeXe = new dalChiTietVeXe();
        public bllChiTietVeXe()
        {

        }

        public List<string> listViTriGheDuaTrenMaLichChay_Xe(string maLichChayXe)
        {
            return dalChiTietVeXe.listViTriGheDuaTrenMaLichChay_Xe(maLichChayXe);
        }

        public bool themChiTietVeXe(ChiTietVeXe ctvx)
        {
            return dalChiTietVeXe.themChiTietVeXe(ctvx);
        }

        public List<Model_DanhSachVe> layDanhSachVe(string maLichChay_Xe, string maLichChay)
        {
            return dalChiTietVeXe.layDanhSachVe(maLichChay_Xe, maLichChay);
        }

        public List<Model_DanhSachVe> timKiemDanhSachVe(string maLichChay_Xe, string maLichChay, string tenKhachHang)
        {
            return dalChiTietVeXe.timKiemDanhSachVe(maLichChay_Xe, maLichChay, tenKhachHang);
        }

        public bool xoaChiTietVeXe(ChiTietVeXe ctvx)
        {
            return dalChiTietVeXe.xoaChiTietVeXe(ctvx);
        }
    }
}
