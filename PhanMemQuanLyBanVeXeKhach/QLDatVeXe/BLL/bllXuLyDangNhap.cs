using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class bllXuLyDangNhap
    {
        dalXuLyDangNhap dalXuLyDangNhap = new dalXuLyDangNhap();
        public bllXuLyDangNhap()
        {

        }

        public int xuLyDangNhap(string TenDangNhap, string MatKhau)
        {
            return dalXuLyDangNhap.xuLyDangNhap(TenDangNhap, MatKhau);
        }
    }
}
