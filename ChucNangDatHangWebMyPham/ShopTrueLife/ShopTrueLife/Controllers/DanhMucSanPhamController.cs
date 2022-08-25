using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrueLife.Models.KetNoiLinq;
using ShopTrueLife.Models.POJO;

namespace ShopTrueLife.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        //
        // GET: /DanhMucSanPham/
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();

        public ActionResult DanhMucSanPhamHome()
        {
            var listDMSPHome = db.LoaiSanPhams.OrderBy(cd => cd.TenLoaiSanPham).ToList();
            return View(listDMSPHome);
        }
        public ActionResult SanPhamTheoLoaiHome(int ma)
        {
            //var listSanPhamTheoLoaiHome = db.SanPhams.Where(sp => sp.ID_LoaiSanPham == ma).ToList();
            var sp1 = from sp in db.SanPhams
                      join ha in db.HinhAnhs on sp.ID_SanPham equals ha.ID_SanPham
                      where ha.TrangThai == 1
                      where sp.ID_LoaiSanPham == ma
                      select new { sp.ID_SanPham, ha.DuongDanHinh, sp.TenSanPham, sp.GiaBan };
            var ggtn = db.GiamGiaTheoNgays.Where(gg => gg.NgayBatDau.Year == DateTime.Now.Year && gg.NgayBatDau.Month == DateTime.Now.Month && gg.NgayBatDau.Day <= DateTime.Now.Day &&
                gg.NgayKetThuc.Year == DateTime.Now.Year && gg.NgayKetThuc.Month == DateTime.Now.Month && gg.NgayKetThuc.Day >= DateTime.Now.Day).SingleOrDefault();

            List<TrangSanPham> tsp = new List<TrangSanPham>();
            if (ggtn == null)
            {
                foreach (var item in sp1)
                {
                    TrangSanPham s = new TrangSanPham();
                    s.iID_SanPham = item.ID_SanPham;
                    s.sAnhBia = item.DuongDanHinh;
                    s.sTenSanPham = item.TenSanPham;
                    s.iGiaBan = item.GiaBan;
                    s.iGiaDaGiam = item.GiaBan;
                    tsp.Add(s);
                }
            }
            else
            {
                foreach (var item in sp1)
                {
                    TrangSanPham s = new TrangSanPham();
                    s.iID_SanPham = item.ID_SanPham;
                    s.sAnhBia = item.DuongDanHinh;
                    s.sTenSanPham = item.TenSanPham;
                    s.iGiaBan = item.GiaBan;
                    s.iGiaDaGiam = item.GiaBan - ((item.GiaBan * ggtn.SoPhanTram) / 100);
                    tsp.Add(s);
                }
            }
            return View(tsp);
        }

        public ActionResult DanhMucSanPhamUser()
        {
            var listDMSPHome = db.LoaiSanPhams.OrderBy(cd => cd.TenLoaiSanPham).ToList();
            return View(listDMSPHome);
        }
        public ActionResult SanPhamTheoLoaiUser(int ma)
        {
            //var listSanPhamTheoLoaiHome = db.SanPhams.Where(sp => sp.ID_LoaiSanPham == ma).ToList();
            var sp1 = from sp in db.SanPhams
                      join ha in db.HinhAnhs on sp.ID_SanPham equals ha.ID_SanPham
                      where ha.TrangThai == 1
                      where sp.ID_LoaiSanPham == ma
                      select new { sp.ID_SanPham, ha.DuongDanHinh, sp.TenSanPham, sp.GiaBan };
            var ggtn = db.GiamGiaTheoNgays.Where(gg => gg.NgayBatDau.Year == DateTime.Now.Year && gg.NgayBatDau.Month == DateTime.Now.Month && gg.NgayBatDau.Day <= DateTime.Now.Day &&
                gg.NgayKetThuc.Year == DateTime.Now.Year && gg.NgayKetThuc.Month == DateTime.Now.Month && gg.NgayKetThuc.Day >= DateTime.Now.Day).SingleOrDefault();

            List<TrangSanPham> tsp = new List<TrangSanPham>();
            if (ggtn == null)
            {
                foreach (var item in sp1)
                {
                    TrangSanPham s = new TrangSanPham();
                    s.iID_SanPham = item.ID_SanPham;
                    s.sAnhBia = item.DuongDanHinh;
                    s.sTenSanPham = item.TenSanPham;
                    s.iGiaBan = item.GiaBan;
                    s.iGiaDaGiam = item.GiaBan;
                    tsp.Add(s);
                }
            }
            else
            {
                foreach (var item in sp1)
                {
                    TrangSanPham s = new TrangSanPham();
                    s.iID_SanPham = item.ID_SanPham;
                    s.sAnhBia = item.DuongDanHinh;
                    s.sTenSanPham = item.TenSanPham;
                    s.iGiaBan = item.GiaBan;
                    s.iGiaDaGiam = item.GiaBan - ((item.GiaBan * ggtn.SoPhanTram) / 100);
                    tsp.Add(s);
                }
            }
            return View(tsp);
        }
    }
}
