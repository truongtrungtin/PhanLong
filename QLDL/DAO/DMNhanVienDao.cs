using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class DMNhanVienDao
    {
        QLDLDBContext db = null;
        public DMNhanVienDao()
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
                    var article = db.DMNhanViens.Where(x => x.Id == temp).SingleOrDefault();
                    db.DMNhanViens.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<DMNhanVien> ListAll()
        {
            return db.DMNhanViens.OrderByDescending(x => x.Id).ToList();
        }
        public List<DMNhanVien> Check(string MaNhanVien)
        {
            return db.DMNhanViens.Where(x => x.MaNV == MaNhanVien).ToList();
        }
        public DMNhanVien GetById(long? id)
        {
            return db.DMNhanViens.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMNhanVien entity)
        {
            db.DMNhanViens.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(DMNhanVien dMNhanVien)
        {
            try
            {
                var item = db.DMNhanViens.Find(dMNhanVien.Id);
                item.MaNV = dMNhanVien.MaNV;
                item.TenNV = dMNhanVien.TenNV;
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
                var item = db.DMNhanViens.Find(id);
                db.DMNhanViens.Remove(item);
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