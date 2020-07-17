using PhanLong.EF;
using PhanLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanLong.DAO
{
    public class PhatSinhChiThuDao
    {
        PhanLongDBContext db = null;
        public PhatSinhChiThuDao()
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
            return db.PhatSinhChiThus.OrderByDescending(x => x.Id).ToList();
        }

        public IEnumerable<PhatSinhChiThu> SearchChiThu(PhatSinhChiThu phatSinhChiThu, CTChiThu cTChiThu, string NgayBD, string NgayKT, long? ChiThu)
        {
            DateTime sdate = (NgayBD != "") ? Convert.ToDateTime(NgayBD).Date : new DateTime();
            DateTime edate = (NgayKT != "") ? Convert.ToDateTime(NgayKT).Date : new DateTime();

            IQueryable<PhatSinhChiThu> data = db.PhatSinhChiThus;
            var model = data;
            if (!string.IsNullOrEmpty(NgayBD))
            {
                model = model.Where(x => (NgayBD == "") || (x.Ngay >= sdate));
            }
            if (!string.IsNullOrEmpty(NgayKT))
            {
                model = model.Where(x => (NgayKT == "") || (x.Ngay <= edate));
            }
            if (phatSinhChiThu.KhachHang != null)
            {
                model = model.Where(x => x.KhachHang == phatSinhChiThu.KhachHang);             
            }
            if(phatSinhChiThu.Bill != null)
            {
                model = model.Where(x => x.Bill == phatSinhChiThu.Bill);
            }
            //if (cTChiThu.Xe != null)
            //{
            //    model = data.Where(x => x.CTChiThus.FirstOrDefault(m => m.Xe == cTChiThu.Xe).PhatSinhChiThu == x.Id);
            //}
            //if (cTChiThu.Mooc != null)
            //{
            //    model = data.Where(x => x.CTChiThus.FirstOrDefault(m => m.Xe == cTChiThu.Mooc).PhatSinhChiThu == x.Id);
            //}
            //if (cTChiThu.Phi != null)
            //{
            //    model = data.Where(x => x.CTChiThus.FirstOrDefault(m => m.Xe == cTChiThu.Xe).PhatSinhChiThu == x.Id);
            //}

            return model.OrderBy(x => x.Id).ToList();
        }


        public PhatSinhChiThu GetById(long? id)
        {
            return db.PhatSinhChiThus.SingleOrDefault(x => x.Id == id);
        }

        public LoaiPhi GetLoaiPhi(long? id)
        {
            return db.LoaiPhis.SingleOrDefault(x => x.Id == id);
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