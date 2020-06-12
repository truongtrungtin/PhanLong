using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QLDL.DAO
{
    public class DMThoiGianDao
    {
        QLDLDBContext db = null;
        public DMThoiGianDao()
        {
            db = new QLDLDBContext();
        }
        public long InsertThoigian(DMThoiGian entity, string thoigian)
        {
            entity.MaTG = thoigian;
            db.DMThoiGians.Add(entity);
            db.SaveChanges();
            return entity.Id;
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
                                dMCang.MaCang = dr["Tên cảng"].ToString();
                            }
                            else if (column.ColumnName == "Tên cảng")
                            {

                                dMCang.TenCang = dr["Tên cảng"].ToString();

                            }
                        }
                        var data = db.DMCangs.Add(dMCang);
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