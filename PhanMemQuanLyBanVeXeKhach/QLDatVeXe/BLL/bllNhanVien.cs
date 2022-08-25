using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class bllNhanVien
    {
        dalNhanVien dalNhanVien = new dalNhanVien();
        public bllNhanVien()
        {

        }
        public List<Model_ListNhanVien> xuatListNhanVien()
        {
            return dalNhanVien.xuatListNhanVien();
        }

        public NhanVien xuatNhanVien(string MaNhanVien)
        {
            return dalNhanVien.xuatNhanVien(MaNhanVien);
        }

        public bool ThemNhanVien(NhanVien nv)
        {
            return dalNhanVien.ThemNhanVien(nv);
        }

        public bool SuaNhanVien(NhanVien nv)
        {
            return dalNhanVien.SuaNhanVien(nv);
        }

        public bool XoaNhanVien(string MaNhanVien)
        {
            return dalNhanVien.XoaNhanVien(MaNhanVien);
        }

        public List<NhanVien> xuatListNhanVienTaiXe()
        {
            return dalNhanVien.xuatListNhanVienTaiXe();
        }
    }
}
