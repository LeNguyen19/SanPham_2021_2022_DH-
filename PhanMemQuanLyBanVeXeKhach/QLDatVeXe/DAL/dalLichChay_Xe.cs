using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalLichChay_Xe
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalLichChay_Xe()
        {

        }

        public List<LichChay_Xe> layListLichChay_XeNhoMaLichChay(string maLichChay)
        {
            return db.LichChay_Xes.Where(lcx => lcx.MaLichChay.Equals(maLichChay) && lcx.fl_Xoa.Equals(0)).ToList<LichChay_Xe>();
        }

        public List<LichChay_Xe> layListLichChay_Xe()
        {
            return db.LichChay_Xes.Where(lcx => lcx.fl_Xoa.Equals(0)).Select(s => s).ToList<LichChay_Xe>();
        }

        public bool themLichChay_Xe(LichChay_Xe lcx)
        {
            try
            {
                db.LichChay_Xes.InsertOnSubmit(lcx);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool xoaLichChay_Xe(string maLichChayXe)
        {
            try
            {
                LichChay_Xe lcx = db.LichChay_Xes.Where(lc => lc.MaLichChay_Xe.Equals(maLichChayXe) && lc.fl_Xoa.Equals(0)).FirstOrDefault();
                lcx.fl_Xoa = 1;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool suaLichChay_Xe(LichChay_Xe lcx)
        {
            try
            {
                LichChay_Xe lcxx = db.LichChay_Xes.Where(lc => lc.MaLichChay_Xe.Equals(lcx.MaLichChay_Xe) && lc.fl_Xoa.Equals(0)).FirstOrDefault();
                lcxx.MaLichChay = lcx.MaLichChay;
                lcxx.MaXe = lcx.MaXe;
                lcxx.fl_NgaySua = lcx.fl_NgaySua;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool capNhatTrangThaiLichChay_Xe(string maLichChayXe)
        {
            try
            {
                LichChay_Xe lcxx = db.LichChay_Xes.Where(lc => lc.MaLichChay_Xe.Equals(maLichChayXe) && lc.fl_Xoa.Equals(0)).FirstOrDefault();
                lcxx.TrangThai = 1;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int laySoLuongLichChay_Xe()
        {
            return db.LichChay_Xes.Select(s => s).ToList<LichChay_Xe>().Count();
        }
    }
}
