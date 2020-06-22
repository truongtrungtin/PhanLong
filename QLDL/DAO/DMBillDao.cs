using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

        public bool importData(DataTable dt, DMBill dMBill, DMKhachHang dMKhachHang,DMCang dMCang)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        var MaKH = dr["khách hàng"].ToString();
                        var MaCangNhan = dr["Cảng nhận"].ToString();
                        var MaCangTra = dr["Cảng trả"].ToString();
                        long? KH = null;
                        long? CangNhan = null;
                        long? CangTra = null;
                        if (MaKH != null)
                        {
                            foreach (var item in db.DMKhachHangs)
                            {
                                if (item.MaKH == MaKH)
                                {
                                    KH = item.Id;
                                }

                            }
                            if (KH == null)
                            {
                                var dao = new DMKhachHangDao().InsertKhachHang(dMKhachHang, MaKH);
                                KH = dao;
                            }
                        }
                        else
                        {
                            KH = null;
                        }

                        if (MaCangNhan != null)
                        {
                            foreach (var item in db.DMCangs)
                            {
                                if (item.MaCang == MaCangNhan || item.TenCang == MaCangNhan)
                                {
                                    CangNhan = item.Id;
                                }

                            }
                            if (CangNhan == null)

                            {
                                var dao = new DMCangDao().InsertCang(dMCang, MaCangNhan);
                                CangNhan = dao;
                            }
                        }
                        else
                        {
                            CangNhan = null;
                        }
                        if (MaCangTra != null)
                        {
                            foreach (var item in db.DMCangs)
                            {
                                if (item.MaCang == MaCangTra)
                                {
                                    CangTra = item.Id;
                                }

                            }
                            if (CangTra == null)
                            {
                                var dao = new DMCangDao().InsertCang(dMCang, MaCangTra);
                                CangTra = dao;
                            }
                        }
                        else
                        {
                            CangTra = null;
                        }

                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {

                            if (column.ColumnName == "Mã bill")
                            {
                                dMBill.MaBill = dr["Mã bill"].ToString();
                            }
                            else if (column.ColumnName == "Ngày tàu đến")
                            {
                                var day = dr["Ngày tàu đến"].ToString();
                                if (day != "")
                                {
                                    var a = Convert.ToDateTime(day).ToShortDateString();
                                    dMBill.NgayTauDen = Convert.ToDateTime(a);
                                }     
                            }
                            else if (column.ColumnName == "khách hàng")
                            {
                                if (KH != null)
                                {
                                    dMBill.KhachHang = KH;
                                }
                            }
                            else if (column.ColumnName == "Cảng nhận")
                            {
                                if (CangNhan != null)
                                {
                                    dMBill.CangNhan = CangNhan;
                                }
                            }
                            else if (column.ColumnName == "Cảng trả")
                            {
                                if (CangTra != null)
                                {
                                    dMBill.CangTra = CangTra;
                                }
                            }

                        }
                        var data = db.DMBills.Add(dMBill);
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
        public long InsertBill(DMBill entity, string bill, long? KH = null, long? CangNhan = null, long? CangTra = null)
        {
            entity.MaBill = bill;
            entity.KhachHang = KH;
            entity.CangNhan = CangNhan;
            entity.CangTra = CangTra;
            db.DMBills.Add(entity);
            db.SaveChanges();
            return entity.Id;
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
                item.SoToKhai = dMBill.SoToKhai;
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