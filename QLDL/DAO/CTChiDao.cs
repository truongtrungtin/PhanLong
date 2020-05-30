using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class CTChiDao
    {
        QLDLDBContext db = null;
        public CTChiDao()
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
                    var article = db.CTChis.Where(x => x.Id == temp).SingleOrDefault();
                    db.CTChis.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public List<CTChi> listBill(long? bill)
        {
            return db.CTChis.Where(x => x.PhatSinhChi1.Bill == bill).OrderByDescending(x => x.Id).ToList();
        }
        public List<CTChi> ListAll(long phatSinhChi)
        {
            return db.CTChis.Where(x => x.PhatSinhChi == phatSinhChi).OrderByDescending(x => x.Id).ToList();
        }

        public CTChi GetById(long? id)
        {
            return db.CTChis.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(CTChi entity)
        {
            db.CTChis.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(CTChi cTChi)
        {
            try
            {
                var item = db.CTChis.Find(cTChi.Id);
                item.Mooc = cTChi.Mooc;
                item.Xe = cTChi.Xe;
                item.Cont = cTChi.Cont;
                item.NoiDung = cTChi.NoiDung;
                item.Phi = cTChi.Phi;
                item.DonGia = cTChi.DonGia;
                item.SoLuong = cTChi.SoLuong;
                item.Garage = cTChi.Garage;
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
                var item = db.CTChis.Find(id);
                db.CTChis.Remove(item);
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