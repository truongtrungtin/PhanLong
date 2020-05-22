using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class HinhThucTTDao
    {
        QLDLDBContext db = null;
        public HinhThucTTDao()
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
                    var article = db.HinhThucTTs.Where(x => x.Id == temp).SingleOrDefault();
                    db.HinhThucTTs.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<HinhThucTT> ListAll()
        {
            return db.HinhThucTTs.OrderBy(x => x.Id).ToList();
        }
        public List<HinhThucTT> Check(string MaHT)
        {
            return db.HinhThucTTs.Where(x => x.MaHT == MaHT).ToList();
        }
        public HinhThucTT GetById(long? id)
        {
            return db.HinhThucTTs.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(HinhThucTT entity)
        {
            db.HinhThucTTs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(HinhThucTT hinhThucTT)
        {
            try
            {
                var item = db.HinhThucTTs.Find(hinhThucTT.Id);
                item.MaHT = hinhThucTT.MaHT;
                item.MoTa = hinhThucTT.MoTa;
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
                var item = db.HinhThucTTs.Find(id);
                db.HinhThucTTs.Remove(item);
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