using DocumentFormat.OpenXml.Drawing.Diagrams;
using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Data;
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

        public bool importData(DataTable dt, PhatSinhChiThu phatSinhChiThu, DMNhanVien dMNhanVien ,HinhThucTT hinhThucTT, DMKhachHang dMKhachHang, DMBill dMBill)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        var NguoiChiThu = dr["Người chi thu"].ToString();
                        var NguoiNhan = dr["Người nhận"].ToString();
                        var KhachHang = dr["Khách hàng"].ToString();
                        var HinhThucTT = dr["HTTT"].ToString();
                        var Bill = dr["Số bill"].ToString();
                        long? nguoichithu = null;
                        long? nguoinhan = null;
                        long? khachhang = null;
                        long? hinhttt = null;
                        long? bill = null;

                        if (NguoiChiThu != null)
                        {
                            foreach (var item in db.DMNhanViens)
                            {
                                if (item.MaNV == NguoiChiThu || item.TenNV == NguoiChiThu)
                                {
                                    nguoichithu = item.Id;
                                }

                            }
                            if (nguoichithu == null)

                            {
                                var dao = new DMNhanVienDao().InsertNV(dMNhanVien, NguoiChiThu);
                                nguoichithu = dao;
                            }
                        }
                        else
                        {
                            nguoichithu = null;
                        }
                        if (NguoiNhan != null)
                        {
                            foreach (var item in db.DMNhanViens)
                            {
                                if (item.MaNV == NguoiNhan || item.TenNV == NguoiNhan)
                                {
                                    nguoinhan = item.Id;
                                }

                            }
                            if (nguoinhan == null)

                            {
                                var dao = new DMNhanVienDao().InsertNV(dMNhanVien, NguoiNhan);
                                nguoinhan = dao;
                            }
                        }
                        else
                        {
                            nguoinhan = null;
                        }
                        if (KhachHang != null)
                        {
                            foreach (var item in db.DMKhachHangs)
                            {
                                if (item.MaKH == KhachHang)
                                {
                                    khachhang = item.Id;
                                }

                            }
                            if (khachhang == null)
                            {
                                var dao = new DMKhachHangDao().InsertKhachHang(dMKhachHang, KhachHang);
                                khachhang = dao;
                            }
                        }
                        else
                        {
                            khachhang = null;
                        }
                        if (HinhThucTT != null)
                        {
                            foreach (var item in db.HinhThucTTs)
                            {
                                if (item.MaHT == HinhThucTT)
                                {
                                    hinhttt = item.Id;
                                }

                            }
                            if (khachhang == null)
                            {
                                var dao = new HinhThucTTDao().InsertHTTT(hinhThucTT, HinhThucTT);
                                hinhttt = dao;
                            }
                        }
                        else
                        {
                            hinhttt = null;
                        }
                        if (Bill != "")
                        {
                            foreach (var item in db.DMBills)
                            {
                                if (item.MaBill == Bill)
                                {
                                    bill = item.Id;
                                }

                            }
                            if (bill == null)
                            {
                                var dao = new DMBillDao().InsertBill(dMBill, Bill, khachhang);
                                bill = dao;
                            }
                        }
                        else
                        {
                            bill = null;
                        }

                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {

                            if (column.ColumnName == "Ngày")
                            {
                                var day = dr["Ngày"].ToString();
                                if (day != "")
                                {
                                    var a = Convert.ToDateTime(day).ToShortDateString();
                                    phatSinhChiThu.Ngay = Convert.ToDateTime(a);
                                }
                            }
                            else if (column.ColumnName == "Người chi thu")
                            {
                                if (nguoichithu != null)
                                {
                                    phatSinhChiThu.NguoiChiThu = nguoichithu;
                                }
                            }
                            else if (column.ColumnName == "Người nhận")
                            {
                                if (nguoinhan != null)
                                {
                                    phatSinhChiThu.NguoiNhan = nguoinhan;
                                }
                            }
                            else if (column.ColumnName == "HTTT")
                            {
                                if (hinhttt != null)
                                {
                                    phatSinhChiThu.HTTT = hinhttt;
                                }
                            }
                            else if (column.ColumnName == "Khách hàng")
                            {
                                if (khachhang != null)
                                {
                                    phatSinhChiThu.KhachHang = khachhang;
                                }
                            }
                            else if (column.ColumnName == "Số bill")
                            {
                                if (bill != null)
                                {
                                    phatSinhChiThu.Bill = bill;
                                }
                            }
                            else if (column.ColumnName == "Số hoá đơn")
                            {
                                if (dr["Số hoá đơn"].ToString() != "")
                                {
                                    phatSinhChiThu.SoHD = dr["Số hoá đơn"].ToString();

                                }
                                else
                                {
                                    phatSinhChiThu.SoHD = null;
                                }

                            }
                            else if (column.ColumnName == "Ghi chú")
                            {
                                if (dr["Ghi chú"].ToString() != "")
                                {
                                    phatSinhChiThu.GhiChu = dr["Ghi chú"].ToString();

                                }
                                else
                                {
                                    phatSinhChiThu.GhiChu = null;
                                }

                            }

                        }
                        var data = db.PhatSinhChiThus.Add(phatSinhChiThu);
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
        public List<PhatSinhChiThu> ListAll()
        {
            var model = db.PhatSinhChiThus.OrderByDescending(x => x.Ngay).ToList();
            
            return model;
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

        public bool Update(PhatSinhChiThu phatSinhChi)
        {
            try
            {
                var item = db.PhatSinhChiThus.Find(phatSinhChi.Id);
                item.Ngay = phatSinhChi.Ngay;
                item.NguoiChiThu = phatSinhChi.NguoiChiThu;
                item.NguoiNhan = phatSinhChi.NguoiNhan;
                item.HTTT = phatSinhChi.HTTT;
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