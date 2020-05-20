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
        QLDLContext db = null;
        public DMXeDao()
        {
            db = new QLDLContext();
        }
        public List<DMXe> ListAll()
        {
            return db.DMXes.OrderBy(x => x.Id).ToList();
        }

        public List<DMXe> Check(string maXe)
        {
            return db.DMXes.Where(x => x.MaXe == maXe).ToList();

        }
        public DMXe GetById(long id)
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