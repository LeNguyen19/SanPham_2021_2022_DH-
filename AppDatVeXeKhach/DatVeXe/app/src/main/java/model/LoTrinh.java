package model;

public class LoTrinh {

    public String MaLoTrinh;
    public String DiemDi;
    public String DiemDen;
    public long QuangDuong;
    public long GiaVe;
    public String fl_NgayThem;
    public String fl_NgaySua;
    public long fl_Xoa;

    public LoTrinh() {
    }

    public LoTrinh(String maLoTrinh, String diemDi, String diemDen, long quangDuong, long giaVe, String fl_NgayThem, String fl_NgaySua, long fl_Xoa) {
        MaLoTrinh = maLoTrinh;
        DiemDi = diemDi;
        DiemDen = diemDen;
        QuangDuong = quangDuong;
        GiaVe = giaVe;
        this.fl_NgayThem = fl_NgayThem;
        this.fl_NgaySua = fl_NgaySua;
        this.fl_Xoa = fl_Xoa;
    }
}
