package model;

public class LichChay {
    public String MaLichChay;
    public String NgayKhoiHanh;
    public String GioKhoiHanh;
    public String MaLoTrinh;
    public String MaNhanVien;
    public String fl_NgayThem;
    public String fl_NgaySua;
    public long fl_Xoa;

    public LichChay() {
    }

    public LichChay(String maLichChay, String ngayKhoiHanh, String gioKhoiHanh, String maLoTrinh, String maNhanVien, String fl_NgayThem, String fl_NgaySua, long fl_Xoa) {
        MaLichChay = maLichChay;
        NgayKhoiHanh = ngayKhoiHanh;
        GioKhoiHanh = gioKhoiHanh;
        MaLoTrinh = maLoTrinh;
        MaNhanVien = maNhanVien;
        this.fl_NgayThem = fl_NgayThem;
        this.fl_NgaySua = fl_NgaySua;
        this.fl_Xoa = fl_Xoa;
    }
}
