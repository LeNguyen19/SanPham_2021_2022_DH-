using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopTrueLife.Models.KetNoiLinq;

namespace ShopTrueLife.Areas.Admin.Models
{
    public class DAODonHang
    {
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();
        public DAODonHang()
        {

        }

        public bool CapNhatTrangThaiDonHang(int MaHoaDon)
        {
            try
            {
                HoaDonBanHang hd = db.HoaDonBanHangs.Where(s => s.ID_HoaDonBanHang.Equals(MaHoaDon)).Select(k => k).FirstOrDefault();
                if(hd.TrangThai >=4 && hd.TrangThai<0)
                {
                    return false;
                }
                else
                {
                    hd.TrangThai = hd.TrangThai + 1;
                    db.SubmitChanges();
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}