using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;

namespace CONTROLS
{
    public partial class XeGiuongNam : UserControl
    {
        public List<string> listGheNgoiDaChon = new List<string>();
        public TextBoxX Textbox { get; set; }
        public XeGiuongNam(List<string> listVitri, TextBoxX textboxViTri)
        {
            InitializeComponent();
            LoadUI(groupBoxLeft.Controls, listVitri);
            LoadUI(groupBoxRight.Controls, listVitri);
            Textbox = textboxViTri;
        }
        public XeGiuongNam(TextBoxX textboxViTri)
        {
            InitializeComponent();
            Textbox = textboxViTri;
        }
        private void LoadUI(ControlCollection controls, List<string> list)
        {
            foreach (Control item in controls)
            {
                if (item is ButtonX)
                {
                    ButtonX button = (ButtonX)item;
                    button.BackColor = System.Drawing.Color.LightSkyBlue;
                }
                else if (item.HasChildren)
                {
                    LoadUI(item.Controls, list);
                }
            }

            foreach (var str in list)
            {
                foreach (Control item in controls)
                {
                    if (item is ButtonX)
                    {
                        ButtonX button = (ButtonX)item;
                        if (button.Text.Equals(str))
                        {
                            button.BackColor = System.Drawing.Color.Silver;
                            button.Enabled = false;
                        }
                    }
                    else if (item.HasChildren)
                    {
                        LoadUI(item.Controls,list);
                    }
                }
            }
        }

        private void XeGiuongNam_Load(object sender, EventArgs e)
        {
            //LoadUI(groupBoxLeft.Controls);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            ButtonX b = (ButtonX)sender;
            if (b.BackColor == System.Drawing.Color.LightSkyBlue)
            {
                b.BackColor = System.Drawing.Color.Pink;
                //Xử lý thêm vào list
                listGheNgoiDaChon.Add(b.Text);
                Textbox.Text = Textbox.Text + " " + b.Text;
            }
            else
            {
                b.BackColor = System.Drawing.Color.LightSkyBlue;
                //Xử lý xóa khỏi list
                foreach (string item in listGheNgoiDaChon)
                {
                    if (item.Equals(b.Text))
                    {
                        listGheNgoiDaChon.Remove(item);
                        Textbox.Text = string.Empty;
                        foreach(string i in listGheNgoiDaChon)
                        {
                            Textbox.Text = Textbox.Text + " " + i;
                        }
                        break;
                    }
                }
            }
        }

    }
}
