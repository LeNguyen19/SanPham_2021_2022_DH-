package com.example.datvexe;

import android.content.Intent;
import android.os.Bundle;
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

import model.ChiTietVeXe;
import model.VeXe;

public class ThongTinDatVeActivity extends AppCompatActivity {

    Button btn_XacNhanVe;
    TextView textView_DiemDi, textView_DiemDen, textView_NgayKhoiHanh, textView_GioKhoiHanh, textView_MaXe, textView_GiaVe, textView_ViTriGhe;
    FirebaseDatabase database = FirebaseDatabase.getInstance("https://dbquanlynhaxe-default-rtdb.asia-southeast1.firebasedatabase.app/");
    ArrayList<VeXe> listVeXe = new ArrayList<>();
    ArrayList<VeXe> listAllVeXe = new ArrayList<>();
    ArrayList<ChiTietVeXe> listChiTietVeXe = new ArrayList<>();
    String maLichChayXeN = "";

    DatabaseReference referenceVX = database.getReference("VeXe");
    DatabaseReference referenceCTVX = database.getReference("ChiTietVeXe");

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_thong_tin_dat_ve);

        textView_DiemDi = findViewById(R.id.txtKhoiHanhCuaXe);
        textView_DiemDen = findViewById(R.id.txtDiemDenCuaXe);
        textView_NgayKhoiHanh = findViewById(R.id.txtNgayKhoiHanh);
        textView_GioKhoiHanh = findViewById(R.id.txtGioKhoiHanh);
        textView_MaXe = findViewById(R.id.txtBienSoCuaXe);
        textView_GiaVe = findViewById(R.id.txtGiaVeXe);
        textView_ViTriGhe = findViewById(R.id.txtViTriGhe);

        Intent intent = getIntent();
        String diemDi = intent.getStringExtra("DiemDi").toString();
        String diemDen = intent.getStringExtra("DiemDen").toString();
        String ngayKhoiHanh = intent.getStringExtra("NgayKhoiHanh").toString();
        String giaVeNew = intent.getStringExtra("GiaVe").toString();
        String gioKhoiHanh = intent.getStringExtra("GioKhoiHanh").toString();
        String maXe = intent.getStringExtra("MaXe").toString();
        String maLichChayXe = intent.getStringExtra("MaLichChayXe").toString();
        String maKhachHang = intent.getStringExtra("MaKhachHanh").toString();
        String matKhau = intent.getStringExtra("MatKhauKH").toString();
        String vitriGhe = intent.getStringExtra("ViTriGhe").toString();

        maLichChayXeN = maLichChayXe;


        textView_DiemDi.setText(diemDi);
        textView_DiemDen.setText(diemDen);
        textView_NgayKhoiHanh.setText(ngayKhoiHanh);
        textView_GioKhoiHanh.setText(gioKhoiHanh);
        textView_MaXe.setText(maXe);
        textView_GiaVe.setText(giaVeNew);
        textView_ViTriGhe.setText(vitriGhe);

        LoadListVeXe();
        LoadAllListVeXe();
        LoadChiTietVeXe();

        btn_XacNhanVe = findViewById(R.id.btnXacNhan);

        btn_XacNhanVe.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String maVeXe = "";
                for (VeXe vx: listVeXe
                     ) {
                    if(vx.MaKhachHang.equals(maKhachHang))
                    {
                        maVeXe = vx.MaVeXe;
                    }
                }

                if(maVeXe.equals(""))
                {
                    int sl = listAllVeXe.size() + 1;
                    String ma = "VX";
                    if(sl<10)
                    {
                        ma = ma + "0000" + (sl);
                    }
                    else if(sl<100)
                    {
                        ma = ma + "000" + (sl);
                    }
                    else if(sl<1000)
                    {
                        ma = ma + "00" + (sl);
                    }
                    else if(sl<10000)
                    {
                        ma = ma + "0" + (sl);
                    }
                    else if(sl<10000)
                    {
                        ma = ma + "" + (sl);
                    }

                    VeXe vx = new VeXe();
                    vx.MaVeXe = ma;
                    vx.SoLuong = 1;
                    vx.DonGia = Integer.parseInt(giaVeNew);
                    vx.ThanhTien = Integer.parseInt(giaVeNew);
                    vx.MaLichChay_Xe = maLichChayXe;
                    vx.MaKhachHang = maKhachHang;
                    vx.MaNhanVien = "";
                    vx.fl_Xoa = 0;
                    referenceVX.child((listAllVeXe.size()+1)+"").setValue(vx);

                    ChiTietVeXe ctvx = new ChiTietVeXe();
                    ctvx.MaVeXe = ma;
                    ctvx.GheNgoi = vitriGhe;
                    referenceCTVX.child((listChiTietVeXe.size()+1)+"").setValue(ctvx);

                }
                else
                {
                    ChiTietVeXe ctvx = new ChiTietVeXe();
                    ctvx.MaVeXe = maVeXe;
                    ctvx.GheNgoi = vitriGhe;
                    referenceCTVX.child((listChiTietVeXe.size()+1)+"").setValue(ctvx);
                }

                Intent intent = new Intent(ThongTinDatVeActivity.this, DatVeThanhCongActivity.class);
                intent.putExtra("TenDangNhapKH", maKhachHang);
                intent.putExtra("MatKhauKH",matKhau);
                startActivity(intent);
            }
        });
    }
    public void LoadListVeXe()
    {
        DatabaseReference referenceLCX = database.getReference("VeXe");
        referenceLCX.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    VeXe vxF = data.getValue(VeXe.class);
                    if(vxF.MaLichChay_Xe.equals(maLichChayXeN))
                    {
                        listVeXe.add(vxF);
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                return;
            }
        });
    }

    public void LoadAllListVeXe()
    {
        DatabaseReference referenceLCX = database.getReference("VeXe");
        referenceLCX.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    VeXe vxF = data.getValue(VeXe.class);
                    listAllVeXe.add(vxF);
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                return;
            }
        });
    }
    public  void LoadChiTietVeXe()
    {
        DatabaseReference referenceLCX = database.getReference("ChiTietVeXe");
        referenceLCX.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    ChiTietVeXe ctvxF = data.getValue(ChiTietVeXe.class);
                    for (VeXe vx : listVeXe
                    ) {
                        if (vx.MaVeXe.equals(ctvxF.MaVeXe)) {
                            listChiTietVeXe.add(ctvxF);
                        }
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                return;
            }
        });
    }
}