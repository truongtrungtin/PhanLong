using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class PhatSinhChiDao
    {
        QLDLDBContext db = null;
        public PhatSinhChiDao()
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
                    var article = db.PhatSinhChis.Where(x => x.Id == temp).SingleOrDefault();
                    db.PhatSinhChis.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<PhatSinhChi> ListAll()
        {
            return db.PhatSinhChis.OrderBy(x => x.Id).ToList();
        }

        public PhatSinhChi GetById(long? id)
        {
            return db.PhatSinhChis.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(PhatSinhChi entity)
        {
            db.PhatSinhChis.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(PhatSinhChi phatSinhChi)
        {
            try
            {
                var item = db.PhatSinhChis.Find(phatSinhChi.Id);
                item.NgayChi = phatSinhChi.NgayChi;
                item.NguoiChi = phatSinhChi.NguoiChi;
                item.NguoiNhan = phatSinhChi.KhachHang;
                item.HinhThucTT = phatSinhChi.HinhThucTT;
                item.KhachHang = phatSinhChi.KhachHang;
                item.Bill = phatSinhChi.Bill;
                item.SoHD = phatSinhChi.SoHD;
                item.GhiChu = phatSinhChi.GhiChu;
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
                var item = db.PhatSinhChis.Find(id);
                db.PhatSinhChis.Remove(item);
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