﻿using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PhanLong.DAO
{
    public class PhatSinhDao
    {
        PhanLongDBContext db = null;
        public PhatSinhDao()
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
                    var article = db.PhatSinhs.Where(x => x.Id == temp).SingleOrDefault();
                    db.PhatSinhs.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool importData(DataTable dt, PhatSinh phatSinh, DMLoai dMLoai, DMKhachHang dMKhachHang, DMKho dMKho, DMXe dMXe, DMNhanVien dMNhanVien, DMPhi dMPhi, DMThoiGian dMThoiGian, DMCang dMCang, DMBill dMBill)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        var MaLoai = dr["Loại"].ToString();
                        var MaKH = dr["Khách hàng"].ToString();
                        var MaKho = dr["Kho"].ToString();
                        var MaBill = dr["Số Bill"].ToString();
                        var MaCangNhan = dr["Cảng nhận"].ToString();
                        var MaCangTra = dr["Cảng trả"].ToString();
                        var TenTX = dr["Tài Xế"].ToString();
                        var MaXe = dr["Xe"].ToString();
                        var MaPhiKH = dr["Hoá đơn khác"].ToString();
                        var MaPhict = dr["Chi Phí riêng"].ToString();
                        var MaThoiGian = dr["Thời Gian"].ToString();
                        var cont = dr["Cont"].ToString();
                        long? Loai = null;
                        long? KH = null;
                        long? Kho = null;
                        long? Bill = null;
                        long? CangNhan = null;
                        long? CangTra = null;
                        long? TaiXe = null;
                        long? Xe = null;
                        long? phict = null;
                        long? thoigian = null;
                        if (MaLoai != "")
                        {
                            foreach (var item in db.DMLoais)
                            {
                                if (item.MaLoai == MaLoai || item.MoTa == MaLoai || item.MoTa1 == MaLoai)
                                {
                                    Loai = item.Id;
                                    continue;
                                }
                            }
                            if (Loai == null)
                            {
                                var dao = new DMLoaiDao().InsertMaLoai(dMLoai, MaLoai);
                                Loai = dao;

                            }
                        }
                        else
                        {
                            Loai = null;
                        }
                        if (MaKH != "")
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
                        if (MaKho != "")
                        {
                            foreach (var item in db.DMKhoes)
                            {
                                if (item.MaKho == MaKho || item.DiaChi == MaKho)
                                {
                                    Kho = item.Id;
                                }
                            }
                            if (Kho == null)
                            {
                                var dao = new DMKhoDao().InsertKho(dMKho, MaKho);
                                Kho = dao;
                            }
                        }
                        else
                        {
                            Kho = null;
                        }

                        if (MaCangNhan != "")
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
                        if (MaCangTra != "")
                        {
                            foreach (var item in db.DMCangs)
                            {
                                if (item.MaCang == MaCangTra || item.TenCang == MaCangTra)
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
                        if (TenTX != "")
                        {
                            foreach (var item in db.DMNhanViens)
                            {
                                if (item.MaNV == TenTX)
                                {
                                    TaiXe = item.Id;
                                }

                            }
                            if (TaiXe == null)
                            {
                                var dao = new DMNhanVienDao().InsertNV(dMNhanVien, TenTX);
                                TaiXe = dao;
                            }
                        }
                        else
                        {
                            TaiXe = null;
                        }
                        if (MaBill != "")
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
                                var dao = new DMBillDao().InsertBill(dMBill, MaBill, KH, CangNhan, CangTra);
                                Bill = dao;
                            }
                        }
                        else
                        {
                            Bill = null;
                        }
                        if (MaXe != "")
                        {
                            foreach (var item in db.DMXes)
                            {
                                if (item.MaXe == MaXe || item.BienSo == MaXe)
                                {
                                    Xe = item.Id;
                                }

                            }

                            if (Xe == null)
                            {
                                var dao = new DMXeDao().InsertXe(dMXe, MaXe);
                                Xe = dao;
                            }
                        }
                        else
                        {
                            Xe = null;
                        }
                        if (MaPhict != "")
                        {
                            foreach (var item in db.DMPhis)
                            {
                                if (item.MaPhi == MaPhict || item.TenPhi == MaPhict)
                                {
                                    phict = item.Id;
                                }

                            }
                            if (phict == null)
                            {
                                var dao = new DMPhiDao().InsertPhi(dMPhi, MaPhict, 1);
                                phict = dao;
                            }
                        }
                        else
                        {
                            phict = null;
                        }
                        if (MaThoiGian != "")
                        {
                            foreach (var item in db.DMThoiGians)
                            {
                                if (item.ThoiGian == MaThoiGian || item.MaTG == MaThoiGian)
                                {
                                    thoigian = item.Id;
                                }

                            }
                            if (thoigian == null)
                            {
                                var dao = new DMThoiGianDao().InsertThoigian(dMThoiGian, MaThoiGian);
                                thoigian = dao;
                            }
                        }
                        else
                        {
                            thoigian = null;
                        }
                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {
                            if (column.ColumnName == "Ngày")
                            {
                                var day = dr[column].ToString();
                                if (day != "")
                                {
                                    var a = Convert.ToDateTime(day).ToShortDateString();
                                    phatSinh.Ngay = Convert.ToDateTime(a);
                                }

                            }
                            else if (column.ColumnName == "Loại")
                            {
                                phatSinh.Loai = Loai;

                            }
                            else if (column.ColumnName == "Khách hàng")
                            {
                                phatSinh.KhachHang = KH;

                            }
                            else if (column.ColumnName == "Kho")
                            {

                                phatSinh.Kho = Kho;

                            }
                            else if (column.ColumnName == "Cont")
                            {
                                if (dr["Cont"].ToString() != "")
                                {
                                    phatSinh.SoCont = dr["Cont"].ToString();
                                    if (dr["Số Bill"].ToString() != "")
                                    {
                                        var dao = new DMBillDao().Check(dr["Số Bill"].ToString());
                                        var checkcont = new CTBillDao().Check(dao.Id, dr["Cont"].ToString());
                                        if (checkcont == null)
                                        {
                                            CTBill bill = new CTBill();
                                            bill.Bill = dao.Id;
                                            bill.Cont = dr["Cont"].ToString();
                                            bill.Loai = Loai;
                                            bill.Kho = Kho;
                                            bill.NgayGiao = phatSinh.Ngay;
                                            bill.SoXe = Xe;
                                            new CTBillDao().Insert(bill);
                                        }
                                        else
                                        {
                                            CTBill bill = new CTBill();
                                            bill.Bill = dao.Id;
                                            bill.Cont = dr["Cont"].ToString();
                                            bill.NgayGiao = phatSinh.Ngay;
                                            bill.SoXe = Xe;
                                            new CTBillDao().UpdateNgayGiao(bill);
                                        }
                                    }


                                }
                                else
                                {
                                    phatSinh.SoCont = null;
                                }

                            }
                            else if (column.ColumnName == "Số Bill")
                            {
                                phatSinh.SoBill = Bill;

                            }
                            else if (column.ColumnName == "Cảng nhận")
                            {

                                phatSinh.CangNhan = CangNhan;

                            }
                            else if (column.ColumnName == "Cảng trả")
                            {
                                phatSinh.CangTra = CangTra;

                            }
                            else if (column.ColumnName == "Cước khách hàng")
                            {
                                var a = dr["Cước khách hàng"].ToString();
                                if (a != "")
                                {
                                    phatSinh.CuocKH = Convert.ToDecimal(a);
                                }
                                else
                                {
                                    phatSinh.CuocKH = 0;
                                }
                            }
                            else if (column.ColumnName == "Cước tài xế")
                            {
                                var a = dr["Cước tài xế"].ToString();
                                if (a != "")
                                {
                                    phatSinh.CuocTX = Convert.ToDecimal(a);
                                }
                                else
                                {
                                    phatSinh.CuocTX = null;
                                }
                            }
                            else if (column.ColumnName == "Tài Xế")
                            {

                                phatSinh.TenTX = TaiXe;

                            }
                            else if (column.ColumnName == "Xe")
                            {

                                phatSinh.Xe = Xe;

                            }
                            else if (column.ColumnName == "Chi Phí riêng")
                            {

                                phatSinh.PhiCT = phict;

                            }
                            else if (column.ColumnName == "Hoá đơn nâng")
                            {
                                if (dr["Hoá đơn nâng"].ToString() != "")
                                {
                                    phatSinh.HDNang = dr["Hoá đơn nâng"].ToString();

                                }
                                else
                                {
                                    phatSinh.HDNang = null;
                                }

                            }
                            else if (column.ColumnName == "Tiền Nâng")
                            {
                                var a = dr["Tiền Nâng"].ToString();
                                if (a != "")
                                {
                                    phatSinh.TienNang = Convert.ToDecimal(a);

                                }
                                else
                                {
                                    phatSinh.TienNang = null;
                                }

                            }
                            else if (column.ColumnName == "Hoá đơn hạ")
                            {

                                if (dr["Hoá đơn hạ"].ToString() != "")
                                {
                                    phatSinh.HDHa = dr["Hoá đơn hạ"].ToString();

                                }
                                else
                                {
                                    phatSinh.HDHa = null;
                                }

                            }
                            else if (column.ColumnName == "Tiền Hạ")
                            {
                                var a = dr["Tiền Hạ"].ToString();
                                if (a != "")
                                {
                                    phatSinh.TienHa = Convert.ToDecimal(a);
                                }
                                else
                                {
                                    phatSinh.TienHa = null;
                                }
                            }
                            else if (column.ColumnName == "Hoá đơn khác")
                            {
                                if (dr["Hoá đơn khác"].ToString() != "")
                                {
                                    phatSinh.PhiKH = dr["Hoá đơn khác"].ToString();
                                }
                                else
                                {
                                    phatSinh.PhiKH = null;
                                }
                            }
                            else if (column.ColumnName == "Tiền khác")
                            {
                                var a = dr["Tiền khác"].ToString();
                                if (a != "")
                                {
                                    phatSinh.TienPhiKH = Convert.ToDecimal(a);
                                }
                                else
                                {
                                    phatSinh.TienPhiKH = null;
                                }
                            }
                            else if (column.ColumnName == "Tiền chi riêng")
                            {
                                var a = dr["Tiền chi riêng"].ToString();
                                if (a != "")
                                {
                                    phatSinh.TienPhiCT = Convert.ToDecimal(a);
                                }
                                else
                                {
                                    phatSinh.TienPhiCT = null;
                                }
                            }
                            else if (column.ColumnName == "Thời gian")
                            {

                                phatSinh.Thoigian = thoigian;

                            }
                            else if (column.ColumnName == "Ghi chú")
                            {
                                if (dr["Ghi chú"].ToString() != "")
                                {
                                    phatSinh.GhiChu = dr["Ghi chú"].ToString();

                                }
                                else
                                {
                                    phatSinh.GhiChu = null;
                                }

                            }

                        }
                        var data = db.PhatSinhs.Add(phatSinh);
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
        public List<PhatSinh> listKH(long id)
        {
            return db.PhatSinhs.Where(x => x.KhachHang == id).ToList();
        }

        public List<PhatSinh> ListAll()
        {
            return db.PhatSinhs.OrderByDescending(x => x.Ngay).ToList();
        }

        public IEnumerable<PhatSinh> Listtk(PhatSinh phatSinh, string sday, string eday)
        {
            IQueryable<PhatSinh> model = db.PhatSinhs;
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
            if (phatSinh.KhachHang != null)
            {
                model = model.Where(x => x.KhachHang == phatSinh.KhachHang);
            }
            if (phatSinh.Kho != null)
            {
                model = model.Where(x => x.Kho == phatSinh.Kho);
            }
            if (phatSinh.Loai != null)
            {
                model = model.Where(x => x.Loai == phatSinh.Loai);
            }
            if (phatSinh.Xe != null)
            {
                model = model.Where(x => x.Xe == phatSinh.Xe);
            }
            if (phatSinh.SoBill != null)
            {
                model = model.Where(x => x.SoBill == phatSinh.SoBill);
            }

            return model.OrderBy(x => x.Ngay).ToList();
        }
        public IEnumerable<PhatSinh> ThanhToanCuoc(PhatSinh phatSinh, string sday, string eday)
        {
            IQueryable<PhatSinh> model = db.PhatSinhs;
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
            if (phatSinh.KhachHang != null)
            {
                model = model.Where(x => x.KhachHang == phatSinh.KhachHang);
            }
            if (phatSinh.SoBill != null)
            {
                model = model.Where(x => x.SoBill == phatSinh.SoBill);
            }
            return model.OrderBy(x => x.Ngay).ToList();
        }
        public PhatSinh GetById(long? id)
        {
            return db.PhatSinhs.Where(x => x.Id == id).SingleOrDefault();
        }

        public CTBill Kehoach(String cont)
        {
            return db.CTBills.Where(x => x.Cont == cont).SingleOrDefault();
        }

        public PhatSinh GetByData(PhatSinh phatSinh)
        {
            return db.PhatSinhs.Where(x => x.KhachHang == phatSinh.KhachHang || x.Xe == phatSinh.Xe || x.Loai == phatSinh.Xe || x.Kho == phatSinh.Kho).FirstOrDefault();
        }

        public List<PhatSinh> GetLoai(long? id)
        {
            return db.PhatSinhs.Where(x => x.Xe == id).ToList();
        }

        public PhatSinh GetNvByXe(long? id, string sday, string eday)
        {
            DateTime sdate = (sday != "") ? Convert.ToDateTime(sday).Date : new DateTime();
            DateTime edate = (eday != "") ? Convert.ToDateTime(eday).Date : new DateTime();
            var model = db.PhatSinhs.Where(x => (sdate == null && edate == null) || (x.Ngay >= sdate && x.Ngay <= edate));
            return model.Where(x => x.Xe == id).FirstOrDefault();
        }
        public long Insert(PhatSinh entity, string MaBill)
        {
            if (MaBill != null)
            {
                var SoBill = new DMBillDao().CheckMaBill(MaBill) != null ? new DMBillDao().CheckMaBill(MaBill).Id : 0;
                if (SoBill != 0)
                {
                    entity.SoBill = SoBill;
                }
                else
                {
                    DMBill dMBill = new DMBill();
                    dMBill.MaBill = MaBill;
                    dMBill.KhachHang = entity.KhachHang;
                    dMBill.CangNhan = entity.CangNhan;
                    entity.SoBill = new DMBillDao().Insert(dMBill);
                    
                }
                if (entity.SoCont != null && new CTBillDao().Check(entity.SoBill, entity.SoCont) == null)
                {
                    CTBill cTBill = new CTBill();
                    cTBill.Bill = entity.SoBill;
                    cTBill.Cont = entity.SoCont;
                    cTBill.Loai = entity.Loai;
                    cTBill.Kho = entity.Kho;
                    cTBill.NgayGiao = entity.Ngay;
                    cTBill.SoXe = entity.Xe;
                    cTBill.HaRong = entity.CangTra;
                    new CTBillDao().Insert(cTBill);
                }
                if (entity.SoCont != null && new CTBillDao().Check(entity.SoBill, entity.SoCont) != null)
                {
                    CTBill cTBill = new CTBill();
                    cTBill.Bill = entity.SoBill;
                    cTBill.Cont = entity.SoCont;
                    cTBill.Loai = entity.Loai;
                    cTBill.Kho = entity.Kho;
                    cTBill.NgayGiao = entity.Ngay;
                    cTBill.SoXe = entity.Xe;
                    cTBill.HaRong = entity.CangTra;
                    new CTBillDao().Update(cTBill);
                }
            }
            db.PhatSinhs.Add(entity);
            //if (entity.CuocKH != null)
            //{
            //    var a = Convert.ToString(entity.CuocKH).Replace(",", " ").Trim();
            //    data.CuocKH = Convert.ToDecimal(a.Replace(" ", ""));
            //}
            //if (entity.CuocTX != null)
            //{
            //    var a = Convert.ToString(entity.CuocTX).Replace(",", " ").Trim();
            //    data.CuocTX = Convert.ToDecimal(a.Replace(" ", ""));
            //}
            db.SaveChanges();
            return entity.Id;
        }
        public bool UpdateGhiChuLuong(PhatSinh phatSinh)
        {
            try
            {
                var item = db.PhatSinhs.Find(phatSinh.Id);
                item.GhiChuLuong = phatSinh.GhiChuLuong;
                item.DateUpdate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private int CheckSoCont(string SoCont)
        {
            return db.PhatSinhs.Where(x => x.SoCont == SoCont).Count();
        }

        public bool? ChangeStatusVAT(long id)
        {
            var item = db.PhatSinhs.Find(id);
            item.VAT = !item.VAT;
            db.SaveChanges();

            return item.VAT;
        }

        public bool UpdateGhiChuThanhToan(PhatSinh phatSinh)
        {
            try
            {
                var item = db.PhatSinhs.Find(phatSinh.Id);
                item.GhiChuThanhToan = phatSinh.GhiChuThanhToan;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool UpdateGhiChuChiHo(PhatSinh phatSinh)
        {
            try
            {
                var item = db.PhatSinhs.Find(phatSinh.Id);
                item.GhiChuChiHo = phatSinh.GhiChuChiHo;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(PhatSinh phatSinh, string MaBill)
        {
            try
            {
                var item = db.PhatSinhs.Find(phatSinh.Id);
                var Cont = item.SoCont;
                if (MaBill != null)
                {
                    var dao = new DMBillDao().CheckMaBill(MaBill) != null ? new DMBillDao().CheckMaBill(MaBill).Id : 0;
                    if (dao == 0)
                    {
                        DMBill dMBill = new DMBill();
                        dMBill.MaBill = MaBill;
                        dMBill.KhachHang = phatSinh.KhachHang;
                        dMBill.CangNhan = phatSinh.CangNhan;
                        phatSinh.SoBill = new DMBillDao().Insert(dMBill);
                    }
                    else
                    {
                        phatSinh.SoBill = dao;
                    }
                    if (phatSinh.SoCont != null && new CTBillDao().Check(phatSinh.SoBill, phatSinh.SoCont) == null)
                    {
                        CTBill cTBill = new CTBill();
                        cTBill.Bill = phatSinh.SoBill;
                        cTBill.Cont = phatSinh.SoCont;
                        cTBill.Loai = phatSinh.Loai;
                        cTBill.Kho = phatSinh.Kho;
                        cTBill.NgayGiao = phatSinh.Ngay;
                        cTBill.SoXe = phatSinh.Xe;
                        cTBill.HaRong = phatSinh.CangTra;
                        var CTBId = new CTBillDao().Insert(cTBill);
                    }
                    else if (phatSinh.SoCont != null && new CTBillDao().Check(phatSinh.SoBill, phatSinh.SoCont) != null)
                    {
                        CTBill cTBill = new CTBill();
                        cTBill.Id = new CTBillDao().Check(phatSinh.SoBill, phatSinh.SoCont).Id;
                        cTBill.Bill = phatSinh.SoBill;
                        cTBill.Cont = phatSinh.SoCont;
                        cTBill.Loai = phatSinh.Loai;
                        cTBill.Kho = phatSinh.Kho;
                        cTBill.NgayGiao = phatSinh.Ngay;
                        cTBill.SoXe = phatSinh.Xe;
                        cTBill.HaRong = phatSinh.CangTra;
                        new CTBillDao().Update(cTBill);
                    }
                    if (Cont != null && Cont != phatSinh.SoCont && new CTBillDao().Check(phatSinh.SoBill, Cont) != null && CheckSoCont(Cont) == 1)
                    {
                        new CTBillDao().Delete(new CTBillDao().Check(phatSinh.SoBill, Cont).Id);
                    }
                }
                item.Ngay = phatSinh.Ngay;
                item.Loai = phatSinh.Loai;
                item.KhachHang = phatSinh.KhachHang;
                item.Kho = phatSinh.Kho;
                item.SoCont = phatSinh.SoCont;
                item.SoBill = phatSinh.SoBill;
                item.CangNhan = phatSinh.CangNhan;
                item.CangTra = phatSinh.CangTra;
                item.CuocKH = phatSinh.CuocKH;
                item.CuocTX = phatSinh.CuocTX;
                item.TenTX = phatSinh.TenTX;
                item.Xe = phatSinh.Xe;
                item.HDNang = phatSinh.HDNang;
                item.TienNang = phatSinh.TienNang;
                item.HDHa = phatSinh.HDHa;
                item.TienHa = phatSinh.TienHa;
                item.PhiKH = phatSinh.PhiKH;
                item.TienPhiKH = phatSinh.TienPhiKH;
                item.PhiCT = phatSinh.PhiCT;
                item.TienPhiCT = phatSinh.TienPhiCT;
                item.GhiChu = phatSinh.GhiChu;
                item.VAT = phatSinh.VAT;
                item.Thoigian = phatSinh.Thoigian;
                item.TiLe = phatSinh.TiLe;
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
                var item = db.PhatSinhs.Find(id);
                db.PhatSinhs.Remove(item);
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