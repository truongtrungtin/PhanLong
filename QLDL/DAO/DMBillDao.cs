using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class DMBillDao
    {
        QLDLDBContext db = null;
        public DMBillDao()
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
                    var article = db.DMBills.Where(x => x.Id == temp).SingleOrDefault();
                    db.DMBills.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<DMBill> ListAll()
        {
            return db.DMBills.OrderByDescending(x => x.Id).ToList();
        }

        public List<DMBill> Check(string MaBill)
        {
            return db.DMBills.Where(x => x.MaBill == MaBill).ToList();

        }
        public DMBill GetById(long? id)
        {
            return db.DMBills.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMBill entity)
        {
            db.DMBills.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(DMBill dMBill)
        {
            try
            {
                var item = db.DMBills.Find(dMBill.Id);
                item.MaBill = dMBill.MaBill;
                item.CangNhan = dMBill.CangNhan;
                item.CangTra = dMBill.CangTra;
                item.KhachHang = dMBill.KhachHang;
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
                var item = db.DMBills.Find(id);
                db.DMBills.Remove(item);
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