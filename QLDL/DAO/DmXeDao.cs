using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QLDL.DAO
{
    public class DMXeDao
    {
        QLDLDBContext db = null;
        public DMXeDao()
        {
            db = new QLDLDBContext();
        }
        public long InsertXe(DMXe entity, string xe)
        {
            entity.MaXe = xe;
            entity.BienSo = xe;
            db.DMXes.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool checkbox(int[] chkId)
        {
            try
            {
                for (int i = 0; i < chkId.Length; i++)
                {
                    int temp = chkId[i];
                    var article = db.DMXes.Where(x => x.Id == temp).SingleOrDefault();
                    db.DMXes.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool importData(DataTable dt, DMXe dMXe)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {

                            if (column.ColumnName == "Mã Xe")
                            {
                                dMXe.MaXe = dr["Mã Xe"].ToString();
                            }
                            else if (column.ColumnName == "Biển số")
                            {

                                dMXe.BienSo = dr["Biển số"].ToString();

                            }
                        }
                        var data = db.DMXes.Add(dMXe);
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
        public List<DMXe> ListAll()
        {
            return db.DMXes.OrderByDescending(x => x.Id).ToList();
        }

        public List<DMXe> Check(string maXe)
        {
            return db.DMXes.Where(x => x.MaXe == maXe).ToList();

        }
        public DMXe GetById(long? id)
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