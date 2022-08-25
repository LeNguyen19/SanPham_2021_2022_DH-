using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopTrueLife.Models.KetNoiLinq;

namespace ShopTrueLife.Areas.Admin.Models
{
    public class mdNhapHang
    {
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();
        public mdNhapHang()
        {

        }

        public List<pojoSanPham> xuatListSanPham()
        {
            List<SanPham> s1 = db.SanPhams.Select(sn => sn).ToList();
            List<pojoSanPham> tsp = new List<pojoSanPham>();
            foreach (SanPham i in s1)
            {
                string duongDan = db.HinhAnhs.Where(hs => hs.ID_SanPham.Equals(i.ID_SanPham) && hs.TrangThai == 1).Select(l => l.DuongDanHinh).FirstOrDefault();
                    
                if (duongDan != null)
                {
                    pojoSanPham sa = new pojoSanPham();
                    sa.iID_SanPham = i.ID_SanPham;
                    sa.sAnhBia = duongDan;
                    sa.sTenSanPham = i.TenSanPham;
                    sa.iSoLuong = i.SoLuong;
                    sa.iGiaBan = i.GiaBan;
                    sa.sMoTa = i.MoTaSanPham;
                    sa.sTenLoaiSanPham = db.LoaiSanPhams.Where(kk => kk.ID_LoaiSanPham.Equals(i.ID_LoaiSanPham)).Select(hh => hh.TenLoaiSanPham).FirstOrDefault();
                    tsp.Add(sa);
                }
                else
                {
                    pojoSanPham sa = new pojoSanPham();
                    sa.iID_SanPham = i.ID_SanPham;
                    sa.sAnhBia = null;
                    sa.sTenSanPham = i.TenSanPham;
                    sa.iSoLuong = i.SoLuong;
                    sa.iGiaBan = i.GiaBan;
                    sa.sMoTa = i.MoTaSanPham;
                    sa.sTenLoaiSanPham = db.LoaiSanPhams.Where(kk => kk.ID_LoaiSanPham.Equals(i.ID_LoaiSanPham)).Select(hh => hh.TenLoaiSanPham).FirstOrDefault();
                    tsp.Add(sa);
                }
            }
            return tsp;
        }


        public SanPham xuatSanPham(int ma)
        {
            return db.SanPhams.Where(sp => sp.ID_SanPham.Equals(ma)).Select(s=>s).FirstOrDefault();
        }

        public bool suaSanPham(SanPham sp)
        {
            try
            {
                SanPham sa = db.SanPhams.Where(k => k.ID_SanPham.Equals(sp.ID_SanPham)).Select(s=>s).FirstOrDefault();

                sa.MoTaSanPham = sp.MoTaSanPham;
                sa.GiaBan = sp.GiaBan;
                sa.SoLuong = sp.SoLuong;
                db.SubmitChanges();

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public int kiemTraSanPham(string tenSanPham, int maLoaiSanPham)
        {
            return db.SanPhams.Where(s => s.TenSanPham.Equals(tenSanPham) && s.ID_LoaiSanPham.Equals(maLoaiSanPham)).Select(h => h.ID_SanPham).FirstOrDefault();
        }

        public bool tangSLSanPham(int maSP, int sl)
        {
            try
            {
                SanPham sp = db.SanPhams.Where(s => s.ID_SanPham.Equals(maSP)).Select(ss => ss).FirstOrDefault();
                sp.SoLuong = sp.SoLuong + sl;
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public List<LoaiSanPham> xuatListLoaiSanPham()
        {
            return db.LoaiSanPhams.Select(s => s).ToList();
        }

        public bool themSanPham(SanPham sp)
        {
            try
            {
                db.SanPhams.InsertOnSubmit(sp);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool themDonNhapHang(HoaDonNhapHang nh)
        {
            try
            {
                db.HoaDonNhapHangs.InsertOnSubmit(nh);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool themChiTietDonNhapHang(ChiTietHoaDonNhapHang cthd)
        {
            try
            {
                db.ChiTietHoaDonNhapHangs.InsertOnSubmit(cthd);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int xuatMaHoaDonNhapHang()
        {
            return db.ChiTietHoaDonNhapHangs.Select(s => s).Count();
        }

        public int kiemTraMaHoaDonNhap(int ngay, int thang, int nam, int maNCC)
        {
            return db.HoaDonNhapHangs.Where(s => s.NgayNhapHang.Day.Equals(ngay) && s.NgayNhapHang.Month.Equals(thang ) && s.NgayNhapHang.Year.Equals(nam) && s.ID_NhaCungCap.Equals(maNCC)).Select(k=>k.ID_HoaDonNhapHang).FirstOrDefault();
        }

        public bool ThemHinhAnh(HinhAnh ha)
        {
            try
            {
                db.HinhAnhs.InsertOnSubmit(ha);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public int kiemTraHinhAnh(int ma)
        {
            return db.HinhAnhs.Where(h => h.ID_SanPham.Equals(ma)).Select(k => k).Count();
        }

    }
}