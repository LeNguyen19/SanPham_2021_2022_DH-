using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONTROLS;
using BLL;
using DTO;
using Export;

namespace QLDatVeXe
{
    public partial class frmDatCho : Form
    {
        bllLoTrinh bllLoTrinh = new bllLoTrinh();
        bllLichChay bllLichChay = new bllLichChay();
        bllLichChay_Xe bllLichChay_Xe = new bllLichChay_Xe();
        bllChiTietVeXe bllChiTietVeXe = new bllChiTietVeXe();
        bllKhachHang bllKhachHang = new bllKhachHang();
        bllIndentity bllIndentity = new bllIndentity();
        bllVeXe bllVeXe = new bllVeXe();
        bllXe bllXe = new bllXe();
        public List<string> listViTri { get; set; }
        public Model_NhanVien _nv;
        public frmDatCho()
        {
            InitializeComponent();
            LoadGhe();
        }

        public frmDatCho(Model_NhanVien nv)
        {
            InitializeComponent();
            LoadGhe();
            this._nv = nv;
        }
        public void LoadGhe()
        {
            XeGiuongNam xgn = new XeGiuongNam(txtViTriGhe);
            xgn.Dock = DockStyle.Fill;
            panelXe.Controls.Add(xgn);
            EnabledTextBox();
        }

        private void frmDatCho_Load(object sender, EventArgs e)
        {
            cbbDiemDi.DataSource = bllLoTrinh.listDiemDi();
            cbbDiemDen.Enabled = false;
            DateNgayDi.Enabled = false;
            cbbGioKhoiHanh.Enabled = false;
            EnabledTextBox();
        }

        private void cbbDiemDi_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbbDiemDen.DataSource = bllLoTrinh.listDiemDen(cbbDiemDi.Text);
            cbbDiemDen.Enabled = true;
            DateNgayDi.Enabled = false;
            cbbGioKhoiHanh.Enabled = false;
        }

        private void cbbDiemDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateNgayDi.Enabled = true;
            cbbGioKhoiHanh.Enabled = false;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            cbbGioKhoiHanh.Enabled = true;
            string maLoTrinh = bllLoTrinh.layMaLoTrinh(cbbDiemDi.Text, cbbDiemDen.Text);
            cbbGioKhoiHanh.DataSource = bllLichChay.layGioLichChay(DateNgayDi.Value, maLoTrinh);
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            string maLoTrinh = bllLoTrinh.layMaLoTrinh(cbbDiemDi.Text, cbbDiemDen.Text);
            string maLichChay = bllLichChay.layMaLichChay(DateNgayDi.Value, maLoTrinh, cbbGioKhoiHanh.Text);
            dataGridView1.DataSource = bllLichChay_Xe.layListLichChay_XeNhoMaLichChay(maLichChay);
        }

        public void EnabledTextBox()
        {
            txtViTriGhe.Enabled = false;
            txtTenKhach.Text = string.Empty;
            txtViTriGhe.Text = string.Empty;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            listViTri = bllChiTietVeXe.listViTriGheDuaTrenMaLichChay_Xe(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            panelXe.Controls.Clear();
            XeGiuongNam xgn = new XeGiuongNam(listViTri,txtViTriGhe);
            xgn.Dock = DockStyle.Fill;
            panelXe.Controls.Add(xgn);
            EnabledTextBox();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenKhach.Text = txtViTriGhe.Text = txtSDTKhach.Text = string.Empty;
        }

        private void btnThemVe_Click(object sender, EventArgs e)
        {
            if(txtTenKhach.Text.Equals(string.Empty) || txtSDTKhach.Text.Equals(string.Empty) || txtViTriGhe.Text.Equals(string.Empty))
            {
                MessageBox.Show("Thông tin khách hàng và chổ ngồi còn trống\nĐặt vé thất bại","Thông báo!");
                return;
            }
            //Kiểm tra Khách Hàng xem có trong csdl ch có rùi thì lấy mã của Khách Hàng ra thông qua số điện thoại
            string maKhachHang = bllKhachHang.xuatKhachHang_SDT(txtSDTKhach.Text);
            
            //Nếu chưa thì thêm Khách Hàng vào csdl là lấy mã của Khách Hàng đó ra
            if(maKhachHang == null)
            {
                //Láy identity của KhachHang trong bảng tạm
                int? stt = bllIndentity.xuatIndentityKhachHang();
                //identity KhachHang cộng 1 để tạo mã cho KhachHang
                int? stt1 = stt + 1;
                string ma = "";
                //Tạo mã theo quy định có sẳn
                
                if (stt1 < 10)
                {
                    ma = "KH0000" + stt1;
                }
                else if (stt1 < 100 && stt1 >= 10)
                {
                    ma = "KH000" + stt1;
                }
                else if (stt1 < 1000 && stt1 >= 100)
                {
                    ma = "KH00" + stt1;
                }
                else if (stt1 < 10000 && stt1 >= 1000)
                {
                    ma = "KH0" + stt1;
                }
                else if (stt1 < 100000 && stt1 >= 10000)
                {
                    ma = "KH" + stt1;
                }

                KhachHang kh = new KhachHang();
                kh.MaKhachHang = ma;
                kh.TenKhachHang = txtTenKhach.Text;
                kh.GioiTinh = null;
                kh.NgaySinh = null;
                kh.DienThoai = txtSDTKhach.Text;
                kh.CCCD = null;
                kh.DiaChi = null;
                kh.TenDangNhap = null;
                kh.fl_NgayThem = DateTime.Now;
                kh.fl_NgaySua = null;
                kh.fl_Xoa = 0;
                bllKhachHang.themKhachHang(kh);
                //Thêm 1 ví xe mới
                int? sttVeXe = bllIndentity.xuatIndentityVeXe();
                int? sttVeXeNew = sttVeXe + 1;
                string maVeXe = "";
                if (sttVeXeNew < 10)
                {
                    maVeXe = "VX0000" + sttVeXeNew;
                }
                else if (sttVeXeNew < 100 && sttVeXeNew >= 10)
                {
                    maVeXe = "VX000" + sttVeXeNew;
                }
                else if (sttVeXeNew < 1000 && sttVeXeNew >= 100)
                {
                    maVeXe = "VX00" + sttVeXeNew;
                }
                else if (sttVeXeNew < 10000 && sttVeXeNew >= 1000)
                {
                    maVeXe = "VX0" + sttVeXeNew;
                }
                else if (sttVeXeNew < 100000 && sttVeXeNew >= 10000)
                {
                    maVeXe = "VX" + sttVeXeNew;
                }

                string[] listViTriNe = txtViTriGhe.Text.Split(' ');
                string maLichChay = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string maLichChay_Xe = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                int giaVe = bllLoTrinh.layDonGiaLoTrinh(maLichChay);

                VeXe v = new VeXe();
                v.MaVeXe = maVeXe;
                v.DonGia = giaVe;
                v.SoLuong = listViTriNe.Count() - 1;
                v.ThanhTien = giaVe * (listViTriNe.Count() - 1);
                v.MaNhanVien = _nv.NhanVien.MaNhanVien;
                v.MaKhachHang = ma;
                v.MaLichChay_Xe = maLichChay_Xe;
                v.fl_Xoa = 0;
                bllVeXe.themVeXe(v);
                //Thêm chi tiết vé xe
                
                foreach(string item in listViTriNe)
                {
                    if(!item.Equals(""))
                    {
                        ChiTietVeXe ctvx = new ChiTietVeXe();
                        ctvx.MaVeXe = maVeXe;
                        ctvx.GheNgoi = item;
                        bllChiTietVeXe.themChiTietVeXe(ctvx);
                    }
                }

            }
            else
            {
                //Thêm 1 ví xe mới
                int? sttVeXe = bllIndentity.xuatIndentityVeXe();
                int? sttVeXeNew = sttVeXe + 1;
                string maVeXe = "";
                if (sttVeXeNew < 10)
                {
                    maVeXe = "VX0000" + sttVeXeNew;
                }
                else if (sttVeXeNew < 100 && sttVeXeNew >= 10)
                {
                    maVeXe = "VX000" + sttVeXeNew;
                }
                else if (sttVeXeNew < 1000 && sttVeXeNew >= 100)
                {
                    maVeXe = "VX00" + sttVeXeNew;
                }
                else if (sttVeXeNew < 10000 && sttVeXeNew >= 1000)
                {
                    maVeXe = "VX0" + sttVeXeNew;
                }
                else if (sttVeXeNew < 100000 && sttVeXeNew >= 10000)
                {
                    maVeXe = "VX" + sttVeXeNew;
                }

                string[] listViTriNe = txtViTriGhe.Text.Split(' ');
                string maLichChay = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string maLichChay_Xe = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                int giaVe = bllLoTrinh.layDonGiaLoTrinh(maLichChay);

                VeXe v = new VeXe();
                v.MaVeXe = maVeXe;
                v.DonGia = giaVe;
                v.SoLuong = listViTriNe.Count() - 1;
                v.ThanhTien = giaVe * (listViTriNe.Count() - 1);
                v.MaNhanVien = _nv.NhanVien.MaNhanVien;
                v.MaKhachHang = maKhachHang;
                v.MaLichChay_Xe = maLichChay_Xe;
                v.fl_Xoa = 0;
                bllVeXe.themVeXe(v);
                //Thêm chi tiết vé xe
                foreach (string item in listViTriNe)
                {
                    if (!item.Equals(""))
                    {
                        ChiTietVeXe ctvx = new ChiTietVeXe();
                        ctvx.MaVeXe = maVeXe;
                        ctvx.GheNgoi = item;
                        bllChiTietVeXe.themChiTietVeXe(ctvx);
                        listViTri.Add(item);
                    }
                }
            }

            string[] list = txtViTriGhe.Text.Split(' ');
            foreach (string item in list)
            {
                if (!item.Equals(""))
                {
                    string maXe = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    WordExport_VeXe w = new WordExport_VeXe();
                    string ngayDi = DateNgayDi.Value.Day + "/" + DateNgayDi.Value.Month + "/" + DateNgayDi.Value.Year;
                    string bienSo = bllXe.xuatBienSo(maXe);
                    string maLichChay = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    int giaVe = bllLoTrinh.layDonGiaLoTrinh(maLichChay);
                    w.InVeXe((DateTime.Now.Day).ToString(), (DateTime.Now.Month).ToString(), (DateTime.Now.Year).ToString(), txtTenKhach.Text, cbbDiemDi.Text, cbbDiemDen.Text, ngayDi, cbbGioKhoiHanh.Text, bienSo, item, giaVe.ToString());
                }
            }
            
            panelXe.Controls.Clear();
            XeGiuongNam xgn = new XeGiuongNam(listViTri, txtViTriGhe);
            xgn.Dock = DockStyle.Fill;
            panelXe.Controls.Add(xgn);
            EnabledTextBox();
        }
    }
}
