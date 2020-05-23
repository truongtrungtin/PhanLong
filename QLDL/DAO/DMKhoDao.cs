using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace QLDL.DAO
{
    public class DMKhoDao
    {
        QLDLDBContext db = null;
        public DMKhoDao()
        {
            db = new QLDLDBContext();
        }
        public List<DMKho> ListAll()
        {
            return db.DMKhoes.OrderByDescending(x => x.Id).ToList();
        }
        public bool checkbox(int[] chkId)
        {
            try
            {
                for (int i = 0; i < chkId.Length; i++)
                {
                    int temp = chkId[i];
                    var article = db.DMKhoes.Where(x => x.Id == temp).SingleOrDefault();
                    db.DMKhoes.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<DMKho> Check(string MaKho)
        {
            return db.DMKhoes.Where(x => x.MaKho == MaKho).ToList();

        }
        public DMKho GetById(long? id)
        {
            return db.DMKhoes.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMKho entity)
        {
            db.DMKhoes.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(DMKho dMKho)
        {
            try
            {
                var item = db.DMKhoes.Find(dMKho.Id);
                item.DiaChi = dMKho.DiaChi;
                item.NguoiLienHe = dMKho.NguoiLienHe;
                item.SoDienThoai = dMKho.SoDienThoai;
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
                var item = db.DMKhoes.Find(id);
                db.DMKhoes.Remove(item);
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