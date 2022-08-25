using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class dalXe
    {
        QuanLyDatVeXeLinQDataContext db = new QuanLyDatVeXeLinQDataContext();
        public dalXe()
        {

        }

        public bool themXe(Xe x)
        {
            try
            {
                db.Xes.InsertOnSubmit(x);
                db.SubmitChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool xoaXe(string maXe)
        {
            try
            {
                Xe xn = db.Xes.Where(f => f.MaXe.Equals(maXe)).FirstOrDefault();

                xn.fl_Xoa = 1;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool suaXe(Xe x)
        {
            try
            {
                Xe xn = db.Xes.Where(f => f.MaXe.Equals(x.MaXe)).FirstOrDefault();
                xn.BienSo = x.BienSo;
                xn.SoGhe = x.SoGhe;
                xn.MaLoaiXe = x.MaLoaiXe;
                db.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<Model_Xe> xuatListXe()
        {
            var list = from x in db.Xes
                       join lx in db.LoaiXes on x.MaLoaiXe equals lx.MaLoaiXe
                       where x.fl_Xoa == 0 && lx.fl_Xoa == 0
                       select new { x.MaXe, x.BienSo, x.SoGhe, lx.TenLoaiXe };
            List<Model_Xe> listXe = new List<Model_Xe>();
            foreach(var i in list)
            {
                Model_Xe xx = new Model_Xe();
                xx.MaXe = i.MaXe;
                xx.BienSo = i.BienSo;
                xx.SoGhe = i.SoGhe;
                xx.TenLoaiXe = i.TenLoaiXe;
                listXe.Add(xx);
            }
            return listXe;
        }

        public string xuatBienSo(string maXe)
        {
            return db.Xes.Where(x => x.MaXe.Equals(maXe) && x.fl_Xoa.Equals(0)).Select(s => s.BienSo).FirstOrDefault();
        }

    }
}
