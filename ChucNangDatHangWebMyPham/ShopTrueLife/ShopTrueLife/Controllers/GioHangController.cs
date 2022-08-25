using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopTrueLife.Models.KetNoiLinq;
using ShopTrueLife.Models.POJO;
using ShopTrueLife.Models.DAO;
using Microsoft.VisualBasic;

namespace ShopTrueLife.Controllers
{
    public class GioHangController : Controller
    {
        //
        // GET: /GioHang/
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();
        TaiKhoan tk = new TaiKhoan();
        daoGioHang daoGH = new daoGioHang();
        WebMsgBox bb = new WebMsgBox();
        //Phuong thuc lay gio hang
        public List<GioHang> layGioHang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang == null)
            {
                listGioHang = new List<GioHang>();
                Session["GioHang"] = listGioHang;
            }
            return listGioHang;
        }
        //Xay dung phuong thuc them vao gio hang
        public ActionResult themGioHang(int ma)
        {
            List<GioHang> listGioHang = layGioHang();
            //Kiem tra san pham co trong gio hang hay khong neu co thi tang so luong
            // con khong co thi them vao gio hang
            GioHang kiemTraSP = listGioHang.Find(sp => sp.iMaSP.Equals(ma));
            int soLuongCon = daoGH.laySoLuongSP(ma);
            if (kiemTraSP == null)
            {
                if(soLuongCon<1)
                {
                    //bb.Show("Số lượng sản phẩm không đủ để bán");
                    return RedirectToAction("UserSanPham", "User");
                }
                kiemTraSP = new GioHang(ma);
                listGioHang.Add(kiemTraSP);
                //bb.Show("Thêm vào giỏ hàng thành công");
                return RedirectToAction("UserSanPham", "User");
            }
            else
            {
                if(soLuongCon<kiemTraSP.iSoLuong + 1)
                {
                    //bb.Show("Số lượng sản phẩm không đủ để bán");
                    return RedirectToAction("UserSanPham", "User");
                }
                kiemTraSP.iSoLuong++;
                //bb.Show("Thêm vào giỏ hàng thành công");
                return RedirectToAction("UserSanPham", "User");
            }
        }
        //Phuong thuc tinh tong so luong
        private int tongSoLuong()
        {
            int soLuong = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                soLuong = listGioHang.Sum(sp => sp.iSoLuong);
            }
            return soLuong;
        }
        //Tinh tong thanh tien
        public double tinhTongThanhTien()
        {
            double tongThanhTien = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                tongThanhTien += listGioHang.Sum(sp => sp.dThanhTien);
            }
            return tongThanhTien;
        }
        //Xay dung cho trang gio hang
        public ActionResult GioHang()
        {
            var user = new KhachHang();
            if (Session["User"] != null)
            {
                user = Session["User"] as KhachHang;
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("UserSanPham", "User");
            }
            List<GioHang> listGioHang = layGioHang();
            ViewBag.TongSoLuong = tongSoLuong();
            ViewBag.TongThanhTien = tinhTongThanhTien();
            return View(listGioHang);
        }

        //Xoa mot san pham khoi gio hang
        public ActionResult xoaGioHang(int MaSP)
        {
            List<GioHang> lstGH = layGioHang();
            GioHang sp = lstGH.Single(s => s.iMaSP == MaSP);

            if (sp != null)
            {
                lstGH.RemoveAll(s => s.iMaSP == MaSP);
                return RedirectToAction("GioHang", "GioHang");
            }
            if (lstGH.Count == 0)
            {
                return RedirectToAction("UserSanPham", "User");
            }
            return RedirectToAction("GioHang", "GioHang");
        }
        //Xoa tat ca san pham trong gio hang
        public ActionResult xoaGioHang_All()
        {
            List<GioHang> lstGH = layGioHang();
            if (lstGH != null)
            {
                lstGH.Clear();
                return RedirectToAction("UserSanPham", "User");
            }
            if (lstGH.Count == 0)
            {
                return RedirectToAction("UserSanPham", "User");
            }
            return RedirectToAction("UserSanPham", "User");
        }

        //Cap nhat so luong cua san pham trong gio hang
        public ActionResult capNhatGioHang(int MaSP, FormCollection f)
        {
            List<GioHang> lstGH = layGioHang();
            GioHang sp = lstGH.Single(s => s.iMaSP == MaSP);
            if (sp != null)
            {
                sp.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang", "GioHang");
        }

        //Dat hang
        public ActionResult DatHang()
        {
            //Lấy danh sách sản phẩm của Khách Hàng đặt mua
            List<GioHang> lstGH = layGioHang();
            //Lấy thông tin của khách hàng
            var user = new KhachHang();
            if (Session["User"] != null)
            {
                user = Session["User"] as KhachHang;
            }
            //Nếu chưa có thông tin của Khách Hàng thì đến trang đăng nhập cho Khách Hàng đăng nhập
            if(user == null)
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            else
            {
                //Tạo một hoá đơn bán hàng
                HoaDonBanHang hd = new HoaDonBanHang();
                hd.NgayMuaHang = DateTime.Now;
                hd.TrangThai = 0;
                hd.ID_NhanVien = null;
                hd.ID_KhachHang = user.ID_KhachHang;
                //Gọi phương thức thêm hoá đơn bán hàng với tham số là một hoá đơn bán hàng
                daoGH.themHoaDonBanHang(hd);
                //Lấy mã hoá đơn bán hàng
                int MaHoaDon = daoGH.xuatMaHoaDonBanHang();
                //Duyệt hết danh sách sản phẩm khách hàng cần mua để thêm vào chi tiết bán hàng
                foreach(var item in lstGH)
                {
                    //Tạo một chi tiết hoá đơn bán hàng
                    ChiTietHoaDonBanHang cthd = new ChiTietHoaDonBanHang();
                    cthd.ID_HoaDonBanHang = MaHoaDon;
                    cthd.ID_SanPham = item.iMaSP;
                    cthd.SoLuong = item.iSoLuong;
                    cthd.Gia = item.dDonGia;
                    //Gọi phương thức thêm chi tiết hoá đơn bán hàng với tham số là một chi tiết hoá đơn bán hàng
                    daoGH.themChiTietHoaDonBanHang(cthd);
                    //Cập nhật số lượng tồn kho
                    daoGH.capNhatSoLuong(item.iMaSP, item.iSoLuong);
                }
            }
            //Sau khi đặt hàng thành công thì xoá hết tất cả trong giỏ hàng
            return RedirectToAction("XoaGioHang_All", "GioHang");
        }

        public ActionResult DanhSachDonHang()
        {
            return View();
        }
    }
}
