using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;

namespace QLDL.DAO
{
    public class HoaDonDao
    {
        QLDLDBContext db = null;
        public HoaDonDao()
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
                    var article = db.HoaDons.Where(x => x.Id == temp).SingleOrDefault();
                    db.HoaDons.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool importData(DataTable dt, HoaDon hoaDon, DMKhachHang dMKhachHang, DMBill dMBill)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        var MaKH = dr["Mã KH"].ToString();
                        var MaBill = dr["Số Bill"].ToString();
                        long? KH = null;
                        long? Bill = null;
                        if (MaKH != "" && MaKH != null)
                        {
                            foreach (var item in db.DMKhachHangs)
                            {
                                if (item.MaKH == MaKH || item.TenCongTy == MaKH)
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
                        if (MaBill != "" && MaBill != null)
                        {
                            foreach (var item in db.DMBills)
                            {
                                if (item.MaBill == MaBill)
                                {
                                    Bill = item.Id;
                                }

                            }
                            if (Bill == null)
                            {
                                var dao = new DMBillDao().InsertBill(dMBill, MaBill, KH);
                                Bill = dao;
                            }
                        }
                        else
                        {
                            Bill = null;
                        }
                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {
                            if (column.ColumnName == "Ngày HĐ")
                            {
                                var day = dr[column].ToString();
                                if (day != "")
                                {
                                    var a = Convert.ToDateTime(day).ToShortDateString();
                                    hoaDon.NgayHD = Convert.ToDateTime(a);
                                }
                                else
                                {
                                    hoaDon.NgayHD = null;
                                }
                            }
                            else if (column.ColumnName == "Mã KH")
                            {
                                    hoaDon.KH = KH;
                                
                            }
                            else if (column.ColumnName == "Số Cont")
                            {
                                if (dr["Số Cont"].ToString() != "")
                                {
                                    hoaDon.SoCont = dr["Số Cont"].ToString();
                                }
                                else
                                {
                                    hoaDon.SoCont = null;
                                }

                            }
                            else if (column.ColumnName == "Số Bill")
                            {
                                    hoaDon.SoBill = Bill;
                               
                            }
                            else if (column.ColumnName == "Tiền cước trên HĐ")
                            {
                                var a = dr["Tiền cước trên HĐ"].ToString();
                                if (a != "")
                                {
                                    hoaDon.TienCuoc = Convert.ToDecimal(a);
                                }
                                else
                                {
                                    hoaDon.TienCuoc = null;
                                }
                            }
                            else if (column.ColumnName == "Tổng chi hộ")
                            {
                                var a = dr["Tổng chi hộ"].ToString();
                                if (a != "")
                                {
                                    hoaDon.ChiHo = Convert.ToDecimal(a);
                                }
                                else
                                {
                                    hoaDon.ChiHo = null;
                                }
                            }
                            else if (column.ColumnName == "Ngày thanh toán")
                            {

                                var day = dr[column].ToString();
                                if (day != "")
                                {
                                    var a = Convert.ToDateTime(day).ToShortDateString();
                                    hoaDon.NgayThanhToan = Convert.ToDateTime(a);
                                }
                                else
                                {
                                    hoaDon.NgayThanhToan = null;
                                }
                            }
                            else if (column.ColumnName == "Số tiền")
                            {
                                var a = dr["Số tiền"].ToString();
                                if (a != "")
                                {
                                    hoaDon.TienThanhToan = Convert.ToDecimal(a);
                                }
                                else
                                {
                                    hoaDon.TienThanhToan = null;
                                }
                            }
                            else if (column.ColumnName == "Thuế VAT")
                            {
                                var a = dr["Thuế VAT"];
                                if (a != null)
                                {
                                    hoaDon.VAT = Convert.ToDouble(a);
                                }
                                else
                                {
                                    hoaDon.VAT = 0;
                                }
                            }
                            else if (column.ColumnName == "Số HĐ")
                            {

                                if (dr["Số HĐ"].ToString() != "")
                                {
                                    hoaDon.SoHD = dr["Số HĐ"].ToString();

                                }
                                else
                                {
                                    hoaDon.SoHD = null;
                                }

                            }
                            else if (column.ColumnName == "Nội dung")
                            {
                                if (dr["Nội dung"].ToString() != "")
                                {
                                    hoaDon.NoiDung = dr["Nội dung"].ToString();

                                }
                                else
                                {
                                    hoaDon.NoiDung = null;
                                }

                            }
                            else if (column.ColumnName == "Ghi chú")
                            {
                                if (dr["Ghi chú"].ToString() != "")
                                {
                                    hoaDon.GhiChu = dr["Ghi chú"].ToString();

                                }
                                else
                                {
                                    hoaDon.GhiChu = null;
                                }

                            }

                        }
                        var data = db.HoaDons.Add(hoaDon);
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
        public List<HoaDon> listKH(long id)
        {
            return db.HoaDons.Where(x => x.KH == id).ToList();
        }

        public List<HoaDon> ListAll()
        {
            return db.HoaDons.OrderByDescending(x => x.NgayHD).ToList();
        }

        public IEnumerable<HoaDon> Listtk(HoaDon hoaDon, string sday, string eday)
        {
            IQueryable<HoaDon> model = db.HoaDons;
            DateTime sdate = (sday != "") ? Convert.ToDateTime(sday).Date : new DateTime();
            DateTime edate = (eday != "") ? Convert.ToDateTime(eday).Date : new DateTime();
            if (!string.IsNullOrEmpty(sday))
            {
                model = model.Where(x => (sday == "") || (x.NgayHD >= sdate));
            }
            else
            {
                sdate = DateTime.Now.Date.AddDays(-30); 
                model = model.Where(x => x.NgayHD >= sdate);
            }
            if (!string.IsNullOrEmpty(eday))
            {
                
                model = model.Where(x => (eday == "") || (x.NgayHD <= edate));
            }
            else
            {
                edate = DateTime.Now;
                model = model.Where(x => x.NgayHD <= edate);
            }
            if (hoaDon.KH != null)
            {
                model = model.Where(x => x.KH == hoaDon.KH);
            }

            return model.OrderBy(x => x.NgayHD).ToList();
        }

        public HoaDon GetById(long? id)
        {
            return db.HoaDons.Where(x => x.Id == id).SingleOrDefault();
        }
        public HoaDon GetByData(HoaDon hoaDon)
        {
            return db.HoaDons.Where(x => x.KH == hoaDon.KH).FirstOrDefault();
        }
        public long Insert(HoaDon entity)
        {
            db.HoaDons.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool UpdateGhiChuLuong(HoaDon hoaDon)
        {
            try
            {
                var item = db.HoaDons.Find(hoaDon.Id);
                item.NgayThanhToan = hoaDon.NgayThanhToan;
                item.TienThanhToan = hoaDon.TienThanhToan;
                if (hoaDon.GhiChu != null && hoaDon.GhiChu != "")
                {
                    item.GhiChu = hoaDon.GhiChu;

                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(HoaDon hoaDon)
        {
            try
            {
                var item = db.HoaDons.Find(hoaDon.Id);
                item.KH = hoaDon.KH;
                item.NoiDung = hoaDon.NoiDung;
                item.SoBill = hoaDon.SoBill;
                item.SoCont = hoaDon.SoCont;
                item.TienCuoc = hoaDon.TienCuoc;
                item.VAT = hoaDon.VAT;
                item.ChiHo = hoaDon.ChiHo;
                item.NgayThanhToan = hoaDon.NgayThanhToan;
                item.TienThanhToan = hoaDon.TienThanhToan;
                item.GhiChu = hoaDon.GhiChu;
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
                var item = db.HoaDons.Find(id);
                db.HoaDons.Remove(item);
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