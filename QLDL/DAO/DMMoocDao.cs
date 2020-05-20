using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace QLDL.DAO
{
    public class DMMoocDao
    {
        QLDLContext db = null;
        public DMMoocDao()
        {
            db = new QLDLContext();
        }
        public List<DMMooc> ListAll()
        {
            return db.DMMoocs.OrderBy(x => x.Id).ToList();
        }

        public List<DMMooc> Check(string MaMooc)
        {
            return db.DMMoocs.Where(x => x.MaMooc == MaMooc).ToList();

        }
        public DMMooc GetById(long id)
        {
            return db.DMMoocs.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMMooc entity)
        {
            db.DMMoocs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(DMMooc dMKho)
        {
            try
            {
                var item = db.DMMoocs.Find(dMKho.Id);
                item.MaMooc = dMKho.MaMooc;
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
                var item = db.DMMoocs.Find(id);
                db.DMMoocs.Remove(item);
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