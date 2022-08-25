package Adapter;

import android.content.Context;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.BaseAdapter;
import android.widget.TextView;

import com.example.datvexe.R;

import java.util.ArrayList;

import model.CHUYENXE;

public class ListChuyenXe extends BaseAdapter {
    private ArrayList<CHUYENXE> data_xe;
    private Context context;

    public void clearData()
    {
        data_xe.clear();
    }


    public ListChuyenXe(Context _context, ArrayList<CHUYENXE> _data_xe){
        data_xe = _data_xe;
        context = _context;
    }

    @Override
    public int getCount() {
        return data_xe.size();
    }

    @Override
    public Object getItem(int i) {
        return data_xe.get(i);
    }

    @Override
    public long getItemId(int i) {
        return i;
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        View viewXe;
        if(view == null) {
            viewXe = View.inflate(viewGroup.getContext(), R.layout.list_chuyenxe, null);
        }
        else{
            viewXe = view;
        }
        TextView tenLoTrinh = viewXe.findViewById(R.id.txtTenLoTrinh);
        TextView bienSoXe = viewXe.findViewById(R.id.txtBienSoXe);
        TextView giaVe = viewXe.findViewById(R.id.txtGiaVe);

        CHUYENXE xe = (CHUYENXE)getItem(i);

        tenLoTrinh.setText(xe.getTenLoTrinh());
        bienSoXe.setText(xe.getBienSoXe());
        giaVe.setText(xe.getGiaVe()+"");

        return viewXe;

    }
}
