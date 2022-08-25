using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class bllLoaiXe
    {
        dalLoaiXe dalLoaiXe = new dalLoaiXe();
        public bllLoaiXe()
        {

        }
        public List<LoaiXe> xuatListLoaiXe()
        {
            return dalLoaiXe.xuatListLoaiXe();
        }
    }
}
