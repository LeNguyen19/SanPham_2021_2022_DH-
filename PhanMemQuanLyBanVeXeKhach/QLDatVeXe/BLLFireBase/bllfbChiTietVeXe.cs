using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireBase;
using DTO;

namespace BLLFireBase
{
    public class bllfbChiTietVeXe
    {
        public bllfbChiTietVeXe()
        {

        }
        public static async Task<List<ChiTietVeXe>> GetThongTinChiTietVeXe()
        {
            return await fbChiTietVeXe.GetThongTinChiTietVeXe();
        }


        public static async Task<bool> ThemChiTietVeXe(ChiTietVeXe pChiTietVeXe, int stt)
        {
            return await fbChiTietVeXe.ThemChiTietVeXe(pChiTietVeXe, stt);
        }

        public static async Task<bool> XoaChiTietVeXe(ChiTietVeXe pChiTietVeXe, int stt)
        {
            return await fbChiTietVeXe.XoaChiTietVeXe(pChiTietVeXe, stt);
        }

        public static async Task<bool> SuaChiTietVeXe(ChiTietVeXe pChiTietVeXe, int stt)
        {
            return await fbChiTietVeXe.SuaChiTietVeXe(pChiTietVeXe, stt);
        }
    }
}
