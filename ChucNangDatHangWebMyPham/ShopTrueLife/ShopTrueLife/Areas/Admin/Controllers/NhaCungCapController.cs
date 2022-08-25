using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrueLife.Models.KetNoiLinq;
using ShopTrueLife.Areas.Admin.Models;

namespace ShopTrueLife.Areas.Admin.Controllers
{
    public class NhaCungCapController : Controller
    {
        //
        // GET: /Admin/NhaCungCap/
        mdNhaCungCap md = new mdNhaCungCap();
        public ActionResult ShowNhaCungCap()
        {
            return View(md.xuatDanhSachNhaCungCap());
        }

        public ActionResult ThemNhaCungCap(string TenNhaCungCap, string DiaChi, string DienThoai)
        {
            if(TenNhaCungCap == null || DiaChi == null)
            {
                return View(TenNhaCungCap, DiaChi);
            }
            else
            {
                NhaCungCap n = new NhaCungCap();
                n.TenNhaCungCap = TenNhaCungCap;
                n.DiaChi = DiaChi;
                md.themNCC(n);
                DienThoai_NhaCungCap dt = new DienThoai_NhaCungCap();
                dt.ID_NhaCungCap = md.xuatMaNhaCungCap();
                dt.SoDienThoai = DienThoai;
                md.themSDTNCC(dt);
                return RedirectToAction("ShowNhaCungCap", "NhaCungCap");
            }
        }

    }
}
