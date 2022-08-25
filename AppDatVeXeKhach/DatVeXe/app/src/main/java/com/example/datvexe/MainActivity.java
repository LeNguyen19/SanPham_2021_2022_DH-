package com.example.datvexe;

import android.os.Bundle;
import android.widget.ImageView;

import androidx.appcompat.app.AppCompatActivity;

public class MainActivity extends AppCompatActivity {

    ImageView logo, ten_bg, img_bg, img_bus;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        logo = findViewById(R.id.logo);
        ten_bg = findViewById(R.id.ten_bg);
        img_bg = findViewById(R.id.img_bg);
        img_bus = findViewById(R.id.img_bus);

        img_bg.animate().translationY(-1600).setDuration(1000).setStartDelay(1000);
        logo.animate().translationY(1400).setDuration(1000).setStartDelay(1000);
        ten_bg.animate().translationY(1400).setDuration(1000).setStartDelay(1000);
        img_bus.animate().translationY(1400).setDuration(1000).setStartDelay(1000);
    }
}