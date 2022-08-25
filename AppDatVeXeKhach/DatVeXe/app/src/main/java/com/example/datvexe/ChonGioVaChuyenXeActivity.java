package com.example.datvexe;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Adapter;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.List;
import Adapter.ListChuyenXe;
import model.CHUYENXE;
import model.LichChay;
import model.LichChay_Xe;
import model.Xe;

public class ChonGioVaChuyenXeActivity extends AppCompatActivity {

    Spinner spn_Gio;

    ListView lstv;
    ArrayList<LichChay> listLichChay = new ArrayList<>();
    ArrayList<LichChay_Xe> listLichChay_Xe = new ArrayList<>();
    ArrayList<Xe> listXe = new ArrayList<>();
    ArrayList<String> listGioKhoiHanh = new ArrayList<>();
    ArrayAdapter<String> adapterGioKhoiHanh;
    ArrayList<String> listMaXe = new ArrayList<>();
    ArrayList<CHUYENXE> listChuyenXe = new ArrayList<>();
    ListChuyenXe adapterChuyenXe;
    String maLichChayNew = null;
    String gioKhoiHanh = null;
    FirebaseDatabase database = FirebaseDatabase.getInstance("https://dbquanlynhaxe-default-rtdb.asia-southeast1.firebasedatabase.app/");

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chon_gio_va_chuyen_xe);

        Intent intent = getIntent();
        String diemDi = intent.getStringExtra("DiemDi").toString();
        String diemDen = intent.getStringExtra("DiemDen").toString();
        String ngayKhoiHanh = intent.getStringExtra("NgayKhoiHanh").toString();
        String giaVeNew = intent.getStringExtra("GiaVe").toString();
        String maLoTrinh = intent.getStringExtra("MaLoTrinh").toString();
        String tenDangNhap = intent.getStringExtra("TenDangNhapKH").toString();
        String matKhau = intent.getStringExtra("MatKhauKH").toString();

        LoadData(maLoTrinh);
        lstv = findViewById(R.id.listviewCX);
        spn_Gio.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                String item = parent.getItemAtPosition(position).toString();
                for (LichChay lc: listLichChay
                     ) {
                    if(lc.GioKhoiHanh.equals(item) && lc.MaLoTrinh.equals(maLoTrinh))
                    {
                        maLichChayNew = lc.MaLichChay;
                        LoadDanhSachMaXe(maLichChayNew);
                        listChuyenXe = LoadDanhSachChuyenXe(listMaXe,diemDi,diemDen,giaVeNew);
                        //adapterChuyenXe.notifyDataSetChanged();
                        adapterChuyenXe = new ListChuyenXe(ChonGioVaChuyenXeActivity.this, listChuyenXe);
                        lstv.setAdapter(adapterChuyenXe);
                        Toast.makeText(getApplicationContext(), "Bạn chọn giờ khởi hành là " + maLichChayNew,Toast.LENGTH_SHORT).show();
                    }
                }
                gioKhoiHanh = item;
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });
        lstv.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                CHUYENXE xe_item = (CHUYENXE) adapterChuyenXe.getItem(i);
                String maXe = null;
                for (Xe x: listXe
                     ) {
                    if(x.BienSo.equals(xe_item.getBienSoXe()))
                    {
                        maXe = x.MaXe;
                    }
                }
                String maLichChay = maLichChayNew;
                String maLichChayXe = null;
                for (LichChay_Xe lcx: listLichChay_Xe
                     ) {
                    if(lcx.MaLichChay.equals(maLichChay) && lcx.MaXe.equals(maXe))
                    {
                        maLichChayXe = lcx.MaLichChay_Xe;
                    }
                }

                Toast.makeText(ChonGioVaChuyenXeActivity.this, "Bạn chọn xe có biển số là " + xe_item.getBienSoXe(), Toast.LENGTH_LONG).show();
                Intent intent = new Intent(ChonGioVaChuyenXeActivity.this, ChonGheActivity.class);
                intent.putExtra("DiemDi", diemDi);
                intent.putExtra("DiemDen", diemDen);
                intent.putExtra("MaLoTrinh", maLoTrinh);
                intent.putExtra("GiaVe",giaVeNew);
                intent.putExtra("NgayKhoiHanh", ngayKhoiHanh);
                intent.putExtra("GioKhoiHanh", gioKhoiHanh);
                intent.putExtra("TenDangNhapKH", tenDangNhap);
                intent.putExtra("MatKhauKH",matKhau);
                intent.putExtra("MaXe", maXe);
                intent.putExtra("MaLichChay", maLichChay);
                intent.putExtra("MaLichChayXe", maLichChayXe);
                startActivity(intent);
            }
        });


    }
    public void LoadData(String maLoTrinh)
    {
        //Lấy danh sách lịch chạy
        adapterGioKhoiHanh = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, listGioKhoiHanh);
        DatabaseReference reference = database.getReference("LichChay");
        reference.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    LichChay lcF = data.getValue(LichChay.class);
                    listLichChay.add(lcF);
                }
                LoadDanhSachXe(maLoTrinh);
                adapterGioKhoiHanh.notifyDataSetChanged();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                return;
            }
        });
        spn_Gio = findViewById(R.id.spi_Gio);
        spn_Gio.setAdapter(adapterGioKhoiHanh);
        //Lấy danh sách lịch chạy xe
        DatabaseReference referenceLCX = database.getReference("LichChay_Xe");
        referenceLCX.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    LichChay_Xe lcxF = data.getValue(LichChay_Xe.class);
                    listLichChay_Xe.add(lcxF);
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                return;
            }
        });
        //Lấy danh sách xe
        DatabaseReference referenceXe = database.getReference("Xe");
        referenceXe.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    Xe xeF = data.getValue(Xe.class);
                    listXe.add(xeF);
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                return;
            }
        });
    }
    public void LoadDanhSachXe(String maLoTrinh)
    {
        for (LichChay lc: listLichChay
        ) {
            if(lc.MaLoTrinh.equals(maLoTrinh))
            {
                listGioKhoiHanh.add(lc.GioKhoiHanh);
            }
            adapterGioKhoiHanh.notifyDataSetChanged();
        }
    }

    public void LoadDanhSachMaXe(String maLichChay)
    {
        listMaXe.clear();
        for (LichChay_Xe lcx: listLichChay_Xe
             ) {
            if(lcx.MaLichChay.equals(maLichChay))
            {
                listMaXe.add(lcx.MaXe);
            }
        }
    }

    public ArrayList<CHUYENXE> LoadDanhSachChuyenXe(ArrayList<String> listMaXeNew, String diemDi, String diemDen, String giaVe)
    {
        ArrayList<CHUYENXE> listCX = new ArrayList<>();
        for (String maXe: listMaXeNew
             ) {
            for (Xe x: listXe
            ) {
                if(x.MaXe.equals(maXe))
                {
                    CHUYENXE cx =new CHUYENXE();
                    cx.tenLoTrinh = diemDen + " - " + diemDi;
                    cx.giaVe = giaVe;
                    cx.bienSoXe = x.BienSo;
                    listCX.add(cx);
                }
            }
        }
        return listCX;
    }
}

