using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace QLDL.DAO
{
    public class DMCangDao
    {
        QLDLContext db = null;
        public DMCangDao()
        {
            db = new QLDLContext();
        }
        public List<DMCang> ListAll()
        {
            return db.DMCangs.OrderBy(x => x.Id).ToList();
        }

        public List<DMCang> Check(String maCang)
        {
            return db.DMCangs.Where(x => x.MaCang == maCang).ToList();

        }
        public DMCang GetById(long id)
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