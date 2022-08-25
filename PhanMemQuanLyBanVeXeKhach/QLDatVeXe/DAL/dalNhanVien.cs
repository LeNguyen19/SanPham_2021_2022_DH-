using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalNhanVien
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalNhanVien()
        {

        }

        public List<Model_ListNhanVien> xuatListNhanVien()
        {
            var listNhanVien = from nv in db.NhanViens
                               join lnv in db.LoaiNhanViens on nv.MaLoaiNhanVien equals lnv.MaLoaiNhanVien
                               where nv.fl_Xoa == 0
                               select new { nv, lnv.TenLoaiNhanVien };
                               
                               
            List<Model_ListNhanVien> list = new List<Model_ListNhanVien>();
            foreach(var item in listNhanVien)
            {
                Model_ListNhanVien nhanVien = new Model_ListNhanVien();

                nhanVien.MaNhanVien = item.nv.MaNhanVien;
                nhanVien.TenNhanVien = item.nv.TenNhanVien;
                nhanVien.GioiTinh = item.nv.GioiTinh;
                nhanVien.NgaySinh = item.nv.NgaySinh;
                nhanVien.DienThoai = item.nv.DienThoai;
                nhanVien.CCCD = item.nv.CCCD;
                nhanVien.DiaChi = item.nv.DiaChi;
                nhanVien.TenDangNhap = item.nv.TenDangNhap;
                nhanVien.fl_NgayThem = item.nv.fl_NgayThem;
                nhanVien.fl_NgaySua = item.nv.fl_NgaySua;
                nhanVien.fl_Xoa = item.nv.fl_Xoa;
                nhanVien.TenLoaiNhanVien = item.TenLoaiNhanVien;
                list.Add(nhanVien);
            }
            return list;
        }

        public NhanVien xuatNhanVien(string MaNhanVien)
        {
            return db.NhanViens.Where(nv => nv.MaNhanVien.Equals(MaNhanVien) && nv.fl_Xoa == 0).SingleOrDefault();
        }

        public bool ThemNhanVien(NhanVien nv)
        {
            try
            {
                db.NhanViens.InsertOnSubmit(nv);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool SuaNhanVien(NhanVien nv)
        {
            try
            {
                NhanVien nhanVien = db.NhanViens.Where(n => n.MaNhanVien.Equals(nv.MaNhanVien)).FirstOrDefault();

                nhanVien.TenNhanVien = nv.TenNhanVien;
                nhanVien.GioiTinh = nv.GioiTinh;
                nhanVien.DienThoai = nv.DienThoai;
                nhanVien.CCCD = nv.CCCD;
                nhanVien.DiaChi = nv.DiaChi;
                nhanVien.MaLoaiNhanVien = nv.MaLoaiNhanVien;
                nhanVien.fl_NgaySua = nv.fl_NgaySua;
                nhanVien.fl_Xoa = nv.fl_Xoa;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool XoaNhanVien(string MaNhanVien)
        {
            try
            {
                NhanVien nhanVien = db.NhanViens.Where(n => n.MaNhanVien.Equals(MaNhanVien)).FirstOrDefault();

                nhanVien.fl_Xoa = 1;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<NhanVien> xuatListNhanVienTaiXe()
        {
            return db.NhanViens.Where(nv => nv.MaLoaiNhanVien.Equals(3) && nv.fl_Xoa == 0).Select(s=>s).ToList();
        }
    }
}
