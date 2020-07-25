using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PhanLong.DAO
{
    public class DMCangDao
    {
        PhanLongDBContext db = null;
        public DMCangDao()
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
                    var article = db.DMCangs.Where(x => x.Id == temp).SingleOrDefault();
                    db.DMCangs.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public long InsertCang(DMCang entity, string cang)
        {
            entity.MaCang = cang;
            entity.TenCang = cang;
            db.DMCangs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool importData(DataTable dt, DMCang dMCang)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {
                           
                            if (column.ColumnName == "Mã cảng")
                            {
                                dMCang.MaCang = dr["Mã cảng"].ToString();
                            }
                            else if (column.ColumnName == "Tên cảng")
                            {

                                dMCang.TenCang = dr["Tên cảng"].ToString();

                            }
                        }
                        db.DMCangs.Add(dMCang);
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
        public List<DMCang> ListAll()
        {
            return db.DMCangs.OrderByDescending(x => x.Id).ToList();
        }

        public List<DMCang> Check(string MaCang)
        {
            return db.DMCangs.Where(x => x.MaCang == MaCang).ToList();

        }
        public DMCang GetById(long? id)
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