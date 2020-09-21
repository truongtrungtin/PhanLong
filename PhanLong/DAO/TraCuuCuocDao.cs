using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PhanLong.DAO
{
    public class TraCuuCuocDao
    {
        PhanLongDBContext db = null;
        public TraCuuCuocDao()
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
                    var article = db.TraCuuCuocs.Where(x => x.Id == temp).SingleOrDefault();
                    db.TraCuuCuocs.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool importData(DataTable dt, TraCuuCuoc traCuuCuoc)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {


                        }
                        db.TraCuuCuocs.Add(traCuuCuoc);
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
        public List<TraCuuCuoc> ListAll()
        {
            return db.TraCuuCuocs.OrderByDescending(x => x.Id).ToList();
        }

        public IEnumerable<TraCuuCuoc> Search(TraCuuCuoc traCuuCuoc)
        {
            IQueryable<TraCuuCuoc> model = db.TraCuuCuocs;
            if (traCuuCuoc.KhachHang != null)
            {
                model = model.Where(x => x.KhachHang == traCuuCuoc.KhachHang);
            }
            if (traCuuCuoc.Kho != null)
            {
                model = model.Where(x => x.Kho == traCuuCuoc.Kho);
            }
            if (traCuuCuoc.CangNhan != null)
            {
                model = model.Where(x => x.CangNhan == traCuuCuoc.CangNhan);
            }
            if (traCuuCuoc.CangTra != null)
            {
                model = model.Where(x => x.CangTra == traCuuCuoc.CangTra);
            }

            return model.OrderBy(x => x.Id).ToList();
        }

        public TraCuuCuoc GetById(long? id)
        {
            return db.TraCuuCuocs.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(TraCuuCuoc entity)
        {
            db.TraCuuCuocs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(TraCuuCuoc traCuuCuoc)
        {
            try
            {
                var item = db.TraCuuCuocs.Find(traCuuCuoc.Id);
                item.KhachHang = traCuuCuoc.KhachHang;
                item.Kho = traCuuCuoc.Kho;
                item.CangNhan = traCuuCuoc.CangNhan;
                item.CangTra = traCuuCuoc.CangTra;
                item.Cuoc = traCuuCuoc.Cuoc;
                item.CuocTX = traCuuCuoc.CuocTX;
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
                var item = db.TraCuuCuocs.Find(id);
                db.TraCuuCuocs.Remove(item);
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