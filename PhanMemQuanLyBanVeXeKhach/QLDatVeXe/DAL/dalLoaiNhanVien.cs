using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalLoaiNhanVien
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalLoaiNhanVien()
        {

        }

        public List<LoaiNhanVien> xuatListLoaiNhanVien()
        {
            return db.LoaiNhanViens.Where(lnv => lnv.fl_Xoa == 0).ToList<LoaiNhanVien>();
        }

        public LoaiNhanVien xuatLoaiNhanVien(int MaLoaiNhanVien)
        {
            return db.LoaiNhanViens.Where(lnv => lnv.MaLoaiNhanVien.Equals(MaLoaiNhanVien) && lnv.fl_Xoa == 0).FirstOrDefault();
        }
    }
}
