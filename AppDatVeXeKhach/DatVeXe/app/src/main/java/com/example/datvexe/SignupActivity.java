package com.example.datvexe;

import android.content.Intent;
import android.os.Bundle;
import android.text.format.DateFormat;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.sql.Time;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import model.KhachHang;
import model.TaiKhoan;

public class SignupActivity extends AppCompatActivity {

    Button btn_signup;
    CheckBox cbNam, cbNu;
    EditText txtHoTen, txtSDT, txtNgSinh, txtCCCD, txtDiaChi;
    ArrayList<KhachHang> listKH = new ArrayList<>();
    ArrayList<TaiKhoan> listTK = new ArrayList<>();
    FirebaseDatabase database = FirebaseDatabase.getInstance("https://dbquanlynhaxe-default-rtdb.asia-southeast1.firebasedatabase.app/");
    DatabaseReference reference = database.getReference("KhachHang");

    DatabaseReference referenceTK = database.getReference("TaiKhoan");
    public SignupActivity()
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
        setContentView(R.layout.activity_signup);



        btn_signup = findViewById(R.id.btnDangKy);
        cbNam = findViewById(R.id.ckboxNam);
        cbNu = findViewById(R.id.ckboxNu);
        txtHoTen = findViewById(R.id.txtHoTen_signup);
        txtSDT = findViewById(R.id.txtSDT_signup);
        txtNgSinh = findViewById(R.id.txtNgaySinh_signup);
        txtCCCD = findViewById(R.id.txtCCCD_signup);
        txtDiaChi = findViewById(R.id.txtDiaChi_signup);

        btn_signup.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {

                if(listKH.size()!=0)
                {
                    int sl = listKH.size() + 1;
                    String ma = "KH";
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
                    Date d = new Date();
                    CharSequence s  = DateFormat.format("MM/dd/yyyy ", d.getTime());
                    if(listTK.size() !=0)
                    {
                        TaiKhoan tk = new TaiKhoan();
                        tk.TenDangNhap = ma;
                        tk.MatKhau = "123";
                        tk.MaLoaiTaiKhoan = 3;
                        tk.fl_NgayThem = s.toString();
                        tk.fl_NgaySua = "";
                        tk.fl_Xoa = 0;
                        referenceTK.child((listTK.size()+1)+"").setValue(tk);
                    }
                    KhachHang kh = new KhachHang();
                    kh.MaKhachHang = ma;
                    kh.TenKhachHang = txtHoTen.getText().toString();
                    kh.DienThoai = txtSDT.getText().toString();
                    if(cbNam.isChecked())
                    {
                        kh.GioiTinh = "Nam";
                    }
                    else
                    {
                        kh.GioiTinh = "Nữ";
                    }
                    kh.NgaySinh = txtNgSinh.getText().toString();
                    kh.DiaChi = txtDiaChi.getText().toString();
                    kh.CCCD = txtCCCD.getText().toString();
                    kh.TenDangNhap = ma;

                    kh.fl_NgayThem = s.toString();
                    kh.fl_NgaySua = "";
                    kh.fl_Xoa = 0;

                    reference.child((sl+1)+"").setValue(kh);
                    Intent intent = new Intent(SignupActivity.this, XemHoSoActivity.class);
                    intent.putExtra("TenDangNhapKH", ma);
                    intent.putExtra("MatKhauKH", "123");
                    startActivity(intent);
                    return;
                }

            }
        });
    }
}