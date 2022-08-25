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
    public partial class frmQuanLyNhanVien : Form
    {
        bllNhanVien bllNhanVien = new bllNhanVien();
        bllLoaiNhanVien bllLoaiNhanVien = new bllLoaiNhanVien();
        bllTaiKhoan bllTaiKhoan = new bllTaiKhoan();
        bllIndentity bllIndentity = new bllIndentity();
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
        }

        private void LoadDTGV()
        {
            dtgvNhanVien.DataSource = bllNhanVien.xuatListNhanVien();
        }

        private void frmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            txtCMND.Enabled = false;
            txtDiaChi.Enabled = false;
            txtHoTen.Enabled = false;
            txtSDT.Enabled = false;
            cbbGioiTinh.Enabled = false;
            cbbLoaiNhanVien.Enabled = false;
            DateNgaySinh.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;

            LoadDTGV();
            cbbLoaiNhanVien.DataSource = bllLoaiNhanVien.xuatListLoaiNhanVien();
            cbbLoaiNhanVien.DisplayMember = "TenLoaiNhanVien";
            cbbLoaiNhanVien.ValueMember = "MaLoaiNhanVien";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtCMND.Enabled = true;
            txtDiaChi.Enabled = true;
            txtHoTen.Enabled = true;
            txtSDT.Enabled = true;
            cbbGioiTinh.Enabled = true;
            cbbLoaiNhanVien.Enabled = true;
            DateNgaySinh.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            txtCMND.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            cbbGioiTinh.Text = string.Empty;
            cbbLoaiNhanVien.Text = string.Empty;
        }

        public bool kiemTraRong()
        {
            if (txtCMND.Text == string.Empty || txtHoTen.Text == string.Empty || txtSDT.Text == string.Empty || txtDiaChi.Text == string.Empty || cbbGioiTinh.Text == string.Empty || cbbLoaiNhanVien.Text == string.Empty)
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
            if (kiemTraRong() == true)
            {
                if (btnSua.Enabled == false)
                {
                    int? stt = bllIndentity.xuatIndentityNhanVien();
                    int? stt1 = stt + 1;

                    string ma = "";
                    if(stt1<10)
                    {
                        ma = "NV0000" + stt1;
                    }
                    else if(stt1<100 && stt1 >=10)
                    {
                        ma = "NV000" + stt1;
                    }
                    else if(stt1<1000 && stt1 >= 100)
                    {
                        ma = "NV00" + stt1;
                    }
                    else if (stt1 < 10000 && stt1 >= 1000)
                    {
                        ma = "NV0" + stt1;
                    }
                    else if (stt1 < 100000 && stt1 >= 10000)
                    {
                        ma = "NV" + stt1;
                    }

                    TaiKhoan tk = new TaiKhoan();
                    tk.TenDangNhap = ma;
                    tk.MatKhau = "123";
                    tk.MaLoaiTaiKhoan = 2;
                    tk.fl_NgayThem = DateTime.Now;
                    tk.fl_NgaySua = null;
                    tk.fl_Xoa = 0;
                    bllTaiKhoan.ThemTaiKhoan(tk);


                    NhanVien nv = new NhanVien();
                    nv.MaNhanVien = ma;
                    nv.TenNhanVien = txtHoTen.Text;
                    nv.GioiTinh = cbbGioiTinh.SelectedItem.ToString();
                    nv.NgaySinh = DateNgaySinh.Value;
                    nv.DienThoai = txtSDT.Text;
                    nv.CCCD = txtCMND.Text;
                    nv.DiaChi = txtDiaChi.Text;
                    nv.TenDangNhap = ma;
                    nv.MaLoaiNhanVien = int.Parse(cbbLoaiNhanVien.SelectedValue.ToString());
                    nv.fl_NgayThem = DateTime.Now;
                    nv.fl_NgaySua = null;
                    nv.fl_Xoa = 0;
                    bllNhanVien.ThemNhanVien(nv);
                    LoadDTGV();
                }
                else
                {
                    NhanVien nvSearch = bllNhanVien.xuatNhanVien(dtgvNhanVien.CurrentRow.Cells[1].Value.ToString());
                    NhanVien nv = new NhanVien();
                    nv.MaNhanVien = dtgvNhanVien.CurrentRow.Cells[1].Value.ToString();
                    nv.TenNhanVien = txtHoTen.Text;
                    nv.GioiTinh = cbbGioiTinh.SelectedItem.ToString();
                    nv.NgaySinh = DateNgaySinh.Value;
                    nv.DienThoai = txtSDT.Text;
                    nv.CCCD = txtCMND.Text;
                    nv.DiaChi = txtDiaChi.Text;
                    nv.MaLoaiNhanVien = int.Parse(cbbLoaiNhanVien.SelectedValue.ToString());
                    nv.fl_NgayThem = nvSearch.fl_NgayThem;
                    nv.fl_NgaySua = DateTime.Now;
                    nv.fl_Xoa = nvSearch.fl_Xoa;

                    if(bllNhanVien.SuaNhanVien(nv))
                    {
                        LoadDTGV();
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Các thông tin không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            txtCMND.Text = dtgvNhanVien.CurrentRow.Cells[6].Value.ToString();
            txtHoTen.Text = dtgvNhanVien.CurrentRow.Cells[2].Value.ToString();
            txtSDT.Text = dtgvNhanVien.CurrentRow.Cells[5].Value.ToString();
            txtDiaChi.Text = dtgvNhanVien.CurrentRow.Cells[7].Value.ToString();
            cbbGioiTinh.Text = dtgvNhanVien.CurrentRow.Cells[3].Value.ToString();
            cbbLoaiNhanVien.Text = dtgvNhanVien.CurrentRow.Cells[12].Value.ToString();
            DateNgaySinh.Value = DateTime.Parse(dtgvNhanVien.CurrentRow.Cells[4].Value.ToString());

            txtCMND.Enabled = false;
            txtDiaChi.Enabled = false;
            txtHoTen.Enabled = false;
            txtSDT.Enabled = false;
            cbbGioiTinh.Enabled = false;
            cbbLoaiNhanVien.Enabled = false;
            DateNgaySinh.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtCMND.Enabled = true;
            txtDiaChi.Enabled = true;
            txtHoTen.Enabled = true;
            txtSDT.Enabled = true;
            cbbGioiTinh.Enabled = true;
            cbbLoaiNhanVien.Enabled = true;
            DateNgaySinh.Enabled = true;

            btnLuu.Enabled = true;
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                if(bllNhanVien.XoaNhanVien(dtgvNhanVien.CurrentRow.Cells[1].Value.ToString()))
                {
                    
                    bllTaiKhoan.XoaTaiKhoan(dtgvNhanVien.CurrentRow.Cells[8].Value.ToString());
                    LoadDTGV();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
