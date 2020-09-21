using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PhanLong.DAO
{
    public class SoPhuNganHangDao
    {
        PhanLongDBContext db = null;
        public SoPhuNganHangDao()
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
                    var article = db.SoPhuNganHangs.Where(x => x.Id == temp).SingleOrDefault();
                    db.SoPhuNganHangs.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool importData(DataTable dt, SoPhuNganHang soPhuNganHang, DMKhachHang dMKhachHang, HinhThucTT hinhThucTT, DMPhi dMPhi)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        var KH = dr["Mã KH"].ToString();
                        var HTTT = dr["Hình thức"].ToString();
                        var Phi = dr["Loại Phí"].ToString();
                        long? makh = null;
                        long? mahttt = null;
                        long? maphi = null;
                        if (KH != "" && KH != null)
                        {
                            foreach (var item in db.DMKhachHangs)
                            {
                                if (item.MaKH == KH || item.TenCongTy == KH)
                                {
                                    makh = item.Id;
                                }

                            }
                            if (makh == null)
                            {
                                var dao = new DMKhachHangDao().InsertKhachHang(dMKhachHang, KH);
                                makh = dao;
                            }
                        }
                        else
                        {
                            makh = null;
                        }
                        if (HTTT != "" && HTTT != null)
                        {
                            foreach (var item in db.HinhThucTTs)
                            {
                                if (item.MaHT == HTTT)
                                {
                                    mahttt = item.Id;
                                }

                            }
                            if (mahttt == null)
                            {
                                var dao = new HinhThucTTDao().InsertHTTT(hinhThucTT, HTTT);
                                mahttt = dao;
                            }
                        }
                        else
                        {
                            mahttt = null;
                        }
                        if (Phi != "" && Phi != null)
                        {
                            foreach (var item in db.DMPhis)
                            {
                                if (item.MaPhi == Phi || item.TenPhi == Phi)
                                {
                                    maphi = item.Id;
                                }

                            }
                            if (maphi == null)
                            {
                                var dao = new DMPhiDao().InsertPhi(dMPhi, Phi, 1);
                                maphi = dao;
                            }
                        }
                        else
                        {
                            maphi = null;
                        }
                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {
                            if (column.ColumnName == "Ngày")
                            {
                                var day = dr[column].ToString();
                                if (day != "")
                                {
                                    var a = Convert.ToDateTime(day).ToShortDateString();
                                    soPhuNganHang.Ngay = Convert.ToDateTime(a);
                                }
                                else
                                {
                                    soPhuNganHang.Ngay = null;
                                }
                            }
                            else if (column.ColumnName == "Mã KH")
                            {
                                soPhuNganHang.MaKH = makh;

                            }
                            else if (column.ColumnName == "Hình thức")
                            {
                                soPhuNganHang.HTTT = mahttt;

                            }
                            else if (column.ColumnName == "Nội dung")
                            {
                                var a = dr["Nội dung"].ToString();
                                if (a != "")
                                {
                                    soPhuNganHang.NoiDung = a;
                                }
                                else
                                {
                                    soPhuNganHang.NoiDung = null;
                                }
                            }
                            else if (column.ColumnName == "Loại phí")
                            {
                                soPhuNganHang.Phi = maphi;

                            }
                            else if (column.ColumnName == "Số tiền chi")
                            {
                                var a = dr["Số tiền chi"].ToString();
                                if (a != "")
                                {
                                    soPhuNganHang.TienChi = Convert.ToDecimal(a);
                                }
                                else
                                {
                                    soPhuNganHang.TienChi = null;
                                }
                            }
                            else if (column.ColumnName == "Số tiền thu")
                            {
                                var a = dr["Số tiền thu"].ToString();
                                if (a != "")
                                {
                                    soPhuNganHang.TienThu = Convert.ToDecimal(a);
                                }
                                else
                                {
                                    soPhuNganHang.TienThu = null;
                                }
                            }
                            else if (column.ColumnName == "Ghi chú")
                            {
                                if (dr["Ghi chú"].ToString() != "")
                                {
                                    soPhuNganHang.GhiChu = dr["Ghi chú"].ToString();

                                }
                                else
                                {
                                    soPhuNganHang.GhiChu = null;
                                }

                            }

                        }
                        var data = db.SoPhuNganHangs.Add(soPhuNganHang);
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
        public List<SoPhuNganHang> listKH(long id)
        {
            return db.SoPhuNganHangs.Where(x => x.MaKH == id).ToList();
        }

        public List<SoPhuNganHang> ListAll()
        {
            return db.SoPhuNganHangs.OrderByDescending(x => x.Ngay).ToList();
        }

        public IEnumerable<SoPhuNganHang> TimKiemThongTin(SoPhuNganHang soPhuNganHang, string NgayBD, string NgayKT, long? loaiphi = null)
        {
            DateTime sdate = (NgayBD != "") ? Convert.ToDateTime(NgayBD).Date : new DateTime();
            DateTime edate = (NgayKT != "") ? Convert.ToDateTime(NgayKT).Date : new DateTime();

            IQueryable<SoPhuNganHang> data = db.SoPhuNganHangs;
            var model = data;
            if (!string.IsNullOrEmpty(NgayBD))
            {
                model = model.Where(x => (NgayBD == "") || (x.Ngay >= sdate));
            }
            if (!string.IsNullOrEmpty(NgayKT))
            {
                model = model.Where(x => (NgayKT == "") || (x.Ngay <= edate));
            }
            if (soPhuNganHang.MaKH != null)
            {
                model = model.Where(x => x.MaKH == soPhuNganHang.MaKH);
            }
            if (soPhuNganHang.Phi != null)
            {
                model = model.Where(x => x.Phi == soPhuNganHang.Phi);
            }
            if (loaiphi != null)
            {
                model = model.Where(x => x.DMPhi.LoaiPhi == loaiphi);
            }
            return model.OrderBy(x => x.Ngay).ToList();
        }

        public IEnumerable<SoPhuNganHang> Listtk(SoPhuNganHang soPhuNganHang, string sday, string eday)
        {
            IQueryable<SoPhuNganHang> model = db.SoPhuNganHangs;
            DateTime sdate = (sday != "") ? Convert.ToDateTime(sday).Date : new DateTime();
            DateTime edate = (eday != "") ? Convert.ToDateTime(eday).Date : new DateTime();
            if (!string.IsNullOrEmpty(sday))
            {
                model = model.Where(x => (sday == "") || (x.Ngay >= sdate));
            }
            else
            {
                sdate = DateTime.Now.Date.AddDays(-30);
                model = model.Where(x => x.Ngay >= sdate);
            }
            if (!string.IsNullOrEmpty(eday))
            {

                model = model.Where(x => (eday == "") || (x.Ngay <= edate));
            }
            else
            {
                edate = DateTime.Now;
                model = model.Where(x => x.Ngay <= edate);
            }
            if (soPhuNganHang.MaKH != null)
            {
                model = model.Where(x => x.MaKH == soPhuNganHang.MaKH);
            }

            return model.OrderBy(x => x.Ngay).ToList();
        }

        public SoPhuNganHang GetById(long? id)
        {
            return db.SoPhuNganHangs.Where(x => x.Id == id).SingleOrDefault();
        }
        public SoPhuNganHang GetByData(SoPhuNganHang soPhuNganHang)
        {
            return db.SoPhuNganHangs.Where(x => x.MaKH == soPhuNganHang.MaKH).FirstOrDefault();
        }
        public long Insert(SoPhuNganHang entity)
        {

            db.SoPhuNganHangs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(SoPhuNganHang soPhuNganHang)
        {
            try
            {
                var item = db.SoPhuNganHangs.Find(soPhuNganHang.Id);
                item.MaKH = soPhuNganHang.MaKH;
                item.NoiDung = soPhuNganHang.NoiDung;
                item.HTTT = soPhuNganHang.HTTT;
                item.Ngay = soPhuNganHang.Ngay;
                item.Phi = soPhuNganHang.Phi;
                item.TienChi = soPhuNganHang.TienChi;
                item.TienThu = soPhuNganHang.TienThu;
                item.GhiChu = soPhuNganHang.GhiChu;
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
                var item = db.SoPhuNganHangs.Find(id);
                db.SoPhuNganHangs.Remove(item);
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