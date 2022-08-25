using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalLichChay
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalLichChay()
        {

        }

        public List<string> layGioLichChay(DateTime ngayKhoiHanh, string maLoTrinh)
        {
            return db.LichChays.Where(lc => lc.NgayKhoiHanh.Day.Equals(ngayKhoiHanh.Day) && lc.NgayKhoiHanh.Month.Equals(ngayKhoiHanh.Month) && lc.NgayKhoiHanh.Year.Equals(ngayKhoiHanh.Year) && lc.MaLoTrinh.Equals(maLoTrinh) && lc.fl_Xoa.Equals(0)).Select(d => d.GioKhoiHanh).ToList();
        }

        public string layMaLichChay(DateTime ngayKhoiHanh, string maLoTrinh, string gioKhoiHanh)
        {
            return db.LichChays.Where(lc => lc.NgayKhoiHanh.Day.Equals(ngayKhoiHanh.Day) && lc.NgayKhoiHanh.Month.Equals(ngayKhoiHanh.Month) && lc.NgayKhoiHanh.Year.Equals(ngayKhoiHanh.Year) && lc.MaLoTrinh.Equals(maLoTrinh) && lc.fl_Xoa.Equals(0) && lc.GioKhoiHanh.Equals(gioKhoiHanh)).Select(d => d.MaLichChay).FirstOrDefault();
        }

        public bool themLichChay(LichChay lc)
        {
            try
            {
                db.LichChays.InsertOnSubmit(lc);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool xoaLichChay(string maLichChay)
        {
            try
            {
                LichChay lc = db.LichChays.Where(f => f.MaLichChay.Equals(maLichChay)).FirstOrDefault();

                lc.fl_Xoa = 1;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool suaLichChay(LichChay lc)
        {
            try
            {
                LichChay xn = db.LichChays.Where(f => f.MaLichChay.Equals(lc.MaLichChay)).FirstOrDefault();
                xn.NgayKhoiHanh = lc.NgayKhoiHanh;
                xn.GioKhoiHanh = lc.GioKhoiHanh;
                xn.MaLoTrinh = lc.MaLoTrinh;
                xn.MaNhanVien = lc.MaNhanVien;
                xn.fl_NgaySua = lc.fl_NgaySua;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Model_LichChay> xuatListLichChayNV()
        {
            var list = from lc in db.LichChays
                       join nv in db.NhanViens on lc.MaNhanVien equals nv.MaNhanVien
                       where lc.fl_Xoa.Equals(0) && nv.fl_Xoa.Equals(0)
                       select new { lc.MaLichChay, lc.NgayKhoiHanh, lc.GioKhoiHanh, lc.MaLoTrinh, nv.TenNhanVien, lc.fl_NgayThem, lc.fl_NgaySua };
            List<Model_LichChay> listLC = new List<Model_LichChay>();
            foreach(var i in list)
            {
                Model_LichChay lc = new Model_LichChay();
                lc.MaLichChay = i.MaLichChay;
                lc.NgayKhoiHanh = i.NgayKhoiHanh;
                lc.GioKhoiHanh = i.GioKhoiHanh;
                lc.MaLoTrinh = i.MaLoTrinh;
                lc.TenNhanVien = i.TenNhanVien;
                lc.fl_NgayThem = i.fl_NgayThem;
                lc.fl_NgaySua = i.fl_NgaySua;
                listLC.Add(lc);
            }
            return listLC;
        }

        public List<Model_LichChay_LoTrinh> xuatListLichChay_LoTrinh()
        {
            var list = from lc in db.LichChays
                       join lt in db.LoTrinhs on lc.MaLoTrinh equals lt.MaLoTrinh
                       join nv in db.NhanViens on lc.MaNhanVien equals nv.MaNhanVien
                       where lc.fl_Xoa.Equals(0) && lt.fl_Xoa.Equals(0) && nv.MaLoaiNhanVien.Equals(3)
                       select new { lc.MaLichChay, lc.NgayKhoiHanh, lc.GioKhoiHanh, lc.MaLoTrinh, lt.DiemDi, lt.DiemDen, nv.TenNhanVien };
            List<Model_LichChay_LoTrinh> listLC = new List<Model_LichChay_LoTrinh>();
            foreach (var i in list)
            {
                Model_LichChay_LoTrinh lc = new Model_LichChay_LoTrinh();
                lc.MaLichChay = i.MaLichChay;
                lc.NgayKhoiHanh = i.NgayKhoiHanh;
                lc.GioKhoiHanh = i.GioKhoiHanh;
                lc.MaLoTrinh = i.MaLoTrinh;
                lc.DiemDi = i.DiemDi;
                lc.DiemDen = i.DiemDen;
                lc.TenNhanVien = i.TenNhanVien;
                listLC.Add(lc);
            }
            return listLC;
        }
    }
}
