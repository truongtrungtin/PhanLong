using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class DMKhachHangDao
    {
        QLDLDBContext db = null;
        public DMKhachHangDao()
        {
            db = new QLDLDBContext();
        }
        public List<DMKhachHang> ListAll()
        {
            return db.DMKhachHangs.OrderBy(x => x.Id).ToList();
        }
        public List<DMKhachHang> Check(string MaKhachHang)
        {
            return db.DMKhachHangs.Where(x => x.MaKH == MaKhachHang).ToList();
        }
        public DMKhachHang GetById(long id)
        {
            return db.DMKhachHangs.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMKhachHang entity)
        {
            db.DMKhachHangs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(DMKhachHang dMKhachHang)
        {
            try
            {
                var item = db.DMKhachHangs.Find(dMKhachHang.Id);
                item.TenCongTy = dMKhachHang.TenCongTy;
                item.MST = dMKhachHang.MST;
                item.DiaChi = dMKhachHang.DiaChi;
                item.NguoiLienHe = dMKhachHang.NguoiLienHe;
                item.SoDienThoai = dMKhachHang.SoDienThoai;
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
                var item = db.DMKhachHangs.Find(id);
                db.DMKhachHangs.Remove(item);
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