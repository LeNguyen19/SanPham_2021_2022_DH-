package com.example.datvexe;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import androidx.appcompat.app.AppCompatActivity;

public class CapTaiKhoanActivity extends AppCompatActivity {

    Button btn_DangKy;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cap_tai_khoan);

        btn_DangKy = findViewById(R.id.btnDangNhap);

        btn_DangKy.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(CapTaiKhoanActivity.this, HomeActivity.class);
                startActivity(intent);
            }
        });
    }
}