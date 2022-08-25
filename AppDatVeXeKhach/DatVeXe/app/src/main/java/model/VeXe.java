package model;

public class VeXe {
    public String MaVeXe;
    public long SoLuong;
    public long DonGia;
    public long ThanhTien;
    public String MaLichChay_Xe;
    public String MaKhachHang;
    public String MaNhanVien;
    public long fl_Xoa;

    public VeXe()
    {

    }

    public VeXe(String maVeXe, long soLuong, long donGia, long thanhTien, String maLichChay_Xe, String maKhachHang, String maNhanVien, long fl_Xoa) {
        MaVeXe = maVeXe;
        SoLuong = soLuong;
        DonGia = donGia;
        ThanhTien = thanhTien;
        MaLichChay_Xe = maLichChay_Xe;
        MaKhachHang = maKhachHang;
        MaNhanVien = maNhanVien;
        this.fl_Xoa = fl_Xoa;
    }
}
