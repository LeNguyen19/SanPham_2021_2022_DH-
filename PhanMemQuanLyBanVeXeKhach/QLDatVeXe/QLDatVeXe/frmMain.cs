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
    public partial class frmMain : Form
    {
        Model_NhanVien nv { get; set; }

        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(Model_NhanVien _nv)
        {
            this.nv = _nv;
            InitializeComponent();
        }

        private Form currentFormChild;

        private void OpenChilForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            panelEx1.Controls.Add(childForm);
            panelEx1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnXemHoSo_Click(object sender, EventArgs e)
        {
            OpenChilForm(new frmHoSo(nv));
        }

        private void btnBanVe_Click(object sender, EventArgs e)
        {
            OpenChilForm(new frmBanVe(nv));
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChilForm(new frmQuanLyTaiKhoan());
        }

        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            OpenChilForm(new frmQuanLyNhanVien());
        }

        private void btnQLLichChay_Click(object sender, EventArgs e)
        {
            OpenChilForm(new frmQuanLyLichChay());
        }

        private void btnXepLichChay_Click(object sender, EventArgs e)
        {
            OpenChilForm(new frmXepLichChay());
        }

        private void btnQLXe_Click(object sender, EventArgs e)
        {
            OpenChilForm(new frmQuanLyXe());
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ribbonTabItem2.Enabled = false;
            if(nv.LoaiNhanVien.MaLoaiNhanVien == 1)
            {
                ribbonTabItem2.Enabled = true;
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn muốn đăng xuất","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnQLKhachHang_Click(object sender, EventArgs e)
        {
            OpenChilForm(new frmQuanLyKhachHang());
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            OpenChilForm(new frmThongKeDoanhThu());
        }




    }
}
