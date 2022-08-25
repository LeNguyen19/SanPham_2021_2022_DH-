package model;

public class CHUYENXE {

    public String tenLoTrinh;
    public String bienSoXe;
    public String giaVe;

    public CHUYENXE(String tenLoTrinh, String bienSoXe, String giaVe) {
        this.tenLoTrinh = tenLoTrinh;
        this.bienSoXe = bienSoXe;
        this.giaVe = giaVe;
    }

    public CHUYENXE()
    {

    }
    public String getTenLoTrinh() {
        return tenLoTrinh;
    }

    public void setTenLoTrinh(String tenLoTrinh) {
        this.tenLoTrinh = tenLoTrinh;
    }

    public String getBienSoXe() {
        return bienSoXe;
    }

    public void setBienSoXe(String bienSoXe) {
        this.bienSoXe = bienSoXe;
    }

    public String getGiaVe() {
        return giaVe;
    }

    public void setGiaVe(String giaVe) {
        this.giaVe = giaVe;
    }




}
