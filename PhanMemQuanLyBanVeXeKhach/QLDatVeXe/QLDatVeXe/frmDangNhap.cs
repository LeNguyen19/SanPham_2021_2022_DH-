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
using Export;

namespace QLDatVeXe
{
    public partial class frmDangNhap : Form
    {
        bllNhanVien bllNhanVien = new bllNhanVien();
        bllXuLyDangNhap bllXuLyDangNhap = new bllXuLyDangNhap();
        bllLoaiNhanVien bllLoaiNhanVien = new bllLoaiNhanVien();
        bllTaiKhoan bllTaiKhoan = new bllTaiKhoan();

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;
            if(tenDangNhap.Equals(string.Empty) && matKhau.Equals(string.Empty))
            {
                MessageBox.Show("Tài khoản và Mật khẩu trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(tenDangNhap.Equals(string.Empty))
            {
                MessageBox.Show("Tài khoản trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(matKhau.Equals(string.Empty))
            {
                MessageBox.Show("Mật khẩu trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int kiemTraDangNhap = bllXuLyDangNhap.xuLyDangNhap(tenDangNhap, matKhau);
                if (kiemTraDangNhap == 0)
                {
                    MessageBox.Show("Hàm xử lý đăng nhập bị lỗi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (kiemTraDangNhap == 2)
                {
                    MessageBox.Show("Tài khoản mật khẩu không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Model_NhanVien nv = new Model_NhanVien();
                    nv.NhanVien = bllNhanVien.xuatNhanVien(txtTenDangNhap.Text);
                    nv.TaiKhoan = bllTaiKhoan.xuatTaiKhoan(txtTenDangNhap.Text);
                    nv.LoaiNhanVien = bllLoaiNhanVien.xuatLoaiNhanVien(nv.NhanVien.MaLoaiNhanVien);
                    frmMain Main = new frmMain(nv);
                    Main.Show();
                }
            }
        }


    }
}
