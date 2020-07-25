using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PhanLong.DAO
{
    public class DMNhanVienDao
    {
        PhanLongDBContext db = null;
        public DMNhanVienDao()
        {
            db = new PhanLongDBContext();
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

        public bool importData(DataTable dt, DMNhanVien dMNhanVien)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {

                            if (column.ColumnName == "Mã Nhân Viên")
                            {
                                dMNhanVien.MaNV = dr["Mã Nhân Viên"].ToString();
                            }
                            else if (column.ColumnName == "Tên Nhân Viên")
                            {

                                dMNhanVien.TenNV = dr["Tên Nhân Viên"].ToString();

                            }
                        }
                        var data = db.DMNhanViens.Add(dMNhanVien);
                        db.SaveChanges();
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public long InsertNV(DMNhanVien entity, string nv)
        {
            entity.MaNV = nv;
            entity.TenNV = nv;
            db.DMNhanViens.Add(entity);
            db.SaveChanges();
            return entity.Id;
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
                item.DateUpdate = DateTime.Now;
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