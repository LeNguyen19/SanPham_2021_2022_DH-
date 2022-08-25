namespace QLDatVeXe
{
    partial class frmDijkstra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.cbbKetThuc = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.cbbBatDau = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.panel8 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbbDiaDiem = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.btnTimDuongDiNganNhat = new DevComponents.DotNetBar.ButtonX();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.panel17 = new System.Windows.Forms.Panel();
            this.panel18 = new System.Windows.Forms.Panel();
            this.lbKetQua = new System.Windows.Forms.Label();
            this.panel19 = new System.Windows.Forms.Panel();
            this.panel20 = new System.Windows.Forms.Panel();
            this.dtgvQuangDuong = new System.Windows.Forms.DataGridView();
            this.MaTrungChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemDi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiemDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuangDuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaDiaChiTrungChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fl_Xoa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChiTrungChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel6.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel17.SuspendLayout();
            this.panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvQuangDuong)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 724);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(1567, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 724);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(10, 714);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1557, 10);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(10, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1557, 10);
            this.panel4.TabIndex = 3;
            // 
            // labelX1
            // 
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelX1.ForeColor = System.Drawing.Color.MediumBlue;
            this.labelX1.Location = new System.Drawing.Point(10, 10);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(1557, 33);
            this.labelX1.TabIndex = 4;
            this.labelX1.Text = "TÌM ĐƯỜNG ĐI NGẮN NHẤT DIJKSTRA";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(10, 43);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1557, 10);
            this.panel5.TabIndex = 5;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.panel11);
            this.panel6.Controls.Add(this.panel10);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.panel8);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(10, 53);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1557, 49);
            this.panel6.TabIndex = 6;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.White;
            this.panel11.Controls.Add(this.cbbKetThuc);
            this.panel11.Controls.Add(this.labelX4);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel11.Location = new System.Drawing.Point(1052, 0);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(505, 49);
            this.panel11.TabIndex = 4;
            // 
            // cbbKetThuc
            // 
            this.cbbKetThuc.DisplayMember = "Text";
            this.cbbKetThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbKetThuc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbKetThuc.FormattingEnabled = true;
            this.cbbKetThuc.ItemHeight = 34;
            this.cbbKetThuc.Location = new System.Drawing.Point(81, 0);
            this.cbbKetThuc.Name = "cbbKetThuc";
            this.cbbKetThuc.Size = new System.Drawing.Size(424, 40);
            this.cbbKetThuc.TabIndex = 8;
            // 
            // labelX4
            // 
            this.labelX4.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelX4.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.labelX4.Location = new System.Drawing.Point(0, 0);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(81, 49);
            this.labelX4.TabIndex = 6;
            this.labelX4.Text = "Kết thúc:";
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(1021, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(11, 49);
            this.panel10.TabIndex = 3;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Controls.Add(this.cbbBatDau);
            this.panel9.Controls.Add(this.labelX3);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel9.Location = new System.Drawing.Point(516, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(505, 49);
            this.panel9.TabIndex = 2;
            // 
            // cbbBatDau
            // 
            this.cbbBatDau.DisplayMember = "Text";
            this.cbbBatDau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbBatDau.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbBatDau.FormattingEnabled = true;
            this.cbbBatDau.ItemHeight = 34;
            this.cbbBatDau.Location = new System.Drawing.Point(81, 0);
            this.cbbBatDau.Name = "cbbBatDau";
            this.cbbBatDau.Size = new System.Drawing.Size(424, 40);
            this.cbbBatDau.TabIndex = 8;
            // 
            // labelX3
            // 
            this.labelX3.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelX3.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.labelX3.Location = new System.Drawing.Point(0, 0);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(81, 49);
            this.labelX3.TabIndex = 6;
            this.labelX3.Text = "Bắt đầu:";
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(505, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(11, 49);
            this.panel8.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.cbbDiaDiem);
            this.panel7.Controls.Add(this.labelX2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(505, 49);
            this.panel7.TabIndex = 0;
            // 
            // cbbDiaDiem
            // 
            this.cbbDiaDiem.DisplayMember = "Text";
            this.cbbDiaDiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbbDiaDiem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbbDiaDiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbDiaDiem.FormattingEnabled = true;
            this.cbbDiaDiem.ItemHeight = 34;
            this.cbbDiaDiem.Location = new System.Drawing.Point(93, 0);
            this.cbbDiaDiem.Name = "cbbDiaDiem";
            this.cbbDiaDiem.Size = new System.Drawing.Size(412, 40);
            this.cbbDiaDiem.TabIndex = 7;
            this.cbbDiaDiem.SelectedIndexChanged += new System.EventHandler(this.cbbDiaDiem_SelectedIndexChanged);
            // 
            // labelX2
            // 
            this.labelX2.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelX2.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.labelX2.Location = new System.Drawing.Point(0, 0);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(93, 49);
            this.labelX2.TabIndex = 6;
            this.labelX2.Text = "Địa điểm:";
            // 
            // panel12
            // 
            this.panel12.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel12.Location = new System.Drawing.Point(10, 102);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(1557, 10);
            this.panel12.TabIndex = 7;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.panel15);
            this.panel13.Controls.Add(this.panel14);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel13.Location = new System.Drawing.Point(10, 112);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(1557, 44);
            this.panel13.TabIndex = 8;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.btnTimDuongDiNganNhat);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel15.Location = new System.Drawing.Point(658, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(212, 44);
            this.panel15.TabIndex = 1;
            // 
            // btnTimDuongDiNganNhat
            // 
            this.btnTimDuongDiNganNhat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTimDuongDiNganNhat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTimDuongDiNganNhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTimDuongDiNganNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnTimDuongDiNganNhat.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnTimDuongDiNganNhat.Location = new System.Drawing.Point(0, 0);
            this.btnTimDuongDiNganNhat.Name = "btnTimDuongDiNganNhat";
            this.btnTimDuongDiNganNhat.Size = new System.Drawing.Size(212, 44);
            this.btnTimDuongDiNganNhat.TabIndex = 37;
            this.btnTimDuongDiNganNhat.Text = "Tìm Dijkstra";
            this.btnTimDuongDiNganNhat.Click += new System.EventHandler(this.btnTimDuongDiNganNhat_Click);
            // 
            // panel14
            // 
            this.panel14.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel14.Location = new System.Drawing.Point(0, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(658, 44);
            this.panel14.TabIndex = 0;
            // 
            // panel16
            // 
            this.panel16.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel16.Location = new System.Drawing.Point(10, 156);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(1557, 10);
            this.panel16.TabIndex = 9;
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.panel18);
            this.panel17.Controls.Add(this.panel19);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel17.Location = new System.Drawing.Point(10, 166);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(1557, 44);
            this.panel17.TabIndex = 10;
            // 
            // panel18
            // 
            this.panel18.Controls.Add(this.lbKetQua);
            this.panel18.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel18.Location = new System.Drawing.Point(349, 0);
            this.panel18.Name = "panel18";
            this.panel18.Size = new System.Drawing.Size(895, 44);
            this.panel18.TabIndex = 1;
            // 
            // lbKetQua
            // 
            this.lbKetQua.AutoSize = true;
            this.lbKetQua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbKetQua.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lbKetQua.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbKetQua.Location = new System.Drawing.Point(0, 0);
            this.lbKetQua.Name = "lbKetQua";
            this.lbKetQua.Size = new System.Drawing.Size(64, 25);
            this.lbKetQua.TabIndex = 0;
            this.lbKetQua.Text = "label1";
            // 
            // panel19
            // 
            this.panel19.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel19.Location = new System.Drawing.Point(0, 0);
            this.panel19.Name = "panel19";
            this.panel19.Size = new System.Drawing.Size(349, 44);
            this.panel19.TabIndex = 0;
            // 
            // panel20
            // 
            this.panel20.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel20.Location = new System.Drawing.Point(10, 210);
            this.panel20.Name = "panel20";
            this.panel20.Size = new System.Drawing.Size(1557, 10);
            this.panel20.TabIndex = 11;
            // 
            // dtgvQuangDuong
            // 
            this.dtgvQuangDuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvQuangDuong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaTrungChuyen,
            this.DiemDi,
            this.DiemDen,
            this.QuangDuong,
            this.MaDiaChiTrungChuyen,
            this.fl_Xoa,
            this.DiaChiTrungChuyen});
            this.dtgvQuangDuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvQuangDuong.Location = new System.Drawing.Point(10, 220);
            this.dtgvQuangDuong.Name = "dtgvQuangDuong";
            this.dtgvQuangDuong.RowTemplate.Height = 24;
            this.dtgvQuangDuong.Size = new System.Drawing.Size(1557, 494);
            this.dtgvQuangDuong.TabIndex = 12;
            // 
            // MaTrungChuyen
            // 
            this.MaTrungChuyen.DataPropertyName = "MaTrungChuyen";
            this.MaTrungChuyen.HeaderText = "Mã trung chuyển";
            this.MaTrungChuyen.Name = "MaTrungChuyen";
            // 
            // DiemDi
            // 
            this.DiemDi.DataPropertyName = "DiemDi";
            this.DiemDi.HeaderText = "Điểm đi";
            this.DiemDi.Name = "DiemDi";
            // 
            // DiemDen
            // 
            this.DiemDen.DataPropertyName = "DiemDen";
            this.DiemDen.HeaderText = "Điểm đến";
            this.DiemDen.Name = "DiemDen";
            // 
            // QuangDuong
            // 
            this.QuangDuong.DataPropertyName = "QuangDuong";
            this.QuangDuong.HeaderText = "Quãng đường";
            this.QuangDuong.Name = "QuangDuong";
            // 
            // MaDiaChiTrungChuyen
            // 
            this.MaDiaChiTrungChuyen.DataPropertyName = "MaDiaChiTrungChuyen";
            this.MaDiaChiTrungChuyen.HeaderText = "MaDiaChiTrungChuyen";
            this.MaDiaChiTrungChuyen.Name = "MaDiaChiTrungChuyen";
            this.MaDiaChiTrungChuyen.Visible = false;
            // 
            // fl_Xoa
            // 
            this.fl_Xoa.DataPropertyName = "fl_Xoa";
            this.fl_Xoa.HeaderText = "Xoa";
            this.fl_Xoa.Name = "fl_Xoa";
            this.fl_Xoa.Visible = false;
            // 
            // DiaChiTrungChuyen
            // 
            this.DiaChiTrungChuyen.DataPropertyName = "DiaChiTrungChuyen";
            this.DiaChiTrungChuyen.HeaderText = "DiaChiTrungChuyen";
            this.DiaChiTrungChuyen.Name = "DiaChiTrungChuyen";
            this.DiaChiTrungChuyen.Visible = false;
            // 
            // frmDijkstra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1577, 724);
            this.Controls.Add(this.dtgvQuangDuong);
            this.Controls.Add(this.panel20);
            this.Controls.Add(this.panel17);
            this.Controls.Add(this.panel16);
            this.Controls.Add(this.panel13);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDijkstra";
            this.Text = "frmLichTrinhTraKhach";
            this.Load += new System.EventHandler(this.frmDijkstra_Load);
            this.panel6.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            this.panel18.ResumeLayout(false);
            this.panel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvQuangDuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel7;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbDiaDiem;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbKetThuc;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbbBatDau;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel14;
        private DevComponents.DotNetBar.ButtonX btnTimDuongDiNganNhat;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Panel panel18;
        private System.Windows.Forms.Label lbKetQua;
        private System.Windows.Forms.Panel panel19;
        private System.Windows.Forms.Panel panel20;
        private System.Windows.Forms.DataGridView dtgvQuangDuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaTrungChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemDi;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiemDen;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuangDuong;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaDiaChiTrungChuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn fl_Xoa;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChiTrungChuyen;

    }
}