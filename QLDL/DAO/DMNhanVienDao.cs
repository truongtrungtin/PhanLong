using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class DMNhanVienDao
    {
        QLDLContext db = null;
        public DMNhanVienDao()
        {
            db = new QLDLContext();
        }
        public List<DMNhanVien> ListAll()
        {
            return db.DMNhanViens.OrderBy(x => x.Id).ToList();
        }
        public List<DMNhanVien> Check(string MaNhanVien)
        {
            return db.DMNhanViens.Where(x => x.MaNV == MaNhanVien).ToList();
        }
        public DMNhanVien GetById(long id)
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