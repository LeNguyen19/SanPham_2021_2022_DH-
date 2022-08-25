using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireBase;
using DTO;

namespace BLLFireBase
{
    public class bllfbLichChay
    {
        public bllfbLichChay()
        {

        }

        public static async Task<List<PT_LichChay>> GetThongTinLichChay()
        {
            return await fbLichChay.GetThongTinLichChay();
        }

        public static async Task<bool> ThemLichChay(PT_LichChay pLichChay, int stt)
        {
            return await fbLichChay.ThemLichChay(pLichChay, stt);
        }

        public static async Task<bool> XoaLichChay(PT_LichChay pLichChay, int stt)
        {
            return await fbLichChay.XoaLichChay(pLichChay, stt);
        }

        public static async Task<bool> SuaLichChay(PT_LichChay pLichChay, int stt)
        {
            return await fbLichChay.SuaLichChay(pLichChay, stt);
        }
    }
}
