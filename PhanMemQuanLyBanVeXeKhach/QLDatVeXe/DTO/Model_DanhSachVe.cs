using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Model_DanhSachVe
    {
        public string MaVeXe { get; set; }
        public int DonGia { get; set; }
        public string TenKhachHang { get; set; }
        public string DienThoai { get; set; }
        public string GheNgoi { get; set; }

        public Model_DanhSachVe()
        {

        }

        public Model_DanhSachVe(string _MaVeXe, int _DonGia, string _TenKhachHang, string _DienThoai, string _GheNgoi)
        {
            this.MaVeXe = _MaVeXe;
            this.DonGia = _DonGia;
            this.TenKhachHang = _TenKhachHang;
            this.DienThoai = _DienThoai;
            this.GheNgoi = _GheNgoi;
        }
    }
}
