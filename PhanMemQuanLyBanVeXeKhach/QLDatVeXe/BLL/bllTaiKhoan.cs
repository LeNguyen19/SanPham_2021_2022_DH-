using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class bllTaiKhoan
    {
        dalTaiKhoan dalTaiKhoan = new dalTaiKhoan();
        public bllTaiKhoan()
        {

        }

        public List<Model_ListTaiKhoan> xuatListTaiKhoan()
        {
            return dalTaiKhoan.xuatListTaiKhoan();
        }

        public List<Model_ListTaiKhoan> xuatTaiKhoanTheoLoai(int MaLoaiTaiKhoan)
        {
            return dalTaiKhoan.xuatTaiKhoanTheoLoai(MaLoaiTaiKhoan);
        }

        public TaiKhoan xuatTaiKhoan(string TenDangNhap)
        {
            return dalTaiKhoan.xuatTaiKhoan(TenDangNhap);
        }

        public bool ThemTaiKhoan(TaiKhoan tk)
        {
            return dalTaiKhoan.ThemTaiKhoan(tk);
        }

        public bool SuaTaiKhoan(TaiKhoan tk)
        {
            return dalTaiKhoan.SuaTaiKhoan(tk);
        }

        public bool XoaTaiKhoan(string TenDangNhap)
        {
            return dalTaiKhoan.XoaTaiKhoan(TenDangNhap);
        }
    }
}
