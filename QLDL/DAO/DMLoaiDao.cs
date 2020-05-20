using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class DMLoaiDao
    {
        QLDLDBContext db = null;
        public DMLoaiDao()
        {
            db = new QLDLDBContext();
        }
        public List<DMLoai> ListAll()
        {
            return db.DMLoais.OrderBy(x => x.Id).ToList();
        }

        public List<DMLoai> Check(string MaLoai)
        {
            return db.DMLoais.Where(x => x.MaLoai == MaLoai).ToList();

        }
        public DMLoai GetById(long id)
        {
            return db.DMLoais.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMLoai entity)
        {
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