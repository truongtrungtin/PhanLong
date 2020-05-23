using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace QLDL.DAO
{
    public class DMXeDao
    {
        QLDLDBContext db = null;
        public DMXeDao()
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
                    var article = db.DMXes.Where(x => x.Id == temp).SingleOrDefault();
                    db.DMXes.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<DMXe> ListAll()
        {
            return db.DMXes.OrderByDescending(x => x.Id).ToList();
        }

        public List<DMXe> Check(string maXe)
        {
            return db.DMXes.Where(x => x.MaXe == maXe).ToList();

        }
        public DMXe GetById(long? id)
        {
            return db.DMXes.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMXe entity)
        {
            db.DMXes.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(DMXe dMKho)
        {
            try
            {
                var item = db.DMXes.Find(dMKho.Id);
                item.MaXe = dMKho.MaXe;
                item.BienSo = dMKho.BienSo;
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
                var item = db.DMXes.Find(id);
                db.DMXes.Remove(item);
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