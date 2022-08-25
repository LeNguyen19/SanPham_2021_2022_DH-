using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopTrueLife.Models.KetNoiLinq;

namespace ShopTrueLife.Areas.Admin.Models
{
    public class mdNhaCungCap
    {
        QuanLyMyPhamLinQDataContext db = new QuanLyMyPhamLinQDataContext();
        public mdNhaCungCap()
        {

        }

        public List<pojoNhaCungCap> xuatDanhSachNhaCungCap()
        {
            List<NhaCungCap> list = db.NhaCungCaps.Select(s => s).ToList();

            List<pojoNhaCungCap> listNCC = new List<pojoNhaCungCap>();
            foreach(NhaCungCap s in list)
            {
                pojoNhaCungCap n = new pojoNhaCungCap(s.ID_NhaCungCap,s.TenNhaCungCap,s.DiaChi);
                listNCC.Add(n);
            }
            return listNCC;
        }

        public bool themNCC(NhaCungCap ncc)
        {
            try
            {
                db.NhaCungCaps.InsertOnSubmit(ncc);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool themSDTNCC(DienThoai_NhaCungCap dt)
        {
            try
            {
                db.DienThoai_NhaCungCaps.InsertOnSubmit(dt);
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public int xuatMaNhaCungCap()
        {
            return db.NhaCungCaps.Select(s => s).Count();
        }
    }
}