using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalTrungChuyen
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalTrungChuyen()
        {

        }

        public List<TrungChuyen> ShowDanhSachTrungChuyenTheoMa(string maDCTC)
        {
            return db.TrungChuyens.Where(s => s.MaDiaChiTrungChuyen.Equals(maDCTC) && s.fl_Xoa.Equals(0)).Select(k => k).ToList();
        }

        public List<string> ShowDiemDi(string maDCTC)
        {
            return db.TrungChuyens.Where(s => s.MaDiaChiTrungChuyen.Equals(maDCTC) && s.fl_Xoa.Equals(0)).Select(k => k.DiemDi).Distinct().ToList();
        }
        public List<string> ShowDiemDen(string maDCTC)
        {
            return db.TrungChuyens.Where(s => s.MaDiaChiTrungChuyen.Equals(maDCTC) && s.fl_Xoa.Equals(0)).Select(k => k.DiemDen).Distinct().ToList();
        }
    }
}
