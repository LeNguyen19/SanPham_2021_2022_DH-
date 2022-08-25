using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrueLife.Models.KetNoiLinq;
using ShopTrueLife.Models.POJO;

namespace ShopTrueLife.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();

        public ActionResult UserTrangChu()
        {
            return View();
        }

        public ActionResult UserGioiThieu()
        {
            return View();
        }

        public ActionResult UserSanPham()
        {
            var sp1 = from sp in db.SanPhams
                      join ha in db.HinhAnhs on sp.ID_SanPham equals ha.ID_SanPham
                      where ha.TrangThai == 1
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

        public ActionResult UserUuDai()
        {
            var sp1 = from sp in db.SanPhams
                      join ha in db.HinhAnhs on sp.ID_SanPham equals ha.ID_SanPham
                      join ggsp in db.GiamGiaSanPhams on sp.ID_SanPham equals ggsp.ID_SanPham
                      where ha.TrangThai == 1
                      select new { sp.ID_SanPham, ha.DuongDanHinh, sp.TenSanPham, sp.GiaBan, ggsp.SoPhanTram };
            List<GiamGiaTheoSanPham> tsp = new List<GiamGiaTheoSanPham>();
            foreach (var item in sp1)
            {
                GiamGiaTheoSanPham s = new GiamGiaTheoSanPham();
                s.iID_SanPham = item.ID_SanPham;
                s.sAnhBia = item.DuongDanHinh;
                s.sTenSanPham = item.TenSanPham;
                s.iGiaBan = item.GiaBan;
                s.iGiaDaGiam = item.GiaBan - ((item.GiaBan * item.SoPhanTram) / 100);
                s.iSoPhanTram = item.SoPhanTram;
                tsp.Add(s);
            }
            return View(tsp);
        }

        public ActionResult UserTinTuc()
        {
            return View();
        }

        public ActionResult UserLienHe()
        {
            return View();
        }

    }
}
