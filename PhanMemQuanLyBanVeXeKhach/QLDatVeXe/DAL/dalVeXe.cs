using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalVeXe
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalVeXe()
        {

        }
        
        public bool themVeXe(VeXe vx)
        {
            try
            {
                db.VeXes.InsertOnSubmit(vx);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
