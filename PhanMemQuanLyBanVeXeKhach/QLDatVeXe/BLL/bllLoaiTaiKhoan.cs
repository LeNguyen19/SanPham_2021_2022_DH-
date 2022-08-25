using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class bllLoaiTaiKhoan
    {
        dalLoaiTaiKhoan dalLoaiTaiKhoan = new dalLoaiTaiKhoan();
        public bllLoaiTaiKhoan()
        {

        }

        public List<LoaiTaiKhoan> xuatListLoaiTaiKhoan()
        {
            return dalLoaiTaiKhoan.xuatListLoaiTaiKhoan();
        }

        public LoaiTaiKhoan xuatLoaiTaiKhoan(int MaLoaiTaiKhoan)
        {
            return dalLoaiTaiKhoan.xuatLoaiTaiKhoan(MaLoaiTaiKhoan);
        }
    }
}
