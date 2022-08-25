package XuLy;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.lang.ref.Reference;

import model.TaiKhoan;

public class xulyDangNhap {
    public  xulyDangNhap()
    {

    }

    public TaiKhoan dangNhap(String tenDangNhap,String matKhau)
    {
        try
        {
            TaiKhoan tk = new TaiKhoan();
            FirebaseDatabase database = FirebaseDatabase.getInstance("https://dbquanlynhaxe-default-rtdb.asia-southeast1.firebasedatabase.app/");
            DatabaseReference reference = database.getReference("TaiKhoan");

            reference.addValueEventListener(new ValueEventListener() {
                @Override
                public void onDataChange(@NonNull DataSnapshot snapshot) {
                    for (DataSnapshot data : snapshot.getChildren()) {
                        TaiKhoan tkF = data.getValue(TaiKhoan.class);
                        if(tkF.TenDangNhap.equals(tenDangNhap) && tkF.MatKhau.equals(matKhau))
                        {
                            tk.TenDangNhap = tkF.TenDangNhap;
                            tk.MatKhau = tkF.MatKhau;
                            tk.fl_Xoa = tkF.fl_Xoa;
                            tk.fl_NgaySua = tkF.fl_NgaySua;
                            tk.fl_NgayThem = tkF.fl_NgayThem;
                            tk.MaLoaiTaiKhoan = tkF.MaLoaiTaiKhoan;
                            return;
                        }
                        else
                        {
                            tk.TenDangNhap = null;
                            tk.MatKhau = null;
                            tk.fl_Xoa = 0;
                            tk.fl_NgaySua = null;
                            tk.fl_NgayThem = null;
                            tk.MaLoaiTaiKhoan = 0;
                        }
                    }
                }

                @Override
                public void onCancelled(@NonNull DatabaseError error) {

                }
            });
            return tk;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}
