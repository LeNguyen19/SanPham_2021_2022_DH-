package com.example.datvexe;


import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.viewpager.widget.ViewPager;

import com.google.android.material.tabs.TabItem;
import com.google.android.material.tabs.TabLayout;
import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;

import model.ChiTietVeXe;
import model.VeXe;

public class ChonGheActivity extends AppCompatActivity {

    Button button_Tang1, button_Tang2;
    Button button_Key01, button_Key02, button_Key03, button_Key04, button_Key05;
    Button button_Key06, button_Key07, button_Key08, button_Key09, button_Key10;
    Button button_Key11, button_Key12, button_Key13, button_Key14, button_Key15;
    Button button_Key16, button_Key17, button_Key18, button_Key19, button_Key20;
    Button button_Key21, button_Key22, button_Key23;

    FirebaseDatabase database = FirebaseDatabase.getInstance("https://dbquanlynhaxe-default-rtdb.asia-southeast1.firebasedatabase.app/");
    ArrayList<VeXe> listVeXe = new ArrayList<>();
    String maLichChayXeN = "";
    ArrayList<ChiTietVeXe> listChiTietVeXe = new ArrayList<>();
    String key = "";
    String diemDi = "";
    String diemDen = "";
    String ngayKhoiHanh = "";
    String giaVeNew = "";
    String gioKhoiHanh = "";
    String maXe = "";
    String maKH = "";
    String matKhau = "";

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chon_ghe);

        //Ánh xạ dữ liệu
        button_Tang1 = findViewById(R.id.button);
        button_Tang2 = findViewById(R.id.button2);

        button_Key01 = findViewById(R.id.btn_key1);
        button_Key02 = findViewById(R.id.btn_key2);
        button_Key03 = findViewById(R.id.btn_key3);
        button_Key04 = findViewById(R.id.btn_key4);
        button_Key05 = findViewById(R.id.btn_key5);
        button_Key06 = findViewById(R.id.btn_key6);
        button_Key07 = findViewById(R.id.btn_key7);
        button_Key08 = findViewById(R.id.btn_key8);
        button_Key09 = findViewById(R.id.btn_key9);
        button_Key10 = findViewById(R.id.btn_key10);
        button_Key11 = findViewById(R.id.btn_key11);
        button_Key12 = findViewById(R.id.btn_key12);
        button_Key13 = findViewById(R.id.btn_key13);
        button_Key14 = findViewById(R.id.btn_key14);
        button_Key15 = findViewById(R.id.btn_key15);
        button_Key16 = findViewById(R.id.btn_key16);
        button_Key17 = findViewById(R.id.btn_key17);
        button_Key18 = findViewById(R.id.btn_key18);
        button_Key19 = findViewById(R.id.btn_key19);
        button_Key20 = findViewById(R.id.btn_key20);
        button_Key21 = findViewById(R.id.btn_key21);
        button_Key22 = findViewById(R.id.btn_key22);
        button_Key23 = findViewById(R.id.btn_key23);


        Intent intent = getIntent();
        String diemDi1 = intent.getStringExtra("DiemDi").toString();
        String diemDen1 = intent.getStringExtra("DiemDen").toString();
        String ngayKhoiHanh1 = intent.getStringExtra("NgayKhoiHanh").toString();
        String giaVeNew1 = intent.getStringExtra("GiaVe").toString();
        String maLoTrinh = intent.getStringExtra("MaLoTrinh").toString();
        String gioKhoiHanh1 = intent.getStringExtra("GioKhoiHanh").toString();
        String tenDangNhap1 = intent.getStringExtra("TenDangNhapKH").toString();
        String matKhau1 = intent.getStringExtra("MatKhauKH").toString();
        String maXe1 = intent.getStringExtra("MaXe").toString();
        String maLichChay = intent.getStringExtra("MaLichChay").toString();
        String maLichChayXe = intent.getStringExtra("MaLichChayXe").toString();

        maLichChayXeN = maLichChayXe;
        diemDi = diemDi1;
        diemDen = diemDen1;
        ngayKhoiHanh = ngayKhoiHanh1;
        giaVeNew = giaVeNew1;
        gioKhoiHanh = gioKhoiHanh1;
        maKH = tenDangNhap1;
        maXe = maXe1;
        matKhau = matKhau1;

        LoadListVeXe();
        LoadChiTietVeXe();

        button_Tang1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                LoadMoKey();
                LoadTang1(listChiTietVeXe);
                key = "A";
            }
        });

        button_Tang2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                LoadMoKey();
                LoadTang2(listChiTietVeXe);
                key = "B";
            }
        });

        button_Key01.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key01);
            }
        });
        button_Key02.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key02);
            }
        });
        button_Key03.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key03);
            }
        });
        button_Key04.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key04);
            }
        });
        button_Key05.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key05);
            }
        });
        button_Key06.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key06);
            }
        });
        button_Key07.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key07);
            }
        });
        button_Key08.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key08);
            }
        });
        button_Key09.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key09);
            }
        });
        button_Key10.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key10);
            }
        });
        button_Key11.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key11);
            }
        });
        button_Key12.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key12);
            }
        });
        button_Key13.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key13);
            }
        });
        button_Key14.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key14);
            }
        });
        button_Key15.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key15);
            }
        });
        button_Key16.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key16);
            }
        });
        button_Key17.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key17);
            }
        });
        button_Key18.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key18);
            }
        });
        button_Key19.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key19);
            }
        });
        button_Key20.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key20);
            }
        });
        button_Key21.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key21);
            }
        });
        button_Key22.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key22);
            }
        });
        button_Key23.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                setButtonGheNgoi(button_Key23);
            }
        });
    }

    public void setButtonGheNgoi(Button btn)
    {
        Intent intent1 = new Intent(ChonGheActivity.this, ThongTinDatVeActivity.class);
        String vitriGhe = "";
        if(key.equals(""))
        {
            return;
        }
        else if(key.equals("A"))
        {
            vitriGhe = btn.getText() + "A";
        }
        else
        {
            vitriGhe = btn.getText() + "B";
        }
        intent1.putExtra("DiemDi", diemDi);
        intent1.putExtra("DiemDen", diemDen);
        intent1.putExtra("NgayKhoiHanh", ngayKhoiHanh);
        intent1.putExtra("GioKhoiHanh", gioKhoiHanh);
        intent1.putExtra("GiaVe",giaVeNew);
        intent1.putExtra("MaXe", maXe);
        intent1.putExtra("MaKhachHanh",maKH);
        intent1.putExtra("MatKhauKH", matKhau);
        intent1.putExtra("MaLichChayXe", maLichChayXeN);
        intent1.putExtra("ViTriGhe", vitriGhe);
        startActivity(intent1);
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
    public void LoadTang1(ArrayList<ChiTietVeXe> listChiTietVX)
    {
        for (ChiTietVeXe ctvx: listChiTietVX
             ) {
            if(ctvx.GheNgoi.equals("01A"))
            {
                button_Key01.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("02A"))
            {
                button_Key02.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("03A"))
            {
                button_Key03.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("04A"))
            {
                button_Key04.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("05A"))
            {
                button_Key05.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("06A"))
            {
                button_Key06.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("07A"))
            {
                button_Key07.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("08A"))
            {
                button_Key08.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("09A"))
            {
                button_Key09.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("10A"))
            {
                button_Key10.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("11A"))
            {
                button_Key11.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("12A"))
            {
                button_Key12.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("13A"))
            {
                button_Key13.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("14A"))
            {
                button_Key14.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("15A"))
            {
                button_Key15.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("16A"))
            {
                button_Key16.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("17A"))
            {
                button_Key17.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("18A"))
            {
                button_Key18.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("19A"))
            {
                button_Key19.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("20A"))
            {
                button_Key20.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("21A"))
            {
                button_Key21.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("22A"))
            {
                button_Key22.setEnabled(false);
            }
            else if(ctvx.GheNgoi.equals("23A"))
            {
                button_Key23.setEnabled(false);
            }
        }
    }
    public void LoadTang2(ArrayList<ChiTietVeXe> listChiTietVX) {
        for (ChiTietVeXe ctvx : listChiTietVX
        ) {
            if (ctvx.GheNgoi.equals("01B")) {
                button_Key01.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("02B")) {
                button_Key02.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("03B")) {
                button_Key03.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("04B")) {
                button_Key04.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("05B")) {
                button_Key05.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("06B")) {
                button_Key06.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("07B")) {
                button_Key07.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("08B")) {
                button_Key08.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("09B")) {
                button_Key09.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("10B")) {
                button_Key10.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("11B")) {
                button_Key11.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("12B")) {
                button_Key12.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("13B")) {
                button_Key13.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("14B")) {
                button_Key14.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("15B")) {
                button_Key15.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("16B")) {
                button_Key16.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("17B")) {
                button_Key17.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("18B")) {
                button_Key18.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("19B")) {
                button_Key19.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("20B")) {
                button_Key20.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("21B")) {
                button_Key21.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("22B")) {
                button_Key22.setEnabled(false);
            } else if (ctvx.GheNgoi.equals("23B")) {
                button_Key23.setEnabled(false);
            }
        }
    }

    public void LoadMoKey()
    {
        button_Key01.setEnabled(true);
        button_Key02.setEnabled(true);
        button_Key03.setEnabled(true);
        button_Key04.setEnabled(true);
        button_Key05.setEnabled(true);
        button_Key06.setEnabled(true);
        button_Key07.setEnabled(true);
        button_Key08.setEnabled(true);
        button_Key09.setEnabled(true);
        button_Key10.setEnabled(true);
        button_Key11.setEnabled(true);
        button_Key12.setEnabled(true);
        button_Key13.setEnabled(true);
        button_Key14.setEnabled(true);
        button_Key15.setEnabled(true);
        button_Key16.setEnabled(true);
        button_Key17.setEnabled(true);
        button_Key18.setEnabled(true);
        button_Key19.setEnabled(true);
        button_Key20.setEnabled(true);
        button_Key21.setEnabled(true);
        button_Key22.setEnabled(true);
        button_Key23.setEnabled(true);
    }
}
