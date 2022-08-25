using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using Dijkstra;

namespace QLDatVeXe
{
    public partial class frmDijkstra : Form
    {
        int stt = 0;
        bllDiaChiTrungChuyen bllDC = new bllDiaChiTrungChuyen();
        bllTrungChuyen bllTC = new bllTrungChuyen();
        List<TrungChuyen> listTT = new List<TrungChuyen>();
        string[,] quiDoi = new string[20, 2];
        

        public frmDijkstra()
        {
            InitializeComponent();
        }

        private void frmDijkstra_Load(object sender, EventArgs e)
        {
            cbbDiaDiem.DataSource = bllDC.ShowDanhSachDiaChi();
            cbbDiaDiem.DisplayMember = "DiaChi";
            cbbDiaDiem.ValueMember = "MaDiaChiTrungChuyen";

            cbbBatDau.Enabled = cbbKetThuc.Enabled = false;
        }

        private void cbbDiaDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgvQuangDuong.DataSource = bllTC.ShowDanhSachTrungChuyenTheoMa(cbbDiaDiem.SelectedValue.ToString());
            listTT = bllTC.ShowDanhSachTrungChuyenTheoMa(cbbDiaDiem.SelectedValue.ToString());
            cbbBatDau.Enabled = cbbKetThuc.Enabled = true;
            cbbBatDau.DataSource = bllTC.ShowDiemDi(cbbDiaDiem.SelectedValue.ToString()).ToList();
            cbbKetThuc.DataSource = bllTC.ShowDiemDen(cbbDiaDiem.SelectedValue.ToString()).ToList();
        }

        public void quiDoiDuLieu()
        {
            List<string> list = new List<string>();
            List<TrungChuyen> ltt = listTT;
            foreach (TrungChuyen t in ltt)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Equals(t.DiemDen) || list[i].Equals(t.DiemDi))
                    {
                        break;
                    }
                }
                list.Add(t.DiemDi);
                list.Add(t.DiemDen);
            }
            List<string> listDaLoc = list.Distinct().ToList();
            stt = listDaLoc.Count;
            int st = 65;
            int k = 0;

            for (int i = 0; i < listDaLoc.Count; i++)
            {
                quiDoi[i, 0] = listDaLoc[k];
                quiDoi[i, 1] = char.ConvertFromUtf32(st) + "";
                k++;
                st++;
            }
        }

        public Graph Example()
        {
            List<string> list = new List<string>();
            List<TrungChuyen> ltt = listTT;
            foreach (TrungChuyen t in ltt)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Equals(t.DiemDen) || list[i].Equals(t.DiemDi))
                    {
                        break;
                    }
                }
                list.Add(t.DiemDi);
                list.Add(t.DiemDen);
            }
            List<string> listDaLoc = list.Distinct().ToList();

            Graph graph = new Graph();

            for (int i = 0; i < listDaLoc.Count; i++)
            {
                graph.AddNode(quiDoi[i, 1]);
            }

            foreach (TrungChuyen t in ltt)
            {
                string dDi = "";
                string dDen = "";
                for (int i = 0; i < listDaLoc.Count; i++)
                {
                    if (t.DiemDi.Equals(quiDoi[i, 0]))
                    {
                        dDi = quiDoi[i, 1];
                        continue;
                    }
                }
                for (int j = 0; j < listDaLoc.Count; j++)
                {
                    if (t.DiemDen.Equals(quiDoi[j, 0]))
                    {
                        dDen = quiDoi[j, 1];
                        continue;
                    }
                }
                if (dDi.Equals(string.Empty) && dDen.Equals(string.Empty))
                {
                    break;
                }
                if (dDi.Equals(string.Empty) || dDen.Equals(string.Empty))
                {
                    break;
                }
                else
                {
                    graph.AddConnection(dDi + dDen, t.QuangDuong);
                }
            }
            return graph;
        }

        private void btnTimDuongDiNganNhat_Click(object sender, EventArgs e)
        {
            if(cbbBatDau.Text.Equals(cbbKetThuc.Text))
            {
                MessageBox.Show("Không được chọn điểm đi và điểm đến trùng nhau", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                quiDoiDuLieu();
                string batDau = "";
                string ketThuc = "";
                for (int n = 0; n < stt; n++)
                {
                    if (quiDoi[n, 0].Equals(cbbBatDau.Text))
                    {
                        batDau = quiDoi[n, 1];
                    }
                    if (quiDoi[n, 0].Equals(cbbKetThuc.Text))
                    {
                        ketThuc = quiDoi[n, 1];
                    }
                }
                new AIgorithm(Example()).FindPaths(batDau);
                string a = new AIgorithm(Example()).FindPath(batDau, ketThuc);
                string kq = "";
                foreach(char i in a)
                {
                    bool co = true;
                    if((i+"").Equals(" "))
                    {
                        lbKetQua.Text = kq;
                        return;
                    }
                    while(co==true)
                    {
                        for (int n = 0; n < stt; n++)
                        {
                            if((i+"").Equals(quiDoi[n,1]))
                            {
                                kq += quiDoi[n, 0] + "->";
                                co = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
