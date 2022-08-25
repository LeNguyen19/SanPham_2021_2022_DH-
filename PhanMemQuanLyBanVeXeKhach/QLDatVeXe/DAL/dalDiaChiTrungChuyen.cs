using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalDiaChiTrungChuyen
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalDiaChiTrungChuyen()
        {

        }

        public List<DiaChiTrungChuyen> ShowDanhSachDiaChi()
        {
            return db.DiaChiTrungChuyens.Where(dc => dc.fl_Xoa.Equals(0)).Select(K => K).ToList();
        }
    }
}
