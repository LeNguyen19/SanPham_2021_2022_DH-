package com.example.datvexe;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.webkit.WebView;
import android.webkit.WebViewClient;

public class ShowTinTucActivity extends AppCompatActivity {

    WebView webView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_show_tin_tuc);

        webView = findViewById(R.id.webView_TinTuc);
        Intent intent = getIntent();
        String link = intent.getStringExtra("linkTT");
        webView.loadUrl(link);
        webView.setWebViewClient(new WebViewClient());
    }
}