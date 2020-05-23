using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class DMCangDao
    {
        QLDLDBContext db = null;
        public DMCangDao()
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
                    var article = db.DMCangs.Where(x => x.Id == temp).SingleOrDefault();
                    db.DMCangs.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<DMCang> ListAll()
        {
            return db.DMCangs.OrderByDescending(x => x.Id).ToList();
        }

        public List<DMCang> Check(string MaCang)
        {
            return db.DMCangs.Where(x => x.MaCang == MaCang).ToList();

        }
        public DMCang GetById(long? id)
        {
            return db.DMCangs.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMCang entity)
        {
            db.DMCangs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(DMCang dMCang)
        {
            try
            {
                var item = db.DMCangs.Find(dMCang.Id);
                item.MaCang = dMCang.MaCang;
                item.TenCang = dMCang.TenCang;
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
                var item = db.DMCangs.Find(id);
                db.DMCangs.Remove(item);
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