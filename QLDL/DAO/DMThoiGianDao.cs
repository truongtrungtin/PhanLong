using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class DMThoiGianDao
    {
        QLDLDBContext db = null;
        public DMThoiGianDao()
        {
            db = new QLDLDBContext();
        }
        public List<DMThoiGian> ListAll()
        {
            return db.DMThoiGians.OrderBy(x => x.Id).ToList();
        }
        public bool checkbox(int[] chkId)
        {
            try
            {
                for (int i = 0; i < chkId.Length; i++)
                {
                    int temp = chkId[i];
                    var article = db.DMThoiGians.Where(x => x.Id == temp).SingleOrDefault();
                    db.DMThoiGians.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<DMThoiGian> Check(string MaThoiGian)
        {
            return db.DMThoiGians.Where(x => x.MaTG == MaThoiGian).ToList();

        }
        public DMThoiGian GetById(long? id)
        {
            return db.DMThoiGians.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMThoiGian entity)
        {
            db.DMThoiGians.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(DMThoiGian dMThoiGian)
        {
            try
            {
                var item = db.DMThoiGians.Find(dMThoiGian.Id);
                item.Id = dMThoiGian.Id;
                item.MaTG = dMThoiGian.MaTG;
                item.ThoiGian = dMThoiGian.ThoiGian;
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
                var item = db.DMThoiGians.Find(id);
                db.DMThoiGians.Remove(item);
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