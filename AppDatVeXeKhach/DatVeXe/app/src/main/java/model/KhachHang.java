package model;

public class KhachHang {
    public String MaKhachHang;
    public String TenKhachHang;
    public String GioiTinh;
    public String NgaySinh;
    public String DiaChi;
    public String DienThoai;
    public String CCCD;
    public String TenDangNhap;
    public String fl_NgayThem;
    public String fl_NgaySua;
    public long fl_Xoa;

    public KhachHang() {

    }

    public KhachHang(String maKhachHang, String tenKhachHang, String gioiTinh, String ngaySinh, String diaChi, String dienThoai, String CCCD, String tenDangNhap, String fl_NgayThem, String fl_NgaySua, long fl_Xoa) {
        MaKhachHang = maKhachHang;
        TenKhachHang = tenKhachHang;
        GioiTinh = gioiTinh;
        NgaySinh = ngaySinh;
        DiaChi = diaChi;
        DienThoai = dienThoai;
        this.CCCD = CCCD;
        TenDangNhap = tenDangNhap;
        this.fl_NgayThem = fl_NgayThem;
        this.fl_NgaySua = fl_NgaySua;
        this.fl_Xoa = fl_Xoa;
    }
}
