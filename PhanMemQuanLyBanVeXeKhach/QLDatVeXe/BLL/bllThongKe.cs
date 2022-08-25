using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class bllThongKe
    {
        dalThongKe dal = new dalThongKe();
        public bllThongKe()
        {

        }
        public List<LichChay> layDanhSachLichChayTheoNam(int nam)
        {
            return dal.layDanhSachLichChayTheoNam(nam);
        }

        public List<LichChay_Xe> layDanhSachLichChayXeTheoLichChay(int thang, LichChay lc)
        {
            return dal.layDanhSachLichChayXeTheoLichChay(thang, lc);
        }

        public List<VeXe> layDanhSachVeXeTheoLichChayXe(LichChay_Xe lcx)
        {
            return dal.layDanhSachVeXeTheoLichChayXe(lcx);
        }

        public int soVe(VeXe vx)
        {
            return dal.soVe(vx);
        }
    }
}
