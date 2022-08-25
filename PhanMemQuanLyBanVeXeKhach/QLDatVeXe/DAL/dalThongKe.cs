using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalThongKe
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalThongKe()
        {

        }

        public List<LichChay> layDanhSachLichChayTheoNam(int nam)
        {
            return db.LichChays.Where(s => s.NgayKhoiHanh.Year.Equals(nam)).Select(k => k).ToList();
        }

        public List<LichChay_Xe> layDanhSachLichChayXeTheoLichChay(int thang, LichChay lc)
        {
            return db.LichChay_Xes.Where(s => s.MaLichChay.Equals(lc.MaLichChay) && lc.NgayKhoiHanh.Month.Equals(thang)).Select(k => k).ToList();
        }

        public List<VeXe> layDanhSachVeXeTheoLichChayXe(LichChay_Xe lcx)
        {
            return db.VeXes.Where(s => s.MaLichChay_Xe.Equals(lcx.MaLichChay_Xe)).Select(k => k).ToList();
        }

        public int soVe(VeXe vx)
        {
            return db.ChiTietVeXes.Where(s => s.MaVeXe.Equals(vx.MaVeXe)).Count();
        }
    }
}
