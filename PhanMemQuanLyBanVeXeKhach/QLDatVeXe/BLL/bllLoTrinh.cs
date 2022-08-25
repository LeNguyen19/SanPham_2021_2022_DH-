using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class bllLoTrinh
    {
        dalLoTrinh dalLoTrinh = new dalLoTrinh();
        public bllLoTrinh()
        {

        }

        public List<string> listDiemDi()
        {
            return dalLoTrinh.listDiemDi();
        }
        public List<string> listDiemDen(string diemDi)
        {
            return dalLoTrinh.listDiemDen(diemDi);
        }
        public string layMaLoTrinh(string diemDi, string diemDen)
        {
            return dalLoTrinh.layMaLoTrinh(diemDi, diemDen);
        }

        public int layDonGiaLoTrinh(string maLichChay)
        {
            return dalLoTrinh.layDonGiaLoTrinh(maLichChay);
        }

        public List<LoTrinh> xuatAllLoTrinh()
        {
            return dalLoTrinh.xuatAllLoTrinh();
        }

        public bool themLoTrinh(LoTrinh lt)
        {
            return dalLoTrinh.themLoTrinh(lt);
        }

        public bool xoaLoTrinh(string maLoTrinh)
        {
            return dalLoTrinh.xoaLoTrinh(maLoTrinh);
        }

        public bool suaLoTrinh(LoTrinh lt)
        {
            return dalLoTrinh.suaLoTrinh(lt);
        }
    }
}
