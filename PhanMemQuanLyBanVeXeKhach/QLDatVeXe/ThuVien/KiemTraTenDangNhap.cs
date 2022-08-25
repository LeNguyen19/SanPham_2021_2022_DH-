using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThuVien
{
    public class KiemTraTenDangNhap
    {
        public bool KiemTraKyTuChu(string s)
        {
            foreach (var c in s)
            {
                if (char.IsLetter(c) && char.IsUpper(c))
                {
                    return true;
                }
            }
            return false;
        }

        public bool KiemTraKyTuSo(string s)
        {
            foreach (var c in s)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }

        public string KiemTraTenDangNhapHopLe(string s)
        {
            if (KiemTraKyTuChu(s) == false || KiemTraKyTuSo(s) == false)
            {
                return "Mat khau khong hop le";
            }
            return "Mat khau hop le";
        }
    }
}
