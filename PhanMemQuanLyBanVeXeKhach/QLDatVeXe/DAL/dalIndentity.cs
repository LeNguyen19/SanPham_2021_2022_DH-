using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalIndentity
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalIndentity()
        {

        }

        public int? xuatIndentityNhanVien()
        {
            return db.Identifies.Select(kh => kh.NhanVien).FirstOrDefault();
        }

        

        public int? xuatIndentityKhachHang()
        {
            return db.Identifies.Select(kh => kh.KhachHang).FirstOrDefault();
        }

        public int? xuatIndentityVeXe()
        {
            return db.Identifies.Select(kh => kh.VeXe).FirstOrDefault();
        }

        public int? xuatIndentityXe()
        {
            return db.Identifies.Select(kh => kh.Xe).FirstOrDefault();
        }

        public int? xuatIndentityLoTrinh()
        {
            return db.Identifies.Select(kh => kh.LoTrinh).FirstOrDefault();
        }

        public int? xuatIndentityLichChay()
        {
            return db.Identifies.Select(kh => kh.LichChay).FirstOrDefault();
        }

        public int? xuatIndentityLichChay_Xe()
        {
            return db.Identifies.Select(kh => kh.LichChay_Xe).FirstOrDefault();
        }
    }
}
