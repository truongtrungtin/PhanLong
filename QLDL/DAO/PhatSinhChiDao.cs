using DocumentFormat.OpenXml.Drawing.Diagrams;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class PhatSinhChiDao
    {
        QLDLDBContext db = null;
        public PhatSinhChiDao()
        {
            db = new QLDLDBContext();
        }

        public bool checkbox(int[] chkId)
        {
            try
            {
                for (int i = 0; i < chkId.Length; i++)
                {
                    int temp = chkId[i];
                    var article = db.PhatSinhChiThus.Where(x => x.Id == temp).SingleOrDefault();
                    db.PhatSinhChiThus.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<PhatSinhChiThu> ListAll()
        {
            var model = db.PhatSinhChiThus.OrderByDescending(x => x.Ngay).ToList();
            
            return model;
        }

        public PhatSinhChiThu GetById(long? id)
        {
            return db.PhatSinhChiThus.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(PhatSinhChiThu entity)
        {
            db.PhatSinhChiThus.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(PhatSinhChiThu phatSinhChi)
        {
            try
            {
                var item = db.PhatSinhChiThus.Find(phatSinhChi.Id);
                item.Ngay = phatSinhChi.Ngay;
                item.NguoiChiThu = phatSinhChi.NguoiChiThu;
                item.NguoiNhan = phatSinhChi.NguoiNhan;
                item.HTTT = phatSinhChi.HTTT;
                item.KhachHang = phatSinhChi.KhachHang;
                item.Bill = phatSinhChi.Bill;
                item.SoHD = phatSinhChi.SoHD;
                item.GhiChu = phatSinhChi.GhiChu;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool Delete(long id)
        {
            try
            {
                var item = db.PhatSinhChiThus.Find(id);
                db.PhatSinhChiThus.Remove(item);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}