package com.example.datvexe;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Calendar;

import model.LichChay;
import model.LichChay_Xe;
import model.VeXe;

public class HomeActivity extends AppCompatActivity {

    Button btn_DatVe, btn_HoSo, btn_TinTuc, btn_VeCuaBan;
    FirebaseDatabase database = FirebaseDatabase.getInstance("https://dbquanlynhaxe-default-rtdb.asia-southeast1.firebasedatabase.app/");
    ArrayList<LichChay> listLichChay = new ArrayList<>();
    ArrayList<LichChay_Xe> listLichChayXe = new ArrayList<>();
    ArrayList<String> listMaLichChay = new ArrayList<>();
    ArrayList<String> listMaLichChayXe = new ArrayList<>();
    ArrayList<VeXe> listVeXe = new ArrayList<>();
    ArrayList<String> listMaVeXe = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_home);

        btn_DatVe = findViewById(R.id.btnDatVe);
        btn_HoSo = findViewById(R.id.btnXemHoSo);
        btn_TinTuc = findViewById(R.id.btnXemTinTuc);
        btn_VeCuaBan = findViewById(R.id.btnVeCuaBan);

        Intent intent = getIntent();
        String tenDangNhap = intent.getStringExtra("TenDangNhapKH").toString();
        String matKhau = intent.getStringExtra("MatKhauKH").toString();

        LoadListLichChay();
        LoadListLichChayXe();
        LoadListVeXe();

        btn_DatVe.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(HomeActivity.this, ChonNgayVaDiaDiemActivity.class);
                intent.putExtra("TenDangNhapKH", tenDangNhap);
                intent.putExtra("MatKhauKH",matKhau);
                startActivity(intent);
            }
        });

        btn_HoSo.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(HomeActivity.this, XemHoSoActivity.class);
                intent.putExtra("TenDangNhapKH", tenDangNhap);
                intent.putExtra("MatKhauKH",matKhau);
                startActivity(intent);
            }
        });

        btn_TinTuc.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                Intent intent = new Intent(HomeActivity.this, TinTucActivity.class);
                intent.putExtra("TenDangNhapKH", tenDangNhap);
                intent.putExtra("MatKhauKH",matKhau);
                startActivity(intent);
            }
        });

        btn_VeCuaBan.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Date a = Calendar.getInstance().getTime();
                int ngay = a.getDay();
                int thang = a.getMonth();
                int nam = 2022;

                for (LichChay lc: listLichChay
                ) {
                    String[] separated = lc.NgayKhoiHanh.split("/");
                    int ngay1 = Integer.parseInt(separated[1]);
                    int thang1 = Integer.parseInt(separated[0]);
                    int nam1 = Integer.parseInt(separated[2]);
                    if(nam1>nam)
                    {
                        listMaLichChay.add(lc.MaLichChay);
                    }
                    else if(nam1==nam)
                    {
                        if(thang1>thang)
                        {
                            listMaLichChay.add(lc.MaLichChay);
                        }
                        else if(thang1 == thang)
                        {
                            if(ngay1>ngay)
                            {
                                listMaLichChay.add(lc.MaLichChay);
                            }
                            else if(ngay1 == ngay)
                            {
                                listMaLichChay.add(lc.MaLichChay);
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                for (String maLichTrinh: listMaLichChay
                ) {
                    for (LichChay_Xe lcx: listLichChayXe
                    ) {
                        if(lcx.MaLichChay.equals(maLichTrinh))
                        {
                            listMaLichChayXe.add(lcx.MaLichChay_Xe);
                        }
                    }
                }


                for (String maLCX: listMaLichChayXe
                ) {
                    for (VeXe vx: listVeXe
                         ) {
                        if(vx.MaLichChay_Xe.equals(maLCX) && vx.MaKhachHang.equals(tenDangNhap))
                        {
                            listMaVeXe.add(vx.MaVeXe);
                        }
                    }
                }

                Intent intent = new Intent(HomeActivity.this, VeCuaBanActivity.class);
                intent.putExtra("TenDangNhapKH", tenDangNhap);
                intent.putExtra("MatKhauKH",matKhau);
                intent.putExtra("STT", listMaVeXe.size()+"");
                String key = "Key";
                int i = 1;
                for (String maVX: listMaVeXe
                     ) {
                    intent.putExtra(key+i,maVX);
                    i++;
                }
                startActivity(intent);
            }
        });
    }

    public void LoadListLichChay()
    {
        DatabaseReference reference = database.getReference("LichChay");
        reference.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    LichChay lcF = data.getValue(LichChay.class);
                    listLichChay.add(lcF);
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                return;
            }
        });
    }
    public void LoadListLichChayXe()
    {
        DatabaseReference referenceLCX = database.getReference("LichChay_Xe");
        referenceLCX.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    LichChay_Xe lcxF = data.getValue(LichChay_Xe.class);
                    listLichChayXe.add(lcxF);
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                return;
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
                    listVeXe.add(vxF);
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                return;
            }
        });
    }
}