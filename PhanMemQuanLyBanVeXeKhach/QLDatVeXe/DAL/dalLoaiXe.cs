using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalLoaiXe
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalLoaiXe()
        {

        }

        public List<LoaiXe> xuatListLoaiXe()
        {
            return db.LoaiXes.Where(s => s.fl_Xoa == 0).Select(lx => lx).ToList<LoaiXe>();
        }
    }
}
