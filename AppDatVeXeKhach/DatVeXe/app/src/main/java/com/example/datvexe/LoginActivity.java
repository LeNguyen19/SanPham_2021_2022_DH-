package com.example.datvexe;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import XuLy.xulyDangNhap;
import model.TaiKhoan;

public class LoginActivity extends AppCompatActivity {

    ImageView logo, ten_bg, img_bg, img_bus;
    xulyDangNhap xulyDangNhap = new xulyDangNhap();
    Button btn_login;
    EditText txtTenDN, txtPass;
    TextView tvSignup;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        logo = findViewById(R.id.logo);
        ten_bg = findViewById(R.id.ten_bg);
        img_bg = findViewById(R.id.img_bg);
        img_bus = findViewById(R.id.img_bus);

        img_bg.animate().translationY(-2500).setDuration(1000).setStartDelay(1500);
        logo.animate().translationY(2300).setDuration(1000).setStartDelay(1500);
        ten_bg.animate().translationY(2300).setDuration(1000).setStartDelay(1500);
        img_bus.animate().translationY(2300).setDuration(1000).setStartDelay(1500);

        btn_login = findViewById(R.id.btnDangNhap);
        txtTenDN = findViewById(R.id.txtTenDangNhap_login);
        txtPass = findViewById(R.id.txtMatKhau_login);
        tvSignup = findViewById(R.id.tvSignup);







        //Xu ly dang nhap
        btn_login.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String taiKhoan = txtTenDN.getText().toString();
                String matKhau = txtPass.getText().toString();
                if(taiKhoan == null || matKhau == null || taiKhoan.equals("") || matKhau.equals(""))
                {
                    Toast.makeText(LoginActivity.this, "Tài khoản và mật khẩu không được trống!", Toast.LENGTH_SHORT).show();
                }
                else
                {
                    FirebaseDatabase database = FirebaseDatabase.getInstance("https://dbquanlynhaxe-default-rtdb.asia-southeast1.firebasedatabase.app/");
                    DatabaseReference reference = database.getReference("TaiKhoan");
                    reference.addValueEventListener(new ValueEventListener() {
                        @Override
                        public void onDataChange(@NonNull DataSnapshot snapshot) {
                            for (DataSnapshot data : snapshot.getChildren()) {
                                TaiKhoan tkF = data.getValue(TaiKhoan.class);
                                if(tkF.TenDangNhap.equals(taiKhoan) && tkF.MatKhau.equals(matKhau))
                                {
                                    TaiKhoan tk = new TaiKhoan();
                                    tk.TenDangNhap = tkF.TenDangNhap;
                                    tk.MatKhau = tkF.MatKhau;
                                    tk.fl_Xoa = tkF.fl_Xoa;
                                    tk.fl_NgaySua = tkF.fl_NgaySua;
                                    tk.fl_NgayThem = tkF.fl_NgayThem;
                                    tk.MaLoaiTaiKhoan = tkF.MaLoaiTaiKhoan;
                                    Intent intent = new Intent(LoginActivity.this, HomeActivity.class);
                                    intent.putExtra("TenDangNhapKH", tkF.TenDangNhap);
                                    intent.putExtra("MatKhauKH", tkF.MatKhau);
                                    startActivity(intent);
                                    return;
                                }
                            }
                            Toast.makeText(LoginActivity.this, "Tài khoản và mật khẩu không chính xác!", Toast.LENGTH_SHORT).show();
                        }

                        @Override
                        public void onCancelled(@NonNull DatabaseError error) {

                        }

                    });

                }
            }
        });

        tvSignup.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(LoginActivity.this, SignupActivity.class);
                startActivity(intent);
            }
        });
    }
}