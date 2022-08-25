package model;

public class LichChay_Xe {
    public String MaLichChay_Xe;
    public long TrangThai;
    public String MaLichChay;
    public String MaXe;
    public String fl_NgayThem;
    public String fl_NgaySua;
    public long fl_Xoa;

    public LichChay_Xe() {
    }

    public LichChay_Xe(String maLichChay_Xe, long trangThai, String maLichChay, String maXe, String fl_NgayThem, String fl_NgaySua, long fl_Xoa) {
        MaLichChay_Xe = maLichChay_Xe;
        TrangThai = trangThai;
        MaLichChay = maLichChay;
        MaXe = maXe;
        this.fl_NgayThem = fl_NgayThem;
        this.fl_NgaySua = fl_NgaySua;
        this.fl_Xoa = fl_Xoa;
    }
}
