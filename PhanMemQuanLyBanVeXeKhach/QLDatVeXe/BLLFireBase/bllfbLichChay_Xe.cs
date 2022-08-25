using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireBase;
using DTO;

namespace BLLFireBase
{
    public class bllfbLichChay_Xe
    {
        public bllfbLichChay_Xe()
        {

        }
        public static async Task<List<PT_LichChay_Xe>> GetThongTinLichChay_Xe()
        {
            return await fbLichChay_Xe.GetThongTinLichChay_Xe();
        }


        public static async Task<bool> ThemLichChay_Xe(PT_LichChay_Xe pLichChay_Xe, int stt)
        {
            return await fbLichChay_Xe.ThemLichChay_Xe(pLichChay_Xe, stt);
        }

        public static async Task<bool> XoaLichChay_Xe(PT_LichChay_Xe pLichChay_Xe, int stt)
        {
            return await fbLichChay_Xe.XoaLichChay_Xe(pLichChay_Xe, stt);
        }

        public static async Task<bool> SuaLichChay_Xe(PT_LichChay_Xe pLichChay_Xe, int stt)
        {
            return await fbLichChay_Xe.SuaLichChay_Xe(pLichChay_Xe, stt);
        }
    }
}
