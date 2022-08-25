using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopTrueLife.Models.KetNoiLinq;

namespace ShopTrueLife.Models.DAO
{
    public class daoGioHang
    {
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();
        public daoGioHang()
        {

        }
        //Lấy mã hoá đơn để thêm vào chi tiết hoá đơn
        public int xuatMaHoaDonBanHang()
        {
            return db.HoaDonBanHangs.Select(s => s).Count();
        }
        //thêm một hoá đơn vào hoá đơn bán hàng
        public bool themHoaDonBanHang(HoaDonBanHang hd)
        {
            try
            {
                db.HoaDonBanHangs.InsertOnSubmit(hd);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        //thêm chi tiết hoá đơn vào chi tiết hoá đơn bán hàng
        public bool themChiTietHoaDonBanHang(ChiTietHoaDonBanHang cthd)
        {
            try
            {
                db.ChiTietHoaDonBanHangs.InsertOnSubmit(cthd);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        //Cập nhật số lượng tồn
        public bool capNhatSoLuong(int MaSP, int soLuongMua)
        {
            try
            {
                SanPham sp = db.SanPhams.Where(s => s.ID_SanPham.Equals(MaSP)).Select(k => k).FirstOrDefault();
                sp.SoLuong = sp.SoLuong - soLuongMua;
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        //Lấy số lượng của sản phẩm
        public int laySoLuongSP(int ma)
        {
            return db.SanPhams.Where(sp => sp.ID_SanPham.Equals(ma)).Select(s => s.SoLuong).FirstOrDefault();
        }
    }
}