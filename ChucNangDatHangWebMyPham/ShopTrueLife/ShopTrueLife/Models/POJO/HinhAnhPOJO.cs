using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTrueLife.Models.POJO
{
    public class HinhAnhPOJO
    {
        public string sDuongDanHinh { get; set; }
        public int iID_HinhAnh { get; set; }
        public int iTrangThai { get; set; }

        public HinhAnhPOJO()
        {

        }

        public HinhAnhPOJO(string _sDuongDanHinh, int _iID_HinhAnh, int _iTrangThai)
        {
            this.sDuongDanHinh = _sDuongDanHinh;
            this.iID_HinhAnh = _iID_HinhAnh;
            this.iTrangThai = _iTrangThai;
        }
    }
}