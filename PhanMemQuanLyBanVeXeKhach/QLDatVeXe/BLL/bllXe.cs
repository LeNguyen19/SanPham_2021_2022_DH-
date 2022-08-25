using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class bllXe
    {
        dalXe dalXe = new dalXe();
        public bllXe()
        {

        }
        public bool themXe(Xe x)
        {
            return dalXe.themXe(x);
        }

        public bool xoaXe(string maXe)
        {
            return dalXe.xoaXe(maXe);
        }

        public bool suaXe(Xe x)
        {
            return dalXe.suaXe(x);
        }
        public List<Model_Xe> xuatListXe()
        {
            return dalXe.xuatListXe();
        }

        public string xuatBienSo(string maXe)
        {
            return dalXe.xuatBienSo(maXe);
        }
    }
}
