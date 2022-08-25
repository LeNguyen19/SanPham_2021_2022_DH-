package com.example.datvexe;

import android.content.Intent;
import android.os.Bundle;
import android.text.format.DateFormat;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.Date;

import model.KhachHang;
import model.TaiKhoan;

public class XemHoSoActivity extends AppCompatActivity {

    Button btn_back, btn_Sua;
    TextView txt_HoTen, txt_TenDangNhap, txt_MatKhau, txt_SDT, txt_CCCD, txt_NgaySinh, txt_DiaChi, txt_GioiTinh;

    ArrayList<KhachHang> listKH = new ArrayList<>();
    ArrayList<TaiKhoan> listTK = new ArrayList<>();
    FirebaseDatabase database = FirebaseDatabase.getInstance("https://dbquanlynhaxe-default-rtdb.asia-southeast1.firebasedatabase.app/");
    DatabaseReference reference = database.getReference("KhachHang");

    DatabaseReference referenceTK = database.getReference("TaiKhoan");
    public XemHoSoActivity()
    {
        referenceTK.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    TaiKhoan tkF = data.getValue(TaiKhoan.class);
                    listTK.add(tkF);
                }
                return;
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                return;
            }
        });

        reference.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    KhachHang khF = data.getValue(KhachHang.class);
                    listKH.add(khF);
                }
                return;
            }
            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                return;
            }
        });
    }
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_xem_ho_so);

        txt_HoTen = findViewById(R.id.txtHoVaTenHS);
        txt_TenDangNhap = findViewById(R.id.txtTenDangNhapHS);
        txt_MatKhau = findViewById(R.id.txtMatKhauHS);
        txt_SDT = findViewById(R.id.txtSDTHS);
        txt_CCCD = findViewById(R.id.txtCCCDHS);
        txt_NgaySinh = findViewById(R.id.txtNgaySinhHS);
        txt_DiaChi = findViewById(R.id.txtDiaChiHS);
        txt_GioiTinh = findViewById(R.id.txtGioiTinhHS);
        //Lay thong tin tai khoan Khach Hang dang nhap
        Intent intent = getIntent();
        String tenDangNhap = intent.getStringExtra("TenDangNhapKH").toString();
        String matKhau = intent.getStringExtra("MatKhauKH").toString();
        //Lay thong tin cua Khach Hang
        btn_back = findViewById(R.id.btn_TrangChu);
        btn_Sua = findViewById(R.id.btn_Sua);
        btn_back.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(XemHoSoActivity.this, HomeActivity.class);
                intent.putExtra("TenDangNhapKH", tenDangNhap);
                intent.putExtra("MatKhauKH",matKhau);
                startActivity(intent);
            }
        });
        KhachHang kh = new KhachHang();
        reference.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    KhachHang khF = data.getValue(KhachHang.class);
                    if(khF.TenDangNhap.equals(tenDangNhap))
                    {
                        kh.MaKhachHang=khF.MaKhachHang;
                        kh.TenKhachHang=khF.TenKhachHang;
                        kh.GioiTinh=khF.GioiTinh;
                        kh.NgaySinh=khF.NgaySinh;
                        kh.DiaChi=khF.DiaChi;
                        kh.DienThoai=khF.DienThoai;
                        kh.CCCD=khF.CCCD;
                        kh.TenDangNhap=khF.TenDangNhap;
                        kh.fl_NgayThem=khF.fl_NgayThem;
                        kh.fl_NgaySua=khF.fl_NgaySua;
                        kh.fl_Xoa=khF.fl_Xoa;

                        //Gan du lieu len tren textview
                        txt_HoTen.setText(khF.TenKhachHang);
                        txt_HoTen.setEnabled(false);
                        txt_TenDangNhap.setText(khF.TenDangNhap);
                        txt_TenDangNhap.setEnabled(false);
                        txt_CCCD.setText(khF.CCCD);
                        txt_DiaChi.setText(khF.DiaChi);
                        txt_GioiTinh.setText(khF.GioiTinh);
                        txt_GioiTinh.setEnabled(false);
                        txt_MatKhau.setText(matKhau);
                        txt_NgaySinh.setText(khF.NgaySinh);
                        txt_SDT.setText(khF.DienThoai);
                        return;
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });


        btn_Sua.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                Date d = new Date();
                CharSequence s  = DateFormat.format("MM/dd/yyyy ", d.getTime());

                for (int i =0;i<listTK.size();i++)
                {
                    if(listTK.get(i).TenDangNhap.equals(tenDangNhap))
                    {
                        TaiKhoan tk = new TaiKhoan();
                        tk.TenDangNhap = tenDangNhap;
                        tk.MatKhau = txt_MatKhau.getText().toString();
                        tk.MaLoaiTaiKhoan = 3;
                        tk.fl_NgayThem = s.toString();
                        tk.fl_NgaySua = s.toString();
                        tk.fl_Xoa = 0;
                        referenceTK.child((i+1)+"").setValue(tk);
                    }
                }

                for (int j=0;j<listKH.size();j++)
                {
                    if(listKH.get(j).MaKhachHang.equals(tenDangNhap))
                    {
                        KhachHang khachHang = new KhachHang();
                        khachHang.MaKhachHang = tenDangNhap;
                        khachHang.TenKhachHang = txt_HoTen.getText().toString();
                        khachHang.DienThoai = txt_SDT.getText().toString();
                        khachHang.NgaySinh = txt_NgaySinh.getText().toString();
                        khachHang.DiaChi = txt_DiaChi.getText().toString();
                        khachHang.CCCD = txt_CCCD.getText().toString();
                        khachHang.TenDangNhap = tenDangNhap;
                        khachHang.GioiTinh = txt_GioiTinh.getText().toString();
                        khachHang.fl_NgayThem = s.toString();
                        khachHang.fl_NgaySua = s.toString();
                        khachHang.fl_Xoa = 0;
                        reference.child((j+1)+"").setValue(khachHang);
                        Intent intent1 = new Intent(XemHoSoActivity.this, LoginActivity.class);
                        startActivity(intent1);
                        return;
                    }
                }

            }
        });

    }
}