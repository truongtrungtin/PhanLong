using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PhanLong.DAO
{
    public class PhatSinhChiDao
    {
        PhanLongDBContext db = null;
        public PhatSinhChiDao()
        {
            db = new PhanLongDBContext();
        }

        public bool UpdateGhiChu(PhatSinhChiThu phatSinhChiThu)
        {
            try
            {
                var item = db.PhatSinhChiThus.Find(phatSinhChiThu.Id);
                item.GhiChu = phatSinhChiThu.GhiChu;
                item.DateUpdate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
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

        public bool importData(DataTable dt, PhatSinhChiThu phatSinhChiThu, DMNhanVien dMNhanVien, HinhThucTT hinhThucTT, DMKhachHang dMKhachHang, DMBill dMBill, DMXe dMXe, DMMooc dMMooc)
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
                        var Mooc = dr["Mooc"].ToString();
                        var Xe = dr["Xe"].ToString();
                        long? nguoichithu = null;
                        long? nguoinhan = null;
                        long? khachhang = null;
                        long? mooc = null;
                        long? xe = null;
                        long? hinhttt = null;
                        long? bill = null;

                        if (NguoiChiThu != null && NguoiChiThu != "")
                        {
                            foreach (var item in db.DMNhanViens)
                            {
                                if (item.MaNV == NguoiChiThu)
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
                        if (NguoiNhan != null && NguoiNhan != "")
                        {
                            foreach (var item in db.DMKhachHangs)
                            {
                                if (item.MaKH == NguoiNhan)
                                {
                                    nguoinhan = item.Id;
                                }

                            }
                            if (nguoinhan == null)
                            {
                                var dao = new DMKhachHangDao().InsertKhachHang(dMKhachHang, NguoiNhan);
                                nguoinhan = dao;
                            }
                        }
                        else
                        {
                            nguoinhan = null;
                        }
                        if (KhachHang != null && KhachHang != "")
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
                        if (Mooc != null && Mooc != "")
                        {
                            foreach (var item in db.DMMoocs)
                            {
                                if (item.MaMooc == Mooc || item.BienSo == Mooc)
                                {
                                    mooc = item.Id;
                                }

                            }
                            if (mooc == null)
                            {
                                var dao = new DMMoocDao().InsertMooc(dMMooc, Mooc);
                                mooc = dao;
                            }
                        }
                        else
                        {
                            mooc = null;
                        }
                        if (Xe != null && Xe != "")
                        {
                            foreach (var item in db.DMXes)
                            {
                                if (item.MaXe == Xe || item.BienSo == Xe)
                                {
                                    xe = item.Id;
                                }

                            }
                            if (xe == null)
                            {
                                var dao = new DMXeDao().InsertXe(dMXe, Xe);
                                xe = dao;
                            }
                        }
                        else
                        {
                            xe = null;
                        }
                        if (HinhThucTT != null && HinhThucTT != "")
                        {
                            foreach (var item in db.HinhThucTTs)
                            {
                                if (item.MaHT == HinhThucTT)
                                {
                                    hinhttt = item.Id;
                                }

                            }
                            if (hinhttt == null)
                            {
                                var dao = new HinhThucTTDao().InsertHTTT(hinhThucTT, HinhThucTT);
                                hinhttt = dao;
                            }
                        }
                        else
                        {
                            hinhttt = null;
                        }
                        if (Bill != null && Bill != "")
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

                            else if (column.ColumnName == "Mooc")
                            {
                                phatSinhChiThu.Mooc = mooc;

                            }
                            else if (column.ColumnName == "Xe")
                            {

                                phatSinhChiThu.Xe = xe;

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
                                if (dr["Số hoá đơn"].ToString() != "")
                                {
                                    phatSinhChiThu.Bill = bill;
                                }
                                else
                                {
                                    phatSinhChiThu.Bill = null;
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
                item.Xe = phatSinhChi.Xe;
                item.Mooc = phatSinhChi.Mooc;
                item.Bill = phatSinhChi.Bill;
                item.SoHD = phatSinhChi.SoHD;
                item.GhiChu = phatSinhChi.GhiChu;
                item.DateUpdate = DateTime.Now;
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