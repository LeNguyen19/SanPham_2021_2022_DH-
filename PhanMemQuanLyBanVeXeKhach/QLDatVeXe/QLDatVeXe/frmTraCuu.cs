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
using Export;

namespace QLDatVeXe
{
    public partial class frmTraCuu : Form
    {
        bllLoTrinh bllLoTrinh = new bllLoTrinh();
        bllLichChay bllLichChay = new bllLichChay();
        bllLichChay_Xe bllLichChay_Xe = new bllLichChay_Xe();
        bllChiTietVeXe bllChiTietVeXe = new bllChiTietVeXe();
        bllKhachHang bllKhachHang = new bllKhachHang();
        bllIndentity bllIndentity = new bllIndentity();
        bllVeXe bllVeXe = new bllVeXe();

        public frmTraCuu()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTraCuu_Load(object sender, EventArgs e)
        {
            cbbDiemDi.DataSource = bllLoTrinh.listDiemDi();
            cbbDiemDen.Enabled = false;
            DateNgayDi.Enabled = false;
            cbbGio.Enabled = false;
        }

        private void cbbDiemDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbDiemDen.Enabled = true;
            DateNgayDi.Enabled = true;
            cbbDiemDen.DataSource = bllLoTrinh.listDiemDen(cbbDiemDi.Text);
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            cbbGio.Enabled = true;
            string maLoTrinh = bllLoTrinh.layMaLoTrinh(cbbDiemDi.Text,cbbDiemDen.Text);
            cbbGio.DataSource = bllLichChay.layGioLichChay(DateNgayDi.Value, maLoTrinh);
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string maLoTrinh = bllLoTrinh.layMaLoTrinh(cbbDiemDi.Text, cbbDiemDen.Text);
            string maLichChay = bllLichChay.layMaLichChay(DateNgayDi.Value, maLoTrinh, cbbGio.Text);
            dataGridView2.DataSource = bllLichChay_Xe.layListLichChay_XeNhoMaLichChay(maLichChay);
        }
        public void LoadDanhSachVe()
        {
            string maLichChay_Xe = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            string maLichChay = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            dataGridView1.DataSource = bllChiTietVeXe.layDanhSachVe(maLichChay_Xe, maLichChay);
        }
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            LoadDanhSachVe();
        }

        

        private void btnTimKhach_Click(object sender, EventArgs e)
        {
            string maLichChay_Xe = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            string maLichChay = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            dataGridView1.DataSource = bllChiTietVeXe.timKiemDanhSachVe(maLichChay_Xe,maLichChay,txtTenKhachHang.Text);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ChiTietVeXe ctvx = new ChiTietVeXe();
            ctvx.MaVeXe = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            ctvx.GheNgoi = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            if (MessageBox.Show("Bạn có chắc là muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                if (bllChiTietVeXe.xoaChiTietVeXe(ctvx))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDanhSachVe();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            string maLichChay_Xe = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            string maLichChay = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            ExcelExport_DanhSachVe ex = new ExcelExport_DanhSachVe();
            List<Model_DanhSachVe> list = new List<Model_DanhSachVe>();
            list = bllChiTietVeXe.layDanhSachVe(maLichChay_Xe, maLichChay);
            string path1 = string.Empty;
            ex.ExportDanhSachVe(list, ref path1, false);
            if(!string.IsNullOrEmpty(path1))
            {
                System.Diagnostics.Process.Start(path1);
            }
            else
            {
                MessageBox.Show("Thất bại?");
            }
        }
    }
}
