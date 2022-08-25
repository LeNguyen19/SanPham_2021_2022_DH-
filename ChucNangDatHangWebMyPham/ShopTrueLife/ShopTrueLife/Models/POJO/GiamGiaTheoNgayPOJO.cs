using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopTrueLife.Models.POJO
{
    public class GiamGiaTheoNgayPOJO
    {
        public int iID { get; set; }
        public DateTime dNgayBatDau { get; set; }
        public DateTime dNgayKetThuc { get; set; }
        public int iSoPhanTram { get; set; }

        public GiamGiaTheoNgayPOJO()
        {

        }

        public GiamGiaTheoNgayPOJO(int _iID, DateTime _dNgayBatDau, DateTime _dNgayKetThuc, int _iSoPhanTram)
        {
            this.iID = _iID;
            this.dNgayBatDau = _dNgayBatDau;
            this.dNgayKetThuc = _dNgayKetThuc;
            this.iSoPhanTram = _iSoPhanTram;
        }
    }
}