using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace QLDatVeXe
{
    public partial class frmThongKeDoanhThu : Form
    {
        bllThongKe bll = new bllThongKe();
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
        }

        private void frmThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            List<int> listNam = new List<int>();
            int n = 2000;
            while(n<=DateTime.Now.Year)
            {
                listNam.Add(n);
                n++;
            }

            cbbNam.DataSource = listNam;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            List<LichChay> listLichChay = bll.layDanhSachLichChayTheoNam(int.Parse(cbbNam.Text));
            int thang = 1;
            while(thang<=12)
            {
                int count = 0;
                foreach (LichChay lc in listLichChay)
                {

                    List<LichChay_Xe> listLichChayXe = bll.layDanhSachLichChayXeTheoLichChay(thang, lc);
                    foreach (LichChay_Xe lcx in listLichChayXe)
                    {
                        List<VeXe> listVeXe = bll.layDanhSachVeXeTheoLichChayXe(lcx);
                        foreach (VeXe vx in listVeXe)
                        {
                            count += bll.soVe(vx);
                        }
                    }
                }
                chart1.Series["chart1"].Points.AddXY("Tháng "+ thang, count);
                thang++;
            }
        }
    }
}
