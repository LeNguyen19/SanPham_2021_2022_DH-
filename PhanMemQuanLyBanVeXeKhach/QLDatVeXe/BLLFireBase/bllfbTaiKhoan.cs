using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireBase;
using DTO;

namespace BLLFireBase
{
    public class bllfbTaiKhoan
    {
        public bllfbTaiKhoan()
        {

        }
        public static async Task<List<Model_TaiKhoan>> GetThongTinTaiKhoan()
        {
            return await fbTaiKhoan.GetThongTinTaiKhoan();
        }


        public static async Task<bool> ThemTaiKhoan(Model_TaiKhoan pTaiKhoan, int stt)
        {
            return await fbTaiKhoan.ThemTaiKhoan(pTaiKhoan, stt);
        }

        public static async Task<bool> XoaTaiKhoan(Model_TaiKhoan pTaiKhoan, int stt)
        {
            return await fbTaiKhoan.XoaTaiKhoan(pTaiKhoan, stt);
        }

        public static async Task<bool> SuaTaiKhoan(Model_TaiKhoan pTaiKhoan, int stt)
        {
            return await fbTaiKhoan.SuaTaiKhoan(pTaiKhoan, stt);
        }
    }
}
