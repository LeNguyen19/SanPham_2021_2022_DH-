package com.example.datvexe;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.appcompat.app.AppCompatActivity;

public class DatVeThanhCongActivity extends AppCompatActivity {

    Button btn_back;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dat_ve_thanh_cong);

        Intent intent = getIntent();
        String tenDangNhap = intent.getStringExtra("TenDangNhapKH").toString();
        String matKhau = intent.getStringExtra("MatKhauKH").toString();

        btn_back = findViewById(R.id.btnBack);
        btn_back.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(DatVeThanhCongActivity.this, HomeActivity.class);
                intent.putExtra("TenDangNhapKH", tenDangNhap);
                intent.putExtra("MatKhauKH",matKhau);
                startActivity(intent);
            }
        });
    }
}