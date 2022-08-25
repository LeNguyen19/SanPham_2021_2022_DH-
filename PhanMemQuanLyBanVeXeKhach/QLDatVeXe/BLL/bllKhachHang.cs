using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class bllKhachHang
    {
        dalKhachHang dalKhachHang = new dalKhachHang();
        public bllKhachHang()
        {

        }

        public List<KhachHang> xuatListKhachHang()
        {
            return dalKhachHang.xuatListKhachHang();
        }

        public bool themKhachHang(KhachHang kh)
        {
            return dalKhachHang.themKhachHang(kh);
        }

        public bool suaKhachHang(KhachHang kh)
        {
            return dalKhachHang.suaKhachHang(kh);
        }

        public bool xoaKhachHang(string MaKhachHang)
        {
            return dalKhachHang.xoaKhachHang(MaKhachHang);
        }

        public KhachHang xuatKhachHang(string MaKhachHang)
        {
            return dalKhachHang.xuatKhachHang(MaKhachHang);
        }

        public string xuatKhachHang_SDT(string soDienThoai)
        {
            return dalKhachHang.xuatKhachHang_SDT(soDienThoai);
        }
    }
}
