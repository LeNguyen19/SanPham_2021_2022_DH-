using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace QLDatVeXe
{
    public partial class frmQuanLyTaiKhoan : Form
    {
        bllTaiKhoan bllTaiKhoan = new bllTaiKhoan();
        bllLoaiTaiKhoan bllLoaiTaiKhoan = new bllLoaiTaiKhoan();
        bllNhanVien bllNhanVien = new bllNhanVien();
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            dataGridView1.DataSource = bllTaiKhoan.xuatListTaiKhoan();
        }
        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            txtHoTen.Enabled = false;
            txtMatKhau.Enabled = false;
            txtTenDangNhap.Enabled = false;
            btnLuu.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

            LoadData();
            cbbLoaiTaiKhoan.DataSource = bllLoaiTaiKhoan.xuatListLoaiTaiKhoan();
            cbbLoaiTaiKhoan.DisplayMember = "TenLoaiTaiKhoan";
            cbbLoaiTaiKhoan.ValueMember = "MaLoaiTaiKhoan";
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtHoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtMatKhau.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtTenDangNhap.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbbLoaiTaiKhoan.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtHoTen.Enabled = false;
            txtMatKhau.Enabled = true;
            txtTenDangNhap.Enabled = false;
            cbbLoaiTaiKhoan.Enabled = true;
            btnLuu.Enabled = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                if (bllTaiKhoan.XoaTaiKhoan(dataGridView1.CurrentRow.Cells[2].Value.ToString()))
                {
                    bllNhanVien.XoaNhanVien(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    LoadData();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(cbbLoaiTaiKhoan.SelectedValue.ToString().Equals(string.Empty) || txtMatKhau.Text.Equals(string.Empty))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                TaiKhoan tk = new TaiKhoan();
                tk.TenDangNhap = txtTenDangNhap.Text;
                tk.MatKhau = txtMatKhau.Text;
                tk.MaLoaiTaiKhoan = int.Parse(cbbLoaiTaiKhoan.SelectedValue.ToString());
                tk.fl_NgaySua = DateTime.Now;
                if (bllTaiKhoan.SuaTaiKhoan(tk))
                {
                    LoadData();
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLocTaiKhoan_Click(object sender, EventArgs e)
        {
            if (cbbLoaiTaiKhoan.SelectedValue.ToString().Equals(string.Empty))
            {
                MessageBox.Show("Vui lòng chọn loại tài khoản cần lọc", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                dataGridView1.DataSource = bllTaiKhoan.xuatTaiKhoanTheoLoai(int.Parse(cbbLoaiTaiKhoan.SelectedValue.ToString()));
            }
        }
    }
}
