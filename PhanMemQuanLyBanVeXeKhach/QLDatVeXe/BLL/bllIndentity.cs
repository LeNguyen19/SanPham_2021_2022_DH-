using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class bllIndentity
    {
        dalIndentity dalIndentity = new dalIndentity();
        public bllIndentity()
        {

        }

        public int? xuatIndentityNhanVien()
        {
            return dalIndentity.xuatIndentityNhanVien();
        }

        

        public int? xuatIndentityKhachHang()
        {
            return dalIndentity.xuatIndentityKhachHang();
        }

        public int? xuatIndentityVeXe()
        {
            return dalIndentity.xuatIndentityVeXe();
        }

        public int? xuatIndentityXe()
        {
            return dalIndentity.xuatIndentityXe();
        }

        public int? xuatIndentityLoTrinh()
        {
            return dalIndentity.xuatIndentityLoTrinh();
        }

        public int? xuatIndentityLichChay()
        {
            return dalIndentity.xuatIndentityLichChay();
        }

        public int? xuatIndentityLichChay_Xe()
        {
            return dalIndentity.xuatIndentityLichChay_Xe();
        }
    }
}
