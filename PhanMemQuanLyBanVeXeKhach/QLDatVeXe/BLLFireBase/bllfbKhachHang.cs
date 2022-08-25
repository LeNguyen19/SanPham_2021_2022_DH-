using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireBase;
using DTO;

namespace BLLFireBase
{
    public class bllfbKhachHang
    {
        public bllfbKhachHang()
        {

        }
        public static async Task<List<Model_KhachHang>> GetThongTinKhachHang()
        {
            return await fbKhachHang.GetThongTinKhachHang();
        }


        public static async Task<bool> ThemKhachHang(Model_KhachHang pKhachHang, int stt)
        {
            return await fbKhachHang.ThemKhachHang(pKhachHang, stt);
        }

        public static async Task<bool> XoaKhachHang(Model_KhachHang pKhachHang, int stt)
        {
            return await fbKhachHang.XoaKhachHang(pKhachHang, stt);
        }

        public static async Task<bool> SuaKhachHang(Model_KhachHang pKhachHang, int stt)
        {
            return await fbKhachHang.SuaKhachHang(pKhachHang, stt);
        }
    }
}
