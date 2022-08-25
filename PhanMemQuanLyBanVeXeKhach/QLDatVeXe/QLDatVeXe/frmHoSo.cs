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
    public partial class frmHoSo : Form
    {
        bllLoaiTaiKhoan bllLoaiTaiKhoan = new bllLoaiTaiKhoan();
        bllTaiKhoan bllTaiKhoan = new bllTaiKhoan();
        bllNhanVien bllNhanVien = new bllNhanVien();
        Model_NhanVien nv { get; set; }

        public frmHoSo()
        {
            InitializeComponent();
        }

        public frmHoSo(Model_NhanVien _nv)
        {
            this.nv = _nv;
            InitializeComponent();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmHoSo_Load(object sender, EventArgs e)
        {
            cbbLoaiTaiKhoan.Enabled = false;
            txtTenDangNhap.Enabled = false;
            txtTenHienThi.Enabled = false;
            txtMatKhau.Enabled = false;
            txtCMND.Enabled = false;
            txtDiaChi.Enabled = false;
            ctrDatePicker1.Enabled = false;
            txtSDT.Enabled = false;
            cbbGioiTinh.Enabled = false;
            txtMatKhauMoi.Enabled = false;
            txtXacNhanMatKhau.Enabled = false;
            btnLuuTaiKhoan.Enabled = false;
            btnLuuTTCoBan.Enabled = false;

            LoaiTaiKhoan loaiTaiKhoan = bllLoaiTaiKhoan.xuatLoaiTaiKhoan(nv.TaiKhoan.MaLoaiTaiKhoan);

            lbChucVu.Text = nv.LoaiNhanVien.TenLoaiNhanVien;
            lbHoTen.Text = "Xin chào " + nv.NhanVien.TenNhanVien;
            cbbLoaiTaiKhoan.Text = loaiTaiKhoan.TenLoaiTaiKhoan;
            txtTenDangNhap.Text = nv.NhanVien.TenDangNhap;
            txtTenHienThi.Text = nv.NhanVien.TenNhanVien;
            txtMatKhau.Text = nv.TaiKhoan.MatKhau;
            txtCMND.Text = nv.NhanVien.CCCD;
            txtDiaChi.Text = nv.NhanVien.DiaChi;
            ctrDatePicker1.Value = nv.NhanVien.NgaySinh;
            txtSDT.Text = nv.NhanVien.DienThoai;
            cbbGioiTinh.Text = nv.NhanVien.GioiTinh;
            txtMatKhauMoi.Text = "";
            txtXacNhanMatKhau.Text = "";
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            cbbLoaiTaiKhoan.Enabled = false;
            txtTenDangNhap.Enabled = false;
            txtTenHienThi.Enabled = false;
            txtMatKhau.Enabled = false;
            txtCMND.Enabled = false;
            txtDiaChi.Enabled = false;
            ctrDatePicker1.Enabled = false;
            txtSDT.Enabled = false;
            cbbGioiTinh.Enabled = false;
            txtMatKhauMoi.Enabled = true;
            txtXacNhanMatKhau.Enabled = true;
            btnLuuTaiKhoan.Enabled = true;
            btnLuuTTCoBan.Enabled = false;
        }

        private void btnSuaTTCoBan_Click(object sender, EventArgs e)
        {
            cbbLoaiTaiKhoan.Enabled = false;
            txtTenDangNhap.Enabled = false;
            txtTenHienThi.Enabled = false;
            txtMatKhau.Enabled = false;
            txtCMND.Enabled = true;
            txtDiaChi.Enabled = true;
            ctrDatePicker1.Enabled = true;
            txtSDT.Enabled = true;
            cbbGioiTinh.Enabled = true;
            txtMatKhauMoi.Enabled = false;
            txtXacNhanMatKhau.Enabled = false;
            btnLuuTaiKhoan.Enabled = false;
            btnLuuTTCoBan.Enabled = true;
        }

        private async void btnLuuTaiKhoan_Click(object sender, EventArgs e)
        {
            if (txtMatKhauMoi.Text.Equals(string.Empty) && txtXacNhanMatKhau.Text.Equals(string.Empty))
            {
                MessageBox.Show("Mật khẩu mới với xác nhận mật khẩu trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtMatKhauMoi.Text.Equals(string.Empty))
            {
                MessageBox.Show("Mật khẩu mới trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (txtXacNhanMatKhau.Text.Equals(string.Empty))
            {
                MessageBox.Show("Xác nhận mật khẩu trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (txtMatKhauMoi.Text.Equals(txtXacNhanMatKhau.Text))
                {
                    nv.TaiKhoan.MatKhau = txtMatKhauMoi.Text;
                    TaiKhoan tk = new TaiKhoan();

                    tk.TenDangNhap = txtTenDangNhap.Text;
                    tk.MatKhau = txtMatKhauMoi.Text;
                    tk.MaLoaiTaiKhoan = nv.TaiKhoan.MaLoaiTaiKhoan;
                    tk.fl_NgayThem = nv.TaiKhoan.fl_NgayThem;
                    tk.fl_NgaySua = DateTime.Now;
                    tk.fl_Xoa = nv.TaiKhoan.fl_Xoa;


                    bllTaiKhoan.SuaTaiKhoan(tk);
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtMatKhau.Text = nv.TaiKhoan.MatKhau;
                    txtMatKhauMoi.Text = "";
                    txtXacNhanMatKhau.Text = "";
                    txtMatKhauMoi.Enabled = false;
                    txtXacNhanMatKhau.Enabled = false;
                    btnLuuTaiKhoan.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Mật khẩu với xác nhận mật khẩu phải trùng nhau", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLuuTTCoBan_Click(object sender, EventArgs e)
        {
            if(txtCMND.Text == string.Empty || txtDiaChi.Text == string.Empty || txtSDT.Text == string.Empty || ctrDatePicker1.Value == null || cbbGioiTinh.Text == string.Empty)
            {
                MessageBox.Show("Các thông tin không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                nv.NhanVien.CCCD = txtCMND.Text;
                nv.NhanVien.GioiTinh = cbbGioiTinh.Text;
                nv.NhanVien.NgaySinh = ctrDatePicker1.Value;
                nv.NhanVien.DiaChi = txtDiaChi.Text;
                nv.NhanVien.DienThoai = txtSDT.Text;
                NhanVien nv1 = new NhanVien();

                nv1.MaNhanVien = nv.NhanVien.MaNhanVien; ;
                nv1.TenNhanVien = nv.NhanVien.TenNhanVien;
                nv1.GioiTinh = cbbGioiTinh.Text;
                nv1.NgaySinh = ctrDatePicker1.Value;
                nv1.DiaChi = txtDiaChi.Text;
                nv1.DienThoai = txtSDT.Text;
                nv1.CCCD = txtCMND.Text;
                nv1.MaLoaiNhanVien = nv.NhanVien.MaLoaiNhanVien;
                nv1.TenDangNhap = nv.NhanVien.TenDangNhap;
                nv1.fl_NgayThem = nv.NhanVien.fl_NgayThem;
                nv1.fl_NgaySua = DateTime.Now;
                nv1.fl_Xoa = nv.NhanVien.fl_Xoa;

                bllNhanVien.SuaNhanVien(nv1);
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                cbbGioiTinh.Text = nv.NhanVien.GioiTinh;
                ctrDatePicker1.Value = nv.NhanVien.NgaySinh;
                txtDiaChi.Text = nv.NhanVien.DiaChi;
                txtSDT.Text = nv.NhanVien.DienThoai;
                txtCMND.Text = nv.NhanVien.CCCD;
                txtCMND.Enabled = false;
                txtDiaChi.Enabled = false;
                ctrDatePicker1.Enabled = false;
                txtSDT.Enabled = false;
                cbbGioiTinh.Enabled = false;
                btnLuuTTCoBan.Enabled = false;
            }
        }
    }
}
