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
    public partial class frmQuanLyLichChay : Form
    {
        bllLoTrinh bllLoTrinh = new bllLoTrinh();
        bllNhanVien bllNhanVien = new bllNhanVien();
        bllIndentity bllIndentity = new bllIndentity();
        bllLichChay bllLichChay = new bllLichChay();
        public frmQuanLyLichChay()
        {
            InitializeComponent();
        }
        public void LoadData()
        {
            dataGridView1.DataSource = bllLoTrinh.xuatAllLoTrinh();

            txtDiemDi.Enabled = false;
            txtDiemDen.Enabled = false;
            txtGiaVe.Enabled = false;
            txtQuangDuong.Enabled = false;
            btnThem_LT.Enabled = true;
            btnXoa_LT.Enabled = false;
            btnSua_LT.Enabled = false;
            btnLuu_LT.Enabled = false;

            txtMaLoTrinh.Enabled = false;
            cbbNhanVien.Enabled = false;
            cbbGioKhoiHanh.Enabled = false;
            DateNgayDi.Enabled = false;
            btnThem_LC.Enabled = true;
            btnXoa_LC.Enabled = false;
            btnSua_LC.Enabled = false;
            btnLuu_LC.Enabled = false;
        }
        public void LoadDaTa0()
        {
            dataGridView2.DataSource = bllLichChay.xuatListLichChayNV();
        }
        private void frmQuanLyLichChay_Load(object sender, EventArgs e)
        {
            cbbNhanVien.DataSource = bllNhanVien.xuatListNhanVienTaiXe();
            cbbNhanVien.DisplayMember = "TenNhanVien";
            cbbNhanVien.ValueMember = "MaNhanVien";
            LoadDaTa0();
            LoadData();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtDiemDi.Enabled = false;
            txtDiemDen.Enabled = false;
            txtGiaVe.Enabled = false;
            txtQuangDuong.Enabled = false;
            btnThem_LT.Enabled = true;
            btnXoa_LT.Enabled = true;
            btnSua_LT.Enabled = true;
            btnLuu_LT.Enabled = false;

            txtDiemDi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDiemDen.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtGiaVe.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtQuangDuong.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            txtMaLoTrinh.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnThem_LT_Click(object sender, EventArgs e)
        {
            txtDiemDi.Enabled = true;
            txtDiemDen.Enabled = true;
            txtGiaVe.Enabled = true;
            txtQuangDuong.Enabled = true;

            btnThem_LT.Enabled = true;
            btnXoa_LT.Enabled = false;
            btnSua_LT.Enabled = false;
            btnLuu_LT.Enabled = true;

            txtDiemDi.Text = string.Empty;
            txtDiemDen.Text = string.Empty;
            txtGiaVe.Text = string.Empty;
            txtQuangDuong.Text = string.Empty;
        }

        private void btnXoa_LT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                if (bllLoTrinh.xoaLoTrinh(dataGridView1.CurrentRow.Cells[0].Value.ToString()))
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
            if(txtDiemDi.Text.Equals(string.Empty) || txtDiemDen.Text.Equals(string.Empty) || txtGiaVe.Text.Equals(string.Empty) || txtQuangDuong.Text.Equals(string.Empty))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void btnSua_LT_Click(object sender, EventArgs e)
        {
            txtDiemDi.Enabled = false;
            txtDiemDen.Enabled = false;
            txtGiaVe.Enabled = true;
            txtQuangDuong.Enabled = true;

            btnThem_LT.Enabled = true;
            btnXoa_LT.Enabled = true;
            btnSua_LT.Enabled = true;
            btnLuu_LT.Enabled = true;

            txtGiaVe.Text = string.Empty;
            txtQuangDuong.Text = string.Empty;
        }

        private void btnLuu_LT_Click(object sender, EventArgs e)
        {
            if (kiemTraRong())
            {
                if (btnSua_LT.Enabled == false)
                {
                    int? stt = bllIndentity.xuatIndentityLoTrinh();
                    int? stt1 = stt + 1;

                    string ma = "";
                    if (stt1 < 10)
                    {
                        ma = "LT0000" + stt1;
                    }
                    else if (stt1 < 100 && stt1 >= 10)
                    {
                        ma = "LT000" + stt1;
                    }
                    else if (stt1 < 1000 && stt1 >= 100)
                    {
                        ma = "LT00" + stt1;
                    }
                    else if (stt1 < 10000 && stt1 >= 1000)
                    {
                        ma = "LT0" + stt1;
                    }
                    else if (stt1 < 100000 && stt1 >= 10000)
                    {
                        ma = "LT" + stt1;
                    }
                    //Viết hàm thêm
                    LoTrinh lt = new LoTrinh();
                    lt.MaLoTrinh = ma;
                    lt.DiemDi = txtDiemDi.Text;
                    lt.DiemDen = txtDiemDen.Text;
                    lt.GiaVe = int.Parse(txtGiaVe.Text);
                    lt.QuangDuong = int.Parse(txtQuangDuong.Text);
                    lt.fl_NgayThem = DateTime.Now;
                    lt.fl_NgaySua = null;
                    lt.fl_Xoa = 0;
                    if (bllLoTrinh.themLoTrinh(lt))
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
                    LoTrinh lt = new LoTrinh();
                    lt.MaLoTrinh = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    lt.DiemDi = txtDiemDi.Text;
                    lt.DiemDen = txtDiemDen.Text;
                    lt.GiaVe = int.Parse(txtGiaVe.Text);
                    lt.QuangDuong = int.Parse(txtQuangDuong.Text);
                    lt.fl_NgaySua = DateTime.Now;

                    if (bllLoTrinh.suaLoTrinh(lt))
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

        private void btnThem_LC_Click(object sender, EventArgs e)
        {
            txtMaLoTrinh.Enabled = false;
            cbbGioKhoiHanh.Enabled = true;
            cbbNhanVien.Enabled = true;
            DateNgayDi.Enabled = true;

            btnThem_LC.Enabled = true;
            btnXoa_LC.Enabled = false;
            btnSua_LC.Enabled = false;
            btnLuu_LC.Enabled = true;
        }

        private void btnXoa_LC_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                if (bllLichChay.xoaLichChay(dataGridView2.CurrentRow.Cells[0].Value.ToString()))
                {
                    LoadDaTa0();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_LC_Click(object sender, EventArgs e)
        {
            txtMaLoTrinh.Enabled = false;
            cbbGioKhoiHanh.Enabled = true;
            cbbNhanVien.Enabled = true;
            DateNgayDi.Enabled = true;

            btnThem_LC.Enabled = true;
            btnXoa_LC.Enabled = true;
            btnSua_LC.Enabled = true;
            btnLuu_LC.Enabled = true;
        }

        private void btnLuu_LC_Click(object sender, EventArgs e)
        {
            if (!txtMaLoTrinh.Text.Equals(string.Empty))
            {
                if (btnSua_LC.Enabled == false)
                {
                    int? stt = bllIndentity.xuatIndentityLichChay();
                    int? stt1 = stt + 1;

                    string ma = "";
                    if (stt1 < 10)
                    {
                        ma = "LC0000" + stt1;
                    }
                    else if (stt1 < 100 && stt1 >= 10)
                    {
                        ma = "LC000" + stt1;
                    }
                    else if (stt1 < 1000 && stt1 >= 100)
                    {
                        ma = "LC00" + stt1;
                    }
                    else if (stt1 < 10000 && stt1 >= 1000)
                    {
                        ma = "LC0" + stt1;
                    }
                    else if (stt1 < 100000 && stt1 >= 10000)
                    {
                        ma = "LC" + stt1;
                    }
                    //Viết hàm thêm
                    LichChay lc = new LichChay();
                    lc.MaLichChay = ma;
                    lc.NgayKhoiHanh = DateNgayDi.Value;
                    lc.GioKhoiHanh = cbbGioKhoiHanh.Text;
                    lc.MaLoTrinh = txtMaLoTrinh.Text;
                    lc.MaNhanVien = cbbNhanVien.SelectedValue.ToString();
                    lc.fl_NgayThem = DateTime.Now;
                    lc.fl_NgaySua = null;
                    lc.fl_Xoa = 0;

                    if (bllLichChay.themLichChay(lc))
                    {
                        LoadDaTa0();
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
                    LichChay lc = new LichChay();
                    lc.MaLichChay = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                    lc.NgayKhoiHanh = DateNgayDi.Value;
                    lc.GioKhoiHanh = cbbGioKhoiHanh.Text;
                    lc.MaLoTrinh = txtMaLoTrinh.Text;
                    lc.MaNhanVien = cbbNhanVien.SelectedValue.ToString();
                    lc.fl_NgaySua = DateTime.Now;

                    if (bllLichChay.suaLichChay(lc))
                    {
                        LoadDaTa0();
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            txtMaLoTrinh.Enabled = false;
            cbbGioKhoiHanh.Enabled = false;
            cbbNhanVien.Enabled = false;
            DateNgayDi.Enabled = false;

            btnThem_LC.Enabled = true;
            btnXoa_LC.Enabled = true;
            btnSua_LC.Enabled = true;
            btnLuu_LC.Enabled = false;

            cbbGioKhoiHanh.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            cbbNhanVien.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            DateNgayDi.Value = DateTime.Parse(dataGridView2.CurrentRow.Cells[1].Value.ToString());
        }
    }
}
