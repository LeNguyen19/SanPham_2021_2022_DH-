using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class bllDiaChiTrungChuyen
    {
        dalDiaChiTrungChuyen dal = new dalDiaChiTrungChuyen();
        public bllDiaChiTrungChuyen()
        {

        }
        public List<DiaChiTrungChuyen> ShowDanhSachDiaChi()
        {
            return dal.ShowDanhSachDiaChi();
        }
    }
}
