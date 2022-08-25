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

namespace QLDatVeXe
{
    public partial class frmBanVe : Form
    {
        public Model_NhanVien _nv;
        public frmBanVe()
        {
            InitializeComponent();
        }

        public frmBanVe(Model_NhanVien nv)
        {
            InitializeComponent();
            this._nv = nv;
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
            panelEx2.Controls.Add(childForm);
            panelEx2.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnDatCho_Click(object sender, EventArgs e)
        {
            OpenChilForm(new frmDatCho(_nv));
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            OpenChilForm(new frmTraCuu());
        }

        private void frmBanVe_Load(object sender, EventArgs e)
        {
            btnDijkstra.Enabled = true;
        }

        private void btnDijkstra_Click(object sender, EventArgs e)
        {
            OpenChilForm(new frmDijkstra());
        }




    }
}
