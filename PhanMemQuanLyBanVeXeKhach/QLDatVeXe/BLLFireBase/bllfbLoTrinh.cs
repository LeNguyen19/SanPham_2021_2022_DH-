using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireBase;
using DTO;

namespace BLLFireBase
{
    public class bllfbLoTrinh
    {
        public bllfbLoTrinh()
        {

        }
        public static async Task<List<PT_LoTrinh>> GetThongTinLoTrinh()
        {
            return await fbLoTrinh.GetThongTinLoTrinh();
        }


        public static async Task<bool> ThemLoTrinh(PT_LoTrinh pLoTrinh, int stt)
        {
            return await fbLoTrinh.ThemLoTrinh(pLoTrinh, stt);
        }

        public static async Task<bool> XoaLoTrinh(PT_LoTrinh pLoTrinh, int stt)
        {
            return await fbLoTrinh.XoaLoTrinh(pLoTrinh, stt);
        }

        public static async Task<bool> SuaLoTrinh(PT_LoTrinh pLoTrinh, int stt)
        {
            return await fbLoTrinh.SuaLoTrinh(pLoTrinh, stt);
        }
    }
}
