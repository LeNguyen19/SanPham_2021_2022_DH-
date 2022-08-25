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
    public partial class frmQuanLyKhachHang : Form
    {
        bllKhachHang bllKhachHang = new bllKhachHang();
        bllTaiKhoan bllTaiKhoan = new bllTaiKhoan();
        bllIndentity bllIndentity = new bllIndentity();
        public frmQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void LoadDTGV()
        {
            //Load tất cả dữ liệu dưới SQL của bảng KhachHang lên dataGriView
            dtgvKhachHang.DataSource = bllKhachHang.xuatListKhachHang();
        }

        private void frmQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            txtCMND.Enabled = false;
            txtDiaChi.Enabled = false;
            txtHoTen.Enabled = false;
            txtSDT.Enabled = false;
            cbbGioiTinh.Enabled = false;
            DateNgaySinh.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnLuu.Enabled = false;

            LoadDTGV();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            txtCMND.Enabled = true;
            txtDiaChi.Enabled = true;
            txtHoTen.Enabled = true;
            txtSDT.Enabled = true;
            cbbGioiTinh.Enabled = true;
            DateNgaySinh.Enabled = true;
            btnLuu.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;

            txtCMND.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            cbbGioiTinh.Text = string.Empty;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            txtCMND.Enabled = true;
            txtDiaChi.Enabled = true;
            txtHoTen.Enabled = true;
            txtSDT.Enabled = true;
            cbbGioiTinh.Enabled = true;
            DateNgaySinh.Enabled = true;

            btnLuu.Enabled = true;
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn xóa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                if (bllKhachHang.xoaKhachHang(dtgvKhachHang.CurrentRow.Cells[0].Value.ToString()))
                {
                    //Xóa TaiKhoan dưới SQL. Cấp nhật cờ fl_Xoa = 1
                    bllTaiKhoan.XoaTaiKhoan(dtgvKhachHang.CurrentRow.Cells[7].Value.ToString());
                    LoadDTGV();
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xóa thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dtgvKhachHang_SelectionChanged(object sender, EventArgs e)
        {
            if (!dtgvKhachHang.CurrentRow.Cells[5].Value.ToString().Equals(null))
            {
                txtCMND.Text = dtgvKhachHang.CurrentRow.Cells[5].Value.ToString();
            }
            if (!dtgvKhachHang.CurrentRow.Cells[6].Value.Equals(string.Empty))
            {
                txtDiaChi.Text = dtgvKhachHang.CurrentRow.Cells[6].Value.ToString();
            }
            if (!dtgvKhachHang.CurrentRow.Cells[2].Value.Equals(string.Empty))
            {
                cbbGioiTinh.Text = dtgvKhachHang.CurrentRow.Cells[2].Value.ToString();
            }
            if (!dtgvKhachHang.CurrentRow.Cells[3].Equals(string.Empty))
            {
                DateNgaySinh.Value = DateTime.Parse(dtgvKhachHang.CurrentRow.Cells[3].Value.ToString());
            }
            txtHoTen.Text = dtgvKhachHang.CurrentRow.Cells[1].Value.ToString();
            txtSDT.Text = dtgvKhachHang.CurrentRow.Cells[4].Value.ToString();
            
            
            

            txtCMND.Enabled = false;
            txtDiaChi.Enabled = false;
            txtHoTen.Enabled = false;
            txtSDT.Enabled = false;
            cbbGioiTinh.Enabled = false;
            DateNgaySinh.Enabled = false;
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
        }

        //Kiểm tra các dữ liệu xem người dùng có bỏ trống phần nào hay không
        public bool kiemTraRong()
        {
            if (txtCMND.Text == string.Empty || txtHoTen.Text == string.Empty || txtSDT.Text == string.Empty || txtDiaChi.Text == string.Empty || cbbGioiTinh.Text == string.Empty)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            //Kiểm tra các dữ liệu xem người dùng có bỏ trống phần nào hay không
            if (kiemTraRong() == true)
            {
                //Kiểm tra sự kiện button nếu như btnSua = true thì xún sử lý hàm sửa. Còn btnSua = false thì cho biết người dùng đag thêm
                if (btnSua.Enabled == false)
                {
                    //Láy danh sách identity của KhachHang trong bảng tạm
                    int? stt = bllIndentity.xuatIndentityKhachHang();
                    //Lấy sô lớn nhất của identity KhachHang cộng 1 để tạo mã cho KhachHang
                    int? stt1 = stt + 1;
                    //Thêm 1 dòng dữ liệu cho identity KhachHang để lần sau không trùng khóa với nhau
                    //bllIndentity.ThemIndentityKhachHang(stt1);

                    //Tạo mã theo quy định có sẳn
                    string ma = "";
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
                    //Khởi tạo đối tượng Tài khoản. Khi người dùng nhấn thêm
                    //Thì Tên Đăng Nhập và mật khẩu sẽ được tự động cấp theo ý của người dùng cho sẳn
                    TaiKhoan tk = new TaiKhoan();
                    tk.TenDangNhap = ma;
                    tk.MatKhau = "123";
                    tk.MaLoaiTaiKhoan = 3;
                    //Ngày thêm là ngày hiện tại trên máy tính khi người dùng bấm nút thêm
                    tk.fl_NgayThem = DateTime.Now;
                    tk.fl_NgaySua = null;
                    tk.fl_Xoa = 0;
                    //Thêm tài khoản xuống SQL
                    bllTaiKhoan.ThemTaiKhoan(tk);
                    //Tạo một đối tượng mới Khách Hàng để gán giá trị rồi thêm
                    KhachHang kh = new KhachHang();
                    kh.MaKhachHang = ma;
                    kh.TenKhachHang = txtHoTen.Text;
                    kh.GioiTinh = cbbGioiTinh.SelectedItem.ToString();
                    kh.NgaySinh = DateNgaySinh.Value;
                    kh.DienThoai = txtSDT.Text;
                    kh.CCCD = txtCMND.Text;
                    kh.DiaChi = txtDiaChi.Text;
                    kh.TenDangNhap = ma;
                    //Ngày thêm là ngày hiện tại trên máy tính khi người dùng bấm nút thêm
                    kh.fl_NgayThem = DateTime.Now;
                    kh.fl_NgaySua = null;
                    kh.fl_Xoa = 0;
                    //Thêm khách hàng xuống SQL
                    bllKhachHang.themKhachHang(kh);
                    //Load lại dữ liệu sau khi thêm thành công
                    LoadDTGV();
                }
                else
                {
                    //Lấy Khách Hàng dựa và mã Khách Hàng. Để truyền tham số cho những thuộc tính không được thay đổi
                    KhachHang khSeach = bllKhachHang.xuatKhachHang(dtgvKhachHang.CurrentRow.Cells[0].Value.ToString());
                    //Tạo 1 khách hàng mới vào thêm thông tin thay đổi
                    KhachHang kh = new KhachHang();
                    //Mã khách hàng không được thay đổi. Cố định
                    kh.MaKhachHang = khSeach.MaKhachHang;
                    kh.TenKhachHang = txtHoTen.Text;
                    kh.GioiTinh = cbbGioiTinh.SelectedItem.ToString();
                    kh.NgaySinh = DateNgaySinh.Value;
                    kh.DienThoai = txtSDT.Text;
                    kh.CCCD = txtCMND.Text;
                    kh.DiaChi = txtDiaChi.Text;
                    //Tên đăng nhập không được thay đổi. Cố định
                    kh.TenDangNhap = khSeach.TenDangNhap;
                    //Ngày thêm không được thay đổi. Cố định
                    kh.fl_NgayThem = khSeach.fl_NgayThem;
                    kh.fl_NgaySua = DateTime.Now;
                    //Cờ xóa không được thay đổi. Cố định
                    kh.fl_Xoa = khSeach.fl_Xoa;

                    if (bllKhachHang.suaKhachHang(kh))
                    {
                        //Load lại dữ liệu cho dataGriView khi sửa xong
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
    }
}
