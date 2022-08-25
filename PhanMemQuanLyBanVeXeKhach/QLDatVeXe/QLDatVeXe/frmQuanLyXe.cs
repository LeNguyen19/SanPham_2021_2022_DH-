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
    public partial class frmQuanLyXe : Form
    {
        bllLoaiXe bllLoaiXe = new bllLoaiXe();
        bllXe bllXe = new bllXe();
        bllIndentity bllIndentity = new bllIndentity();
        public frmQuanLyXe()
        {
            InitializeComponent();
        }
        public void LoadData()
        {

            txtMaXe.Enabled = false;
            txtBienSo.Enabled = false;
            txtSoGhe.Enabled = false;

            cbbLoaiXe.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;

            dataGridView2.DataSource = bllXe.xuatListXe();
        }
        private void frmQuanLyXe_Load(object sender, EventArgs e)
        {
            cbbLoaiXe.Items.Clear();
            cbbLoaiXe.DataSource = bllLoaiXe.xuatListLoaiXe();
            cbbLoaiXe.DisplayMember = "TenLoaiXe";
            cbbLoaiXe.ValueMember = "MaLoaiXe";
            LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaXe.Enabled = false;
            txtBienSo.Enabled = true;
            txtSoGhe.Enabled = true;

            cbbLoaiXe.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;

            txtMaXe.Text = string.Empty;
            txtBienSo.Text = string.Empty;
            txtSoGhe.Text = string.Empty;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtMaXe.Enabled = false;
            txtBienSo.Enabled = true;
            txtSoGhe.Enabled = true;

            cbbLoaiXe.Enabled = true;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = true;

            txtBienSo.Text = string.Empty;
            txtSoGhe.Text = string.Empty;
        }

        
        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            txtMaXe.Enabled = false;
            txtBienSo.Enabled = false;
            txtSoGhe.Enabled = false;
            cbbLoaiXe.Enabled = false;

            txtMaXe.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtBienSo.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtSoGhe.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            cbbLoaiXe.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                if (bllXe.xoaXe(dataGridView2.CurrentRow.Cells[0].Value.ToString()))
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

        public bool kiemTraRong()
        {
            if (txtBienSo.Text == string.Empty || txtSoGhe.Text == string.Empty || cbbLoaiXe.Text == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(kiemTraRong())
            {
                if(btnSua.Enabled == false)
                {
                    int? stt = bllIndentity.xuatIndentityXe();
                    int? stt1 = stt + 1;
                    //bllIndentity.ThemIndentityNhanVien(stt1);

                    string ma = "";
                    if (stt1 < 10)
                    {
                        ma = "XE0000" + stt1;
                    }
                    else if (stt1 < 100 && stt1 >= 10)
                    {
                        ma = "XE000" + stt1;
                    }
                    else if (stt1 < 1000 && stt1 >= 100)
                    {
                        ma = "XE00" + stt1;
                    }
                    else if (stt1 < 10000 && stt1 >= 1000)
                    {
                        ma = "XE0" + stt1;
                    }
                    else if (stt1 < 100000 && stt1 >= 10000)
                    {
                        ma = "XE" + stt1;
                    }
                    //Viết hàm thêm
                    Xe x = new Xe();
                    x.MaXe = ma;
                    x.BienSo = txtBienSo.Text;
                    x.SoGhe = int.Parse(txtSoGhe.Text);
                    x.MaLoaiXe = int.Parse(cbbLoaiXe.SelectedValue.ToString());
                    x.fl_Xoa = 0;

                    if(bllXe.themXe(x))
                    {
                        LoadData();
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    //Viết hàm sửa
                    Xe x = new Xe();
                    x.MaXe = txtMaXe.Text;
                    x.BienSo = txtBienSo.Text;
                    x.SoGhe = int.Parse(txtSoGhe.Text);
                    x.MaLoaiXe = int.Parse(cbbLoaiXe.SelectedValue.ToString());
                    x.fl_Xoa = 0;

                    if(bllXe.suaXe(x))
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
            else
            {
                MessageBox.Show("Các thông tin không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
