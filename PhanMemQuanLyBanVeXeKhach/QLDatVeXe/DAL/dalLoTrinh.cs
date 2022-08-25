using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalLoTrinh
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalLoTrinh()
        {

        }

        public List<string> listDiemDi()
        {
            return db.LoTrinhs.Where(lt=>lt.fl_Xoa.Equals(0)).Select(x => x.DiemDi).Distinct().ToList();
        }

        public List<string> listDiemDen(string diemDi)
        {
            return db.LoTrinhs.Where(x => x.DiemDi.Equals(diemDi) && x.fl_Xoa.Equals(0)).Select(d => d.DiemDen).Distinct().ToList();
        }

        public string layMaLoTrinh(string diemDi, string diemDen)
        {
            return db.LoTrinhs.Where(x => x.DiemDi.Equals(diemDi) && x.DiemDen.Equals(diemDen) && x.fl_Xoa.Equals(0)).Select(d => d.MaLoTrinh).FirstOrDefault();
        }

        public int layDonGiaLoTrinh(string maLichChay)
        {
            var giaVe = from lc in db.LichChays
                        join lt in db.LoTrinhs on lc.MaLoTrinh equals lt.MaLoTrinh
                        where lc.MaLichChay.Equals(maLichChay) && lt.fl_Xoa == 0 && lc.fl_Xoa == 0
                        select new { lt.GiaVe };
            int gia = 0;
            foreach(var item in giaVe)
            {
                gia = item.GiaVe;
            }
            return gia;
        }

        public List<LoTrinh> xuatAllLoTrinh()
        {
            return db.LoTrinhs.Where(lt => lt.fl_Xoa == 0).Select(s => s).ToList<LoTrinh>();
        }

        public bool themLoTrinh(LoTrinh lt)
        {
            try
            {
                db.LoTrinhs.InsertOnSubmit(lt);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool xoaLoTrinh(string maLoTrinh)
        {
            try
            {
                LoTrinh lt = db.LoTrinhs.Where(f => f.MaLoTrinh.Equals(maLoTrinh)).FirstOrDefault();

                lt.fl_Xoa = 1;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool suaLoTrinh(LoTrinh lt)
        {
            try
            {
                LoTrinh xn = db.LoTrinhs.Where(f => f.MaLoTrinh.Equals(lt.MaLoTrinh)).FirstOrDefault();
                xn.DiemDi = lt.DiemDi;
                xn.DiemDen = lt.DiemDen;
                xn.GiaVe = lt.GiaVe;
                xn.QuangDuong = lt.QuangDuong;
                xn.fl_NgaySua = lt.fl_NgaySua;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
