using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalKhachHang
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalKhachHang()
        {
            
        }

        public List<KhachHang> xuatListKhachHang()
        {
            return db.KhachHangs.Where(kh => kh.fl_Xoa == 0).ToList<KhachHang>();
        }

        public bool themKhachHang(KhachHang kh)
        {
            try
            {
                db.KhachHangs.InsertOnSubmit(kh);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool suaKhachHang(KhachHang kh)
        {
            try
            {
                KhachHang khachHang = db.KhachHangs.Where(khf => khf.fl_Xoa == 0 && khf.MaKhachHang.Equals(kh.MaKhachHang)).FirstOrDefault();

                khachHang.TenKhachHang = kh.TenKhachHang;
                khachHang.GioiTinh = kh.GioiTinh;
                khachHang.NgaySinh = kh.NgaySinh;
                khachHang.DienThoai = kh.DienThoai;
                khachHang.CCCD = kh.CCCD;
                khachHang.DiaChi = kh.DiaChi;
                khachHang.TenDangNhap = kh.TenDangNhap;
                khachHang.fl_NgayThem = kh.fl_NgayThem;
                khachHang.fl_NgaySua = kh.fl_NgaySua;
                khachHang.fl_Xoa = kh.fl_Xoa;

                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool xoaKhachHang(string MaKhachHang)
        {
            try
            {
                KhachHang khachHang = db.KhachHangs.Where(khf => khf.fl_Xoa == 0 && khf.MaKhachHang.Equals(MaKhachHang)).FirstOrDefault();

                khachHang.fl_Xoa = 1;
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public KhachHang xuatKhachHang(string MaKhachHang)
        {
            return db.KhachHangs.Where(kh => kh.fl_Xoa == 0 && kh.MaKhachHang.Equals(MaKhachHang)).FirstOrDefault();
        }

        public string xuatKhachHang_SDT(string soDienThoai)
        {
            return db.KhachHangs.Where(kh => kh.fl_Xoa == 0 && kh.DienThoai.Equals(soDienThoai)).Select(s => s.MaKhachHang).FirstOrDefault();
        }
    }
}
