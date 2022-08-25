using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalChiTietVeXe
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalChiTietVeXe()
        {

        }

        public List<string> listViTriGheDuaTrenMaLichChay_Xe(string maLichChayXe)
        {
            var list = from ctvx in db.ChiTietVeXes
                       join vx in db.VeXes on ctvx.MaVeXe equals vx.MaVeXe
                       where vx.MaLichChay_Xe.Equals(maLichChayXe)
                       where vx.fl_Xoa.Equals(0)
                       select new { ctvx.GheNgoi };

            List<string> listViTriGhe = new List<string>();
            foreach(var item in list)
            {
                string s = item.GheNgoi;
                listViTriGhe.Add(s);
            }
            return listViTriGhe;
        }

        public bool themChiTietVeXe(ChiTietVeXe ctvx)
        {
            try
            {
                db.ChiTietVeXes.InsertOnSubmit(ctvx);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<Model_DanhSachVe> layDanhSachVe(string maLichChay_Xe, string maLichChay)
        {
            var list = from kh in db.KhachHangs
                       join vx in db.VeXes on kh.MaKhachHang equals vx.MaKhachHang
                       join ctvx in db.ChiTietVeXes on vx.MaVeXe equals ctvx.MaVeXe
                       join lcx in db.LichChay_Xes on vx.MaLichChay_Xe equals lcx.MaLichChay_Xe
                       where kh.fl_Xoa == 0 && vx.fl_Xoa == 0 && lcx.fl_Xoa == 0
                       where vx.MaLichChay_Xe.Equals(maLichChay_Xe) && lcx.MaLichChay.Equals(maLichChay)
                       select new { vx.MaVeXe, vx.DonGia, kh.TenKhachHang, kh.DienThoai, ctvx.GheNgoi };

            List<Model_DanhSachVe> listDSV = new List<Model_DanhSachVe>();
            foreach(var i in list)
            {
                Model_DanhSachVe md = new Model_DanhSachVe();
                md.MaVeXe = i.MaVeXe;
                md.DonGia = i.DonGia;
                md.TenKhachHang = i.TenKhachHang;
                md.DienThoai = i.DienThoai;
                md.GheNgoi = i.GheNgoi;
                listDSV.Add(md);
            }

            return listDSV;
        }

        public List<Model_DanhSachVe> timKiemDanhSachVe(string maLichChay_Xe, string maLichChay, string tenKhachHang)
        {
            var list = from kh in db.KhachHangs
                       join vx in db.VeXes on kh.MaKhachHang equals vx.MaKhachHang
                       join ctvx in db.ChiTietVeXes on vx.MaVeXe equals ctvx.MaVeXe
                       join lcx in db.LichChay_Xes on vx.MaLichChay_Xe equals lcx.MaLichChay_Xe
                       where kh.fl_Xoa == 0 && vx.fl_Xoa == 0 && lcx.fl_Xoa == 0
                       where vx.MaLichChay_Xe.Equals(maLichChay_Xe) && lcx.MaLichChay.Equals(maLichChay)
                       where kh.TenKhachHang.Contains(tenKhachHang)
                       select new { vx.MaVeXe, vx.DonGia, kh.TenKhachHang, kh.DienThoai, ctvx.GheNgoi };

            List<Model_DanhSachVe> listDSV = new List<Model_DanhSachVe>();
            foreach (var i in list)
            {
                Model_DanhSachVe md = new Model_DanhSachVe();
                md.MaVeXe = i.MaVeXe;
                md.DonGia = i.DonGia;
                md.TenKhachHang = i.TenKhachHang;
                md.DienThoai = i.DienThoai;
                md.GheNgoi = i.GheNgoi;
                listDSV.Add(md);
            }

            return listDSV;
        }

        public bool xoaChiTietVeXe(ChiTietVeXe ctvx)
        {
            try
            {
                ChiTietVeXe c = db.ChiTietVeXes.Where(ct => ct.MaVeXe.Equals(ctvx.MaVeXe) && ct.GheNgoi.Equals(ctvx.GheNgoi)).FirstOrDefault();
                db.ChiTietVeXes.DeleteOnSubmit(c);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
