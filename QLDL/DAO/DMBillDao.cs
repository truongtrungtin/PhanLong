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
        public IEnumerable<DMBill> ListAll(int? Bill = null, int? KhachHang = null, string ToDate = null, string FromDate = null)
        {
            IQueryable<DMBill> model = db.DMBills;
            DateTime sdate = (ToDate != "") ? Convert.ToDateTime(ToDate).Date : new DateTime();
            DateTime edate = (FromDate != "") ? Convert.ToDateTime(FromDate).Date : new DateTime();
            if (ToDate != null && FromDate != null)
            {
                if (KhachHang != null)
                {
                    if (Bill != null)
                    {
                        model = db.DMBills.Where(x => x.Id == Bill && x.KhachHang == KhachHang && ((ToDate == "" && FromDate == "") || (x.NgayTauDen >= sdate && x.NgayTauDen <= edate)));
                    }
                    else
                    {
                        model = db.DMBills.Where(x => x.KhachHang == KhachHang && ((ToDate == "" && FromDate == "") || (x.NgayTauDen >= sdate && x.NgayTauDen <= edate)));
                    }

                }
                else if (Bill != null)
                {
                    model = db.DMBills.Where(x => x.Id == Bill && ((ToDate == "" && FromDate == "") || (x.NgayTauDen >= sdate && x.NgayTauDen <= edate)));
                }

                else
                {
                    model = db.DMBills.Where(x => (ToDate == "" && FromDate == "") ||( x.NgayTauDen >= sdate && x.NgayTauDen <= edate));
                }
            }
            else
            {
                if (KhachHang != null)
                {
                    if (Bill != null)
                    {
                        model = db.DMBills.Where(x => x.Id == Bill && x.KhachHang == KhachHang);
                    }
                    else
                    {
                        model = db.DMBills.Where(x => x.KhachHang == KhachHang);
                    }

                }
                else if (Bill != null)
                {
                    if (KhachHang != null)
                    {
                        model = db.DMBills.Where(x => x.Id == Bill && x.KhachHang == KhachHang);
                    }
                    else
                    {
                        model = db.DMBills.Where(x => x.Id == Bill);
                    }
                }
            }
            return model.OrderByDescending(x => x.NgayTauDen).ToList();
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
                item.NgayTauDen = dMBill.NgayTauDen;
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