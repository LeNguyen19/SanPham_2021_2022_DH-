using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class bllLoaiNhanVien
    {
        dalLoaiNhanVien dalLoaiNhanVien = new dalLoaiNhanVien();
        public bllLoaiNhanVien()
        {

        }
        public List<LoaiNhanVien> xuatListLoaiNhanVien()
        {
            return dalLoaiNhanVien.xuatListLoaiNhanVien();
        }

        public LoaiNhanVien xuatLoaiNhanVien(int MaLoaiNhanVien)
        {
            return dalLoaiNhanVien.xuatLoaiNhanVien(MaLoaiNhanVien);
        }
    }
}
