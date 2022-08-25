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
    public partial class frmXepLichChay : Form
    {
        bllLichChay bllLichChay = new bllLichChay();
        bllXe bllXe = new bllXe();
        bllLichChay_Xe bllLichChay_Xe = new bllLichChay_Xe();
        bllIndentity bllIndentity = new bllIndentity();
        public frmXepLichChay()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            dataGridView2.DataSource = bllLichChay_Xe.layListLichChay_Xe();
        }
        private void frmXepLichChay_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bllLichChay.xuatListLichChay_LoTrinh();
            LoadData();
            cbbXe.DataSource = bllXe.xuatListXe();
            cbbXe.DisplayMember = "BienSo";
            cbbXe.ValueMember = "MaXe";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                if (bllLichChay_Xe.xoaLichChay_Xe(dataGridView2.CurrentRow.Cells[0].Value.ToString()))
                {
                    LoadData();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            int? stt = bllIndentity.xuatIndentityLichChay_Xe();
            int? stt1 = stt + 1;

            string ma = "";
            if (stt1 < 10)
            {
                ma = "LCX0000" + stt1;
            }
            else if (stt1 < 100 && stt1 >= 10)
            {
                ma = "LCX000" + stt1;
            }
            else if (stt1 < 1000 && stt1 >= 100)
            {
                ma = "LCX00" + stt1;
            }
            else if (stt1 < 10000 && stt1 >= 1000)
            {
                ma = "LCX0" + stt1;
            }
            else if (stt1 < 100000 && stt1 >= 10000)
            {
                ma = "LCX" + stt1;
            }
            string maLichChay = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string maXe = cbbXe.SelectedValue.ToString();
            if(maLichChay.Equals(string.Empty) || maXe.Equals(string.Empty))
            {
                MessageBox.Show("Thông tin cần nhập trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                LichChay_Xe lcxn = new LichChay_Xe();
                lcxn.MaLichChay_Xe = ma;
                lcxn.TrangThai = 0;
                lcxn.MaLichChay = maLichChay;
                lcxn.MaXe = maXe;
                lcxn.fl_NgayThem = DateTime.Now;
                lcxn.fl_NgaySua = null;
                lcxn.fl_Xoa = 0;
                if (bllLichChay_Xe.themLichChay_Xe(lcxn))
                {
                    LoadData();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string maLichChay_Xe = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            if (bllLichChay_Xe.capNhatTrangThaiLichChay_Xe(maLichChay_Xe))
            {
                LoadData();
                MessageBox.Show("Cập nhật trạng thái thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maLichChay_Xe = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            string maXe = cbbXe.SelectedValue.ToString();
            string maLichChay = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            LichChay_Xe lcx = new LichChay_Xe();
            lcx.MaLichChay_Xe = maLichChay_Xe;
            lcx.MaLichChay = maLichChay;
            lcx.MaXe = maXe;
            lcx.fl_NgaySua = DateTime.Now;
            if (bllLichChay_Xe.suaLichChay_Xe(lcx))
            {
                LoadData();
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
