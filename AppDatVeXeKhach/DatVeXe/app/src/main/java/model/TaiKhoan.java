package model;

public class TaiKhoan {
    public String TenDangNhap;
    public String MatKhau;
    public long MaLoaiTaiKhoan;
    public String fl_NgayThem;
    public String fl_NgaySua;
    public long fl_Xoa;

    public TaiKhoan() {
    }

    public TaiKhoan(String tenDangNhap, String matKhau, long maLoaiTaiKhoan, String fl_NgayThem, String fl_NgaySua, long fl_Xoa) {
        TenDangNhap = tenDangNhap;
        MatKhau = matKhau;
        MaLoaiTaiKhoan = maLoaiTaiKhoan;
        this.fl_NgayThem = fl_NgayThem;
        this.fl_NgaySua = fl_NgaySua;
        this.fl_Xoa = fl_Xoa;
    }
}
