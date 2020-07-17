using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanLong.DAO
{
    public class PhatSinhThuDao
    {
        PhanLongDBContext db = null;
        public PhatSinhThuDao()
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
                    var article = db.PhatSinhChiThus.Where(x => x.Id == temp).SingleOrDefault();
                    db.PhatSinhChiThus.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<PhatSinhChiThu> ListAll()
        {
            return db.PhatSinhChiThus.OrderByDescending(x => x.Ngay).ToList();
        }

        public PhatSinhChiThu GetById(long? id)
        {
            return db.PhatSinhChiThus.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(PhatSinhChiThu entity)
        {
            db.PhatSinhChiThus.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(PhatSinhChiThu phatsinhthu)
        {
            try
            {
                var item = db.PhatSinhChiThus.Find(phatsinhthu.Id);
                item.Ngay = phatsinhthu.Ngay;
                item.NguoiChiThu = phatsinhthu.NguoiChiThu;
                item.NguoiNhan = phatsinhthu.NguoiNhan;
                item.HTTT = phatsinhthu.HTTT;
                item.KhachHang = phatsinhthu.KhachHang;
                item.Bill = phatsinhthu.Bill;
                item.SoHD = phatsinhthu.SoHD;
                item.GhiChu = phatsinhthu.GhiChu;
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
                var item = db.PhatSinhChiThus.Find(id);
                db.PhatSinhChiThus.Remove(item);
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