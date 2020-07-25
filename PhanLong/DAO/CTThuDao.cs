using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanLong.DAO
{
    public class CTThuDao
    {
        PhanLongDBContext db = null;
        public CTThuDao()
        {
            db = new PhanLongDBContext();
        }
        public bool checkbox(int[] chkId)
        {
            try
            {
                for (int i = 0; i < chkId.Length; i++)
                {
                    int temp = chkId[i];
                    var article = db.CTChiThus.Where(x => x.Id == temp).SingleOrDefault();
                    db.CTChiThus.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<CTChiThu> listBill(long? bill)
        {
            return db.CTChiThus.Where(x => x.PhatSinhChiThu1.Bill == bill).OrderByDescending(x => x.Id).ToList();
        }
        public List<CTChiThu> ListAll(long phatsinhthu)
        {
            return db.CTChiThus.Where(x => x.PhatSinhChiThu == phatsinhthu).OrderByDescending(x => x.Id).ToList();
        }

        public CTChiThu GetById(long? id)
        {
            return db.CTChiThus.SingleOrDefault(x => x.Id == id);
        }

        public long Insert(CTChiThu entity, long? idChi = null)
        {
            var item = db.CTChiThus.Add(entity);
            if (idChi != null)
            {
                item.PhatSinhChiThu = idChi;
            }
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(CTChiThu cTChi)
        {
            try
            {
                var item = db.CTChiThus.Find(cTChi.Id);
                item.Cont = cTChi.Cont;
                item.NoiDung = cTChi.NoiDung;
                item.Phi = cTChi.Phi;
                item.DonGia = cTChi.DonGia;
                item.SoLuong = cTChi.SoLuong;
                item.Garage = cTChi.Garage;
                item.DateUpdate = DateTime.Now;
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
                var item = db.CTChiThus.Find(id);
                db.CTChiThus.Remove(item);
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