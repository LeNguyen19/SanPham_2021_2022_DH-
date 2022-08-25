using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class bllVeXe
    {
        dalVeXe dalVeXe = new dalVeXe();
        public bllVeXe()
        {

        }

        public bool themVeXe(VeXe vx)
        {
            return dalVeXe.themVeXe(vx);
        }
    }
}
