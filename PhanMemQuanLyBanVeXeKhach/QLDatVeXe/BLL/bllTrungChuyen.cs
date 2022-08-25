using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class bllTrungChuyen
    {
        dalTrungChuyen dal = new dalTrungChuyen();
        public bllTrungChuyen()
        {

        }
        public List<TrungChuyen> ShowDanhSachTrungChuyenTheoMa(string maDCTC)
        {
            return dal.ShowDanhSachTrungChuyenTheoMa(maDCTC);
        }
        public List<string> ShowDiemDi(string maDCTC)
        {
            return dal.ShowDiemDi(maDCTC);
        }
        public List<string> ShowDiemDen(string maDCTC)
        {
            return dal.ShowDiemDen(maDCTC);
        }
    }
}
