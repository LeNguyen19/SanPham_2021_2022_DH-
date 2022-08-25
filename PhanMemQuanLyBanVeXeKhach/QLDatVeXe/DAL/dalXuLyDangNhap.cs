using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalXuLyDangNhap
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalXuLyDangNhap()
        {

        }

        public int xuLyDangNhap(string TenDangNhap, string MatKhau)
        {
            try
            {
                if(db.TaiKhoans.Where(tk => tk.TenDangNhap.Equals(TenDangNhap) && tk.MatKhau.Equals(MatKhau) && tk.fl_Xoa == 0).Count()>0)
                {
                    return 1; //Đăng nhập thành công
                }
                else
                {
                    return 2; //Tài khoản và mật khẩu không chính xác
                }
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
