using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Model_Xe
    {
        public string MaXe { get; set; }
        public string BienSo { get; set; }
        public int SoGhe { get; set; }
        public string TenLoaiXe { get; set; }

        public Model_Xe()
        {

        }

        public Model_Xe(string _MaXe, string _BienSo, int _SoGhe, string _TenLoaiXe)
        {
            this.MaXe = _MaXe;
            this.BienSo = _BienSo;
            this.SoGhe = _SoGhe;
            this.TenLoaiXe = _TenLoaiXe;
        }
    }
}
