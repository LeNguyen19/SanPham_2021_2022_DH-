package com.example.datvexe;

import android.content.Intent;
import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.ListView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;

import model.ChiTietVeXe;
import model.LichChay;
import model.LichChay_Xe;
import model.VeXe;

public class VeCuaBanActivity extends AppCompatActivity {

    ArrayList<String> listMaVeXe = new ArrayList<>();
    FirebaseDatabase database = FirebaseDatabase.getInstance("https://dbquanlynhaxe-default-rtdb.asia-southeast1.firebasedatabase.app/");
    ArrayList<ChiTietVeXe> listChiTietVeXe = new ArrayList<>();
    ArrayList<ChiTietVeXe> listCTVXCuaKhach = new ArrayList<>();
    ArrayList<String> loadCTVX = new ArrayList<>();
    ArrayAdapter<String> adapterCTVXCuaKhach;
    ListView listView_CTVX;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ve_cua_ban);

        listView_CTVX = findViewById(R.id.lvDanhSachCTVX);

        Intent intent = getIntent();
        String tenDangNhap = intent.getStringExtra("TenDangNhapKH").toString();
        String matKhau = intent.getStringExtra("MatKhauKH").toString();
        String stt = intent.getStringExtra("STT").toString();

        int STT = Integer.parseInt(stt);
        String k = "Key";
        boolean co = true;
        int i = 1;
        while (co==true)
        {
            if(i<=STT)
            {
                String key = intent.getStringExtra(k+i).toString();
                listMaVeXe.add(key);
                i++;
            }
            else
            {
                co = false;
            }
        }

        for (String msVx: listMaVeXe
             ) {
            for (ChiTietVeXe ctvx: listChiTietVeXe
                 ) {
                if(ctvx.MaVeXe.equals(msVx))
                {
                    listCTVXCuaKhach.add(ctvx);
                    loadCTVX.add(ctvx.MaVeXe+" "+ctvx.GheNgoi);
                }
            }
        }

        adapterCTVXCuaKhach = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, loadCTVX);
        DatabaseReference referenceLCX = database.getReference("ChiTietVeXe");
        referenceLCX.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    ChiTietVeXe ctvxF = data.getValue(ChiTietVeXe.class);
                    for (String msVx : listMaVeXe
                    ) {
                        if (msVx.equals(ctvxF.MaVeXe)) {
                            listCTVXCuaKhach.add(ctvxF);
                            loadCTVX.add(ctvxF.MaVeXe + " " + ctvxF.GheNgoi);
                        }
                    }
                }
                adapterCTVXCuaKhach.notifyDataSetChanged();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                return;
            }
        });
        listView_CTVX.setAdapter(adapterCTVXCuaKhach);

    }
}