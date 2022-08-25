using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalLoaiTaiKhoan
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalLoaiTaiKhoan()
        {

        }

        public List<LoaiTaiKhoan> xuatListLoaiTaiKhoan()
        {
            return db.LoaiTaiKhoans.Where(ltk => ltk.fl_Xoa == 0).ToList<LoaiTaiKhoan>();
        }

        public LoaiTaiKhoan xuatLoaiTaiKhoan(int MaLoaiTaiKhoan)
        {
            return db.LoaiTaiKhoans.Where(ltk => ltk.MaLoaiTaiKhoan.Equals(MaLoaiTaiKhoan) && ltk.fl_Xoa == 0).FirstOrDefault();
        }
    }
}
