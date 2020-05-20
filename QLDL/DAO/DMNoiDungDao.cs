using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class DMNoiDungDao
    {
        QLDLDBContext db = null;
        public DMNoiDungDao()
        {
            db = new QLDLDBContext();
        }
        public List<DMNoiDung> ListAll()
        {
            return db.DMNoiDungs.OrderBy(x => x.Id).ToList();
        }

        public List<DMNoiDung> Check(string MaNoiDung)
        {
            return db.DMNoiDungs.Where(x => x.MaND == MaNoiDung).ToList();

        }
        public DMNoiDung GetById(long id)
        {
            return db.DMNoiDungs.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMNoiDung entity)
        {
            db.DMNoiDungs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(DMNoiDung dMNoiDung)
        {
            try
            {
                var item = db.DMNoiDungs.Find(dMNoiDung.Id);
                item.MaND = dMNoiDung.MaND;
                item.MoTa = dMNoiDung.MoTa;
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
                var item = db.DMNoiDungs.Find(id);
                db.DMNoiDungs.Remove(item);
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