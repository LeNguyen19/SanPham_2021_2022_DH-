using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalTaiKhoan
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalTaiKhoan()
        {

        }

        public List<Model_ListTaiKhoan> xuatListTaiKhoan()
        {
            var listTaiKhoanNhanVien = from nv in db.NhanViens
                                       join tk in db.TaiKhoans on nv.TenDangNhap equals tk.TenDangNhap
                                       join ltk in db.LoaiTaiKhoans on tk.MaLoaiTaiKhoan equals ltk.MaLoaiTaiKhoan
                                       where nv.fl_Xoa == 0
                                       where tk.fl_Xoa == 0
                                       select new { nv.MaNhanVien, nv.TenNhanVien, tk.TenDangNhap, tk.MatKhau, tk.MaLoaiTaiKhoan, ltk.TenLoaiTaiKhoan };
            var listTaiKhoanKhachHang = from kh in db.KhachHangs
                                       join tk in db.TaiKhoans on kh.TenDangNhap equals tk.TenDangNhap
                                       join ltk in db.LoaiTaiKhoans on tk.MaLoaiTaiKhoan equals ltk.MaLoaiTaiKhoan
                                       where kh.fl_Xoa == 0
                                       where tk.fl_Xoa == 0
                                       select new { kh.MaKhachHang, kh.TenKhachHang, tk.TenDangNhap, tk.MatKhau, tk.MaLoaiTaiKhoan, ltk.TenLoaiTaiKhoan };

            List<Model_ListTaiKhoan> listTaiKhoan = new List<Model_ListTaiKhoan>();
            foreach(var item in listTaiKhoanNhanVien)
            {
                Model_ListTaiKhoan tk = new Model_ListTaiKhoan();
                tk.MaNguoiDung = item.MaNhanVien;
                tk.TenNguoiDung = item.TenNhanVien;
                tk.TenDangNhap = item.TenDangNhap;
                tk.MatKhau = item.MatKhau;
                tk.MaLoaiTaiKhoan = item.MaLoaiTaiKhoan;
                tk.TenLoaiTaiKhoan = item.TenLoaiTaiKhoan;

                listTaiKhoan.Add(tk);
            }
            foreach (var item in listTaiKhoanKhachHang)
            {
                Model_ListTaiKhoan tk = new Model_ListTaiKhoan();
                tk.MaNguoiDung = item.MaKhachHang;
                tk.TenNguoiDung = item.TenKhachHang;
                tk.TenDangNhap = item.TenDangNhap;
                tk.MatKhau = item.MatKhau;
                tk.MaLoaiTaiKhoan = item.MaLoaiTaiKhoan;
                tk.TenLoaiTaiKhoan = item.TenLoaiTaiKhoan;

                listTaiKhoan.Add(tk);
            }
            return listTaiKhoan;
        }

        public TaiKhoan xuatTaiKhoan(string TenDangNhap)
        {
            return db.TaiKhoans.Where(tk => tk.TenDangNhap.Equals(TenDangNhap) && tk.fl_Xoa == 0).FirstOrDefault();
        }

        public List<Model_ListTaiKhoan> xuatTaiKhoanTheoLoai(int MaLoaiTaiKhoan)
        {
            var listTaiKhoanNhanVien = from nv in db.NhanViens
                                       join tk in db.TaiKhoans on nv.TenDangNhap equals tk.TenDangNhap
                                       join ltk in db.LoaiTaiKhoans on tk.MaLoaiTaiKhoan equals ltk.MaLoaiTaiKhoan
                                       where nv.fl_Xoa == 0
                                       where tk.fl_Xoa == 0
                                       where tk.MaLoaiTaiKhoan == MaLoaiTaiKhoan
                                       select new { nv.MaNhanVien, nv.TenNhanVien, tk.TenDangNhap, tk.MatKhau, tk.MaLoaiTaiKhoan, ltk.TenLoaiTaiKhoan };
            var listTaiKhoanKhachHang = from kh in db.KhachHangs
                                        join tk in db.TaiKhoans on kh.TenDangNhap equals tk.TenDangNhap
                                        join ltk in db.LoaiTaiKhoans on tk.MaLoaiTaiKhoan equals ltk.MaLoaiTaiKhoan
                                        where kh.fl_Xoa == 0
                                        where tk.fl_Xoa == 0
                                        where tk.MaLoaiTaiKhoan == MaLoaiTaiKhoan
                                        select new { kh.MaKhachHang, kh.TenKhachHang, tk.TenDangNhap, tk.MatKhau, tk.MaLoaiTaiKhoan, ltk.TenLoaiTaiKhoan };

            List<Model_ListTaiKhoan> listTaiKhoan = new List<Model_ListTaiKhoan>();
            foreach (var item in listTaiKhoanNhanVien)
            {
                Model_ListTaiKhoan tk = new Model_ListTaiKhoan();
                tk.MaNguoiDung = item.MaNhanVien;
                tk.TenNguoiDung = item.TenNhanVien;
                tk.TenDangNhap = item.TenDangNhap;
                tk.MatKhau = item.MatKhau;
                tk.MaLoaiTaiKhoan = item.MaLoaiTaiKhoan;
                tk.TenLoaiTaiKhoan = item.TenLoaiTaiKhoan;

                listTaiKhoan.Add(tk);
            }
            foreach (var item in listTaiKhoanKhachHang)
            {
                Model_ListTaiKhoan tk = new Model_ListTaiKhoan();
                tk.MaNguoiDung = item.MaKhachHang;
                tk.TenNguoiDung = item.TenKhachHang;
                tk.TenDangNhap = item.TenDangNhap;
                tk.MatKhau = item.MatKhau;
                tk.MaLoaiTaiKhoan = item.MaLoaiTaiKhoan;
                tk.TenLoaiTaiKhoan = item.TenLoaiTaiKhoan;

                listTaiKhoan.Add(tk);
            }
            return listTaiKhoan;
        }

        public bool ThemTaiKhoan(TaiKhoan tk)
        {
            try
            {
                db.TaiKhoans.InsertOnSubmit(tk);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool SuaTaiKhoan(TaiKhoan tk)
        {
            try
            {
                TaiKhoan taiKhoan = db.TaiKhoans.Where(tkh => tkh.TenDangNhap.Equals(tk.TenDangNhap)).FirstOrDefault();
                
                taiKhoan.MatKhau = tk.MatKhau;
                taiKhoan.MaLoaiTaiKhoan = tk.MaLoaiTaiKhoan;
                taiKhoan.fl_NgayThem = taiKhoan.fl_NgayThem;
                taiKhoan.fl_NgaySua = tk.fl_NgaySua;
                taiKhoan.fl_Xoa = taiKhoan.fl_Xoa;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaTaiKhoan(string TenDangNhap)
        {
            try
            {
                TaiKhoan taiKhoan = db.TaiKhoans.Where(tkh => tkh.TenDangNhap.Equals(TenDangNhap)).FirstOrDefault();

                taiKhoan.fl_Xoa = 1;
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
