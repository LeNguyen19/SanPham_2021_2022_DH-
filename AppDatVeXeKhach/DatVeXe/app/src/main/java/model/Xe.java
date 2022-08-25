package model;

public class Xe {
    public String MaXe;
    public String BienSo;
    public long SoGhe;
    public long MaLoaiXe;
    public long fl_Xoa;

    public Xe() {
    }

    public Xe(String maXe, String bienSo, long soGhe, long maLoaiXe, long fl_Xoa) {
        MaXe = maXe;
        BienSo = bienSo;
        SoGhe = soGhe;
        MaLoaiXe = maLoaiXe;
        this.fl_Xoa = fl_Xoa;
    }
}
