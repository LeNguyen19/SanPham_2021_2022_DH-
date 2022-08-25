using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireBase;
using DTO;

namespace BLLFireBase
{
    public class bllfbXe
    {
        public bllfbXe()
        {

        }
        public static async Task<List<Xe>> GetThongTinXe()
        {
            return await fbXe.GetThongTinXe();

        }


        public static async Task<bool> ThemXe(Xe pXe, int stt)
        {
            return await fbXe.ThemXe(pXe, stt);
        }

        public static async Task<bool> XoaXe(Xe pXe, int stt)
        {
            return await fbXe.XoaXe(pXe, stt);
        }

        public static async Task<bool> SuaXe(Xe pXe, int stt)
        {
            return await fbXe.SuaXe(pXe, stt);
        }
    }
}
