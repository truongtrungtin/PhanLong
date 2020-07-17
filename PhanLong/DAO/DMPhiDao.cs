using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PhanLong.DAO
{
    public class DMPhiDao
    {
        PhanLongDBContext db = null;
        public DMPhiDao()
        {
            db = new PhanLongDBContext();
        }
        public long InsertPhi(DMPhi entity, string phi,long loai)
        {
            entity.MaPhi = phi;
            entity.TenPhi = phi;
            entity.LoaiPhi = loai;
            db.DMPhis.Add(entity);
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
                    var article = db.DMPhis.Where(x => x.Id == temp).SingleOrDefault();
                    db.DMPhis.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool importData(DataTable dt, DMPhi dMPhi)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        var LoaiPhi = dr["Loại"].ToString();
                        long? LP = null;
                        if (LoaiPhi != null)
                        {
                            foreach (var item in db.LoaiPhis)
                            {
                                if (item.Loai == LoaiPhi)
                                {
                                    LP = item.Id;
                                }

                            }
                        }
                        else
                        {
                            LP = null;
                        }
                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {

                            if (column.ColumnName == "Mã phí")
                            {
                                dMPhi.MaPhi = dr["Mã phí"].ToString();
                            }
                            else if (column.ColumnName == "Tên phí")
                            {

                                dMPhi.TenPhi = dr["Tên phí"].ToString();

                            }
                            else if (column.ColumnName == "Loại")
                            {

                                if (LP != null)
                                {
                                    dMPhi.LoaiPhi = LP;
                                }

                            }
                        }
                        var data = db.DMPhis.Add(dMPhi);
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
        public List<DMPhi> ListAll()
        {
            return db.DMPhis.OrderByDescending(x => x.Id).ToList();
        }

        public List<DMPhi> Check(string MaPhi)
        {
            return db.DMPhis.Where(x => x.MaPhi == MaPhi).ToList();

        }
        public DMPhi GetById(long? id)
        {
            return db.DMPhis.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMPhi entity)
        {
            db.DMPhis.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(DMPhi dMPhi)
        {
            try
            {
                var item = db.DMPhis.Find(dMPhi.Id);
                item.MaPhi = dMPhi.MaPhi;
                item.TenPhi = dMPhi.TenPhi;
                item.LoaiPhi = dMPhi.LoaiPhi;
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
                var item = db.DMPhis.Find(id);
                db.DMPhis.Remove(item);
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