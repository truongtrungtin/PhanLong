using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanLong.DAO
{
    public class DMLoaiDao
    {
        PhanLongDBContext db = null;
        public DMLoaiDao()
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
                    var article = db.DMLoais.Where(x => x.Id == temp).SingleOrDefault();
                    db.DMLoais.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<DMLoai> ListAll()
        {
            return db.DMLoais.OrderByDescending(x => x.Id).ToList();
        }

        public List<DMLoai> Check(string MaLoai)
        {
            return db.DMLoais.Where(x => x.MaLoai == MaLoai).ToList();

        }
        public DMLoai GetById(long? id)
        {
            return db.DMLoais.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMLoai entity)
        {
            db.DMLoais.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public long InsertMaLoai(DMLoai entity,string maloai)
        {
            entity.MaLoai = maloai;
            entity.MoTa = maloai;
            entity.MoTa1 = maloai;
            db.DMLoais.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(DMLoai dMLoai)
        {
            try
            {
                var item = db.DMLoais.Find(dMLoai.Id);
                item.MaLoai = dMLoai.MaLoai;
                item.MoTa = dMLoai.MoTa;
                item.MoTa1 = dMLoai.MoTa1;
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
                var item = db.DMLoais.Find(id);
                db.DMLoais.Remove(item);
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