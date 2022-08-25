using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireBase;
using DTO;

namespace BLLFireBase
{
    public class bllfbVeXe
    {
        public bllfbVeXe()
        {

        }
        public static async Task<List<VeXe>> GetThongTinVeXe()
        {
            return await fbVeXe.GetThongTinVeXe();

        }


        public static async Task<bool> ThemVeXe(VeXe pVeXe, int stt)
        {
            return await fbVeXe.ThemVeXe(pVeXe, stt);
        }

        public static async Task<bool> XoaVeXe(VeXe pVeXe, int stt)
        {
            return await fbVeXe.XoaVeXe(pVeXe, stt);
        }

        public static async Task<bool> SuaVeXe(VeXe pVeXe, int stt)
        {
            return await fbVeXe.SuaVeXe(pVeXe, stt);
        }
    }
}
