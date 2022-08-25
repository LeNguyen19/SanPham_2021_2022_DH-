package com.example.datvexe;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageView;
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
import java.util.Calendar;

import model.KhachHang;
import model.LoTrinh;
import model.TaiKhoan;

public class ChonNgayVaDiaDiemActivity extends AppCompatActivity {

    Spinner spn_DiemDi, spn_DiemDen;
    EditText txtdate;
    ImageView cal;
    private int mNgay, mThang, mNam;
    Button btn_TiepTuc;
    ArrayList<String> listDiemDi = new ArrayList<>();
    ArrayList<String> listDiemDen = new ArrayList<>();
    ArrayList<LoTrinh> listLoTrinh = new ArrayList<>();
    //Lay du lieu lo trinh o day
    String diemDi = "";
    String diemDen = "";
    String ngayKhoiHanh = "";

    public ChonNgayVaDiaDiemActivity() {
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chon_ngay_va_dia_diem);

        Intent intent = getIntent();
        String tenDangNhap = intent.getStringExtra("TenDangNhapKH").toString();
        String matKhau = intent.getStringExtra("MatKhauKH").toString();

        ArrayAdapter<String> adapterDiemDi = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, listDiemDi);
        ArrayAdapter<String> adapterDiemDen = new ArrayAdapter<>(this, android.R.layout.simple_spinner_dropdown_item, listDiemDen);

        FirebaseDatabase database = FirebaseDatabase.getInstance("https://dbquanlynhaxe-default-rtdb.asia-southeast1.firebasedatabase.app/");
        DatabaseReference reference = database.getReference("LoTrinh");

        reference.addValueEventListener(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    LoTrinh ltF = data.getValue(LoTrinh.class);
                    listLoTrinh.add(ltF);
                    if(listDiemDi.size() == 0)
                    {
                        listDiemDi.add(ltF.DiemDi);
                    }
                    else
                    {
                        boolean co = true;
                        for (String dDi: listDiemDi
                        ) {
                            if(dDi.equals(ltF.DiemDi))
                            {
                                co = false;
                            }
                        }
                        if(co==true)
                        {
                            listDiemDi.add(ltF.DiemDi);
                        }
                    }


                    if(listDiemDen.size() == 0)
                    {
                        listDiemDen.add(ltF.DiemDen);
                    }
                    else
                    {
                        boolean coi = true;
                        for (String dDen: listDiemDen
                        ) {
                            if(dDen.equals(ltF.DiemDen))
                            {
                                coi = false;
                            }
                        }
                        if(coi==true)
                        {
                            listDiemDen.add(ltF.DiemDen);
                        }
                    }
                }
                adapterDiemDen.notifyDataSetChanged();
                adapterDiemDi.notifyDataSetChanged();
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {
                return;
            }
        });


        spn_DiemDi = findViewById(R.id.spi_DiemDi);
        spn_DiemDen = findViewById(R.id.spi_DiemDen);

        //String[] items = {"TP.Hồ Chí Minh", "Cà Mau", "Bạc Liêu", "Đồng Tháp", "Sóc Trăng", "Cần Thơ"};

        spn_DiemDi.setAdapter(adapterDiemDi);
        spn_DiemDen.setAdapter(adapterDiemDen);

        spn_DiemDi.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                String item = parent.getItemAtPosition(position).toString();
                diemDi = item;
                Toast.makeText(getApplicationContext(), "Bạn chọn điểm khởi hành là " + item,Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        spn_DiemDen.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                String item = parent.getItemAtPosition(position).toString();
                diemDen = item;
                Toast.makeText(getApplicationContext(), "Bạn chọn điểm đến là " + item,Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });

        txtdate = findViewById(R.id.date);
        cal = findViewById(R.id.cal);

        btn_TiepTuc = findViewById(R.id.btnNext1);


        cal.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                final Calendar Cal = Calendar.getInstance();
                mNgay = Cal.get(Calendar.DATE);
                mThang = Cal.get(Calendar.MONTH);
                mNam = Cal.get(Calendar.YEAR);
                DatePickerDialog datePickerDialog = new DatePickerDialog(ChonNgayVaDiaDiemActivity.this, android.R.style.Theme_DeviceDefault_Dialog, new DatePickerDialog.OnDateSetListener() {
                    @Override
                    public void onDateSet(DatePicker datePicker, int year, int month, int date) {
                        if(month+1>=10)
                        {
                            if(date>=10)
                            {
                                ngayKhoiHanh = (month+1) + "/" + date + "/" + year;
                            }
                            else
                            {
                                ngayKhoiHanh = (month+1) + "/0" + date + "/" + year;
                            }
                        }
                        else
                        {
                            if(date>=10)
                            {
                                ngayKhoiHanh = "0" + (month+1) + "/" + date + "/" + year;
                            }
                            else
                            {
                                ngayKhoiHanh = "0" + (month+1) + "/0" + date + "/" + year;
                            }
                        }

                        txtdate.setText(date + " - " + (month+1) + " - " + year);
                    }
                },mNam, mThang, mNgay);
                datePickerDialog.show();
            }
        });


        btn_TiepTuc.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                String maLoTrinhNew = "";
                String giaVeNew = "";
                for (LoTrinh lt: listLoTrinh
                     ) {
                    if(lt.DiemDi.equals(diemDi) && lt.DiemDen.equals(diemDen) && lt.fl_Xoa == 0)
                    {
                        maLoTrinhNew = lt.MaLoTrinh;
                        giaVeNew = lt.GiaVe + "";
                    }
                }

                Intent intent = new Intent(ChonNgayVaDiaDiemActivity.this, ChonGioVaChuyenXeActivity.class);
                intent.putExtra("DiemDi", diemDi);
                intent.putExtra("DiemDen", diemDen);
                intent.putExtra("MaLoTrinh", maLoTrinhNew);
                intent.putExtra("GiaVe",giaVeNew);
                intent.putExtra("NgayKhoiHanh", ngayKhoiHanh);
                intent.putExtra("TenDangNhapKH", tenDangNhap);
                intent.putExtra("MatKhauKH",matKhau);
                startActivity(intent);
            }
        });
    }
}