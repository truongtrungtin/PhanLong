using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class PhatSinhDao
    {
        QLDLDBContext db = null;
        public PhatSinhDao()
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
                        long? Loai = null;
                        long? KH = null;
                        long? Kho = null;
                        long? Bill = null;
                        long? CangNhan = null;
                        long? CangTra = null;
                        long? TaiXe = null;
                        long? Xe = null;
                        long? phikh = null;
                        long? phict = null;
                        long? thoigian = null;
                        if (MaLoai != null)
                        {
                            foreach (var item in db.DMLoais)
                            {
                                if (item.MaLoai == MaLoai || item.MoTa == MaLoai || item.MoTa1 == MaLoai)
                                {
                                    Loai = item.Id;
                                }
                            }
                            if (Loai == null)
                            {
                                var dao = new DMLoaiDao().InsertMaLoai(dMLoai, MaLoai);
                                Loai = dao;

                            }
                        }
                        if (MaKH != null)
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
                        if (MaKho != null)
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
                        if (MaBill != null)
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
                                var dao = new DMBillDao().InsertBill(dMBill, MaBill);
                                Bill = dao;
                            }
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
                        if (MaCangTra != null)
                        {
                            foreach (var item in db.DMCangs)
                            {
                                if (item.MaCang == MaCangTra || item.TenCang == MaCangNhan)
                                {
                                    CangTra = item.Id;
                                }

                            }
                            if (CangTra != null)
                            {
                                var dao = new DMCangDao().InsertCang(dMCang, MaCangTra);
                                CangTra = dao;
                            }
                        }
                        if (TenTX != null)
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
                        if (MaXe != null)
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
                        if (MaPhiKH != null)
                        {
                            foreach (var item in db.DMPhis)
                            {
                                if (item.MaPhi == MaPhiKH || item.TenPhi == MaPhiKH)
                                {
                                    phikh = item.Id;
                                }

                            }
                            if (phikh == null)
                            {
                                var dao = new DMPhiDao().InsertPhi(dMPhi, MaPhiKH);
                                phikh = dao;
                            }
                        }
                        if (MaPhict != null)
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
                                var dao = new DMPhiDao().InsertPhi(dMPhi, MaPhict);
                                phict = dao;
                            }
                        }
                        if (MaThoiGian != null)
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
                                if (Loai != null)
                                {
                                    phatSinh.Loai = Loai.Value;
                                }

                            }
                            else if (column.ColumnName == "Khách hàng")
                            {

                                if (KH != null)
                                {
                                    phatSinh.KhachHang = KH;
                                }
                            }
                            else if (column.ColumnName == "Kho")
                            {
                                if (Kho != null)
                                {
                                    phatSinh.Kho = Kho;
                                }
                            }
                            else if (column.ColumnName == "Cont")
                            {

                                phatSinh.SoCont = dr["Cont"].ToString();

                            }
                            else if (column.ColumnName == "Số Bill")
                            {
                                if (Bill != null)
                                {
                                    phatSinh.SoBill = Bill;
                                }
                            }
                            else if (column.ColumnName == "Cảng nhận")
                            {
                                if (CangNhan != null)
                                {
                                    phatSinh.CangNhan = CangNhan;
                                }
                            }
                            else if (column.ColumnName == "Cảng trả")
                            {
                                if (CangTra != null)
                                {
                                    phatSinh.CangTra = CangTra;
                                }
                            }
                            else if (column.ColumnName == "Cước khách hàng")
                            {
                                var a = dr["Cước khách hàng"].ToString();
                                if (a != "")
                                {
                                    phatSinh.CuocKH = Convert.ToDecimal(a);
                                }
                            }
                            else if (column.ColumnName == "Cước tài xế")
                            {
                                var a = dr["Cước tài xế"].ToString();
                                if (a != "")
                                {
                                    phatSinh.CuocTX = Convert.ToDecimal(a);
                                }
                            }
                            else if (column.ColumnName == "Tài Xế")
                            {
                                if (TaiXe != null)
                                {
                                    phatSinh.TenTX = TaiXe;
                                }
                            }
                            else if (column.ColumnName == "Xe")
                            {
                                if (Xe != null)
                                {
                                    phatSinh.Xe = Xe;
                                }
                            }
                            else if (column.ColumnName == "Chi Phí riêng")
                            {
                                if (phict != null)
                                {
                                    phatSinh.PhiCT = phict;
                                }
                            }
                            else if (column.ColumnName == "Hoá đơn nâng")
                            {

                                phatSinh.HDNang = dr["Hoá đơn nâng"].ToString();

                            }
                            else if (column.ColumnName == "Tiền Nâng")
                            {
                                var a = dr["Tiền Nâng"].ToString();
                                if (a != "")
                                {
                                    phatSinh.TienNang = Convert.ToDecimal(a);
                                }
                            }
                            else if (column.ColumnName == "Hoá đơn hạ")
                            {

                                phatSinh.HDHa = dr["Hoá đơn hạ"].ToString();

                            }
                            else if (column.ColumnName == "Tiền Hạ")
                            {
                                var a = dr["Tiền Hạ"].ToString();
                                if (a != "")
                                {
                                    phatSinh.TienHa = Convert.ToDecimal(a);
                                }
                            }
                            else if (column.ColumnName == "Hoá đơn khác")
                            {

                                if (phikh != null)
                                {
                                    phatSinh.PhiKH = phikh;
                                }

                            }
                            else if (column.ColumnName == "Tiền khác")
                            {
                                var a = dr["Tiền khác"].ToString();
                                if (a != "")
                                {
                                    phatSinh.TienPhiKH = Convert.ToDecimal(a);
                                }
                            }
                            else if (column.ColumnName == "Tiền chi riêng")
                            {
                                var a = dr["Tiền chi riêng"].ToString();
                                if (a != "")
                                {
                                    phatSinh.TienPhiCT = Convert.ToDecimal(a);
                                }
                            }
                            else if (column.ColumnName == "Thời gian")
                            {

                                if (thoigian != null)
                                {
                                    phatSinh.Thoigian = thoigian;
                                }

                            }
                            else if (column.ColumnName == "Ghi chú")
                            {

                                phatSinh.GhiChu = dr["Ghi chú"].ToString();

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

        public List<PhatSinh> Listtk(PhatSinh phatSinh, string sday, string eday)
        {
            IQueryable<PhatSinh> model = db.PhatSinhs;
            DateTime sdate = (sday != "") ? Convert.ToDateTime(sday).Date : new DateTime();
            DateTime edate = (eday != "") ? Convert.ToDateTime(eday).Date : new DateTime();

            if (phatSinh.Kho != null)
            {
                if (phatSinh.Loai != null)
                {
                    if (phatSinh.Xe != null)
                    {
                        if (phatSinh.KhachHang != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.KhachHang != null)
                    {
                        if (phatSinh.Xe != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.Xe != null)
                {
                    if (phatSinh.Loai != null)
                    {
                        if (phatSinh.KhachHang != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.KhachHang != null)
                    {
                        if (phatSinh.Loai != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.KhachHang != null)
                {
                    if (phatSinh.Loai != null)
                    {
                        if (phatSinh.Xe != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.Xe != null)
                    {
                        if (phatSinh.Loai != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else
                {
                    model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                }
            }
            else if (phatSinh.Xe != null)
            {
                if (phatSinh.Loai != null)
                {
                    if (phatSinh.Kho != null)
                    {
                        if (phatSinh.KhachHang != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.KhachHang != null)
                    {
                        if (phatSinh.Kho != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Xe == phatSinh.Xe && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.Kho != null)
                {
                    if (phatSinh.Loai != null)
                    {
                        if (phatSinh.KhachHang != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.KhachHang != null)
                    {
                        if (phatSinh.Loai != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.KhachHang != null)
                {
                    if (phatSinh.Loai != null)
                    {
                        if (phatSinh.Kho != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Xe == phatSinh.Xe && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.Kho != null)
                    {
                        if (phatSinh.Loai != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else
                {
                    model = db.PhatSinhs.Where(x => x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                }
            }
            else if (phatSinh.Loai != null)
            {
                if (phatSinh.Kho != null)
                {
                    if (phatSinh.Xe != null)
                    {
                        if (phatSinh.KhachHang != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.KhachHang != null)
                    {
                        if (phatSinh.Xe != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.Xe != null)
                {
                    if (phatSinh.Kho != null)
                    {
                        if (phatSinh.KhachHang != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.KhachHang != null)
                    {
                        if (phatSinh.Kho != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.KhachHang != null)
                {
                    if (phatSinh.Kho != null)
                    {
                        if (phatSinh.Xe != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.Xe != null)
                    {
                        if (phatSinh.Kho != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else
                {
                    model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                }
            }
            else if (phatSinh.KhachHang != null)
            {
                if (phatSinh.Loai != null)
                {
                    if (phatSinh.Xe != null)
                    {
                        if (phatSinh.Kho != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.KhachHang == phatSinh.KhachHang && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.Kho != null)
                    {
                        if (phatSinh.Xe != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.Xe != null)
                {
                    if (phatSinh.Loai != null)
                    {
                        if (phatSinh.Kho != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.KhachHang == phatSinh.KhachHang && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.Kho != null)
                    {
                        if (phatSinh.Loai != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.KhachHang == phatSinh.KhachHang && x.Xe == phatSinh.Xe && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else if (phatSinh.Kho != null)
                {
                    if (phatSinh.Loai != null)
                    {
                        if (phatSinh.Xe != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else if (phatSinh.Xe != null)
                    {
                        if (phatSinh.Loai != null)
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Loai == phatSinh.Loai && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                        else
                        {
                            model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.Xe == phatSinh.Xe && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                        }
                    }
                    else
                    {
                        model = db.PhatSinhs.Where(x => x.Kho == phatSinh.Kho && x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                    }
                }
                else
                {
                    model = db.PhatSinhs.Where(x => x.KhachHang == phatSinh.KhachHang && ((sday == "" && eday == "") || (x.Ngay >= sdate && x.Ngay <= edate)));
                }
            }
            else
            {
                model = db.PhatSinhs.Where(x => x.Ngay >= sdate && x.Ngay <= edate);
            }
            return model.OrderBy(x => x.Ngay).ToList();
        }

        public PhatSinh GetById(long? id)
        {
            return db.PhatSinhs.SingleOrDefault(x => x.Id == id);
        }
        public PhatSinh GetByData(PhatSinh phatSinh)
        {
            return db.PhatSinhs.Where(x => x.KhachHang == phatSinh.KhachHang || x.Xe == phatSinh.Xe || x.Loai == phatSinh.Xe || x.Kho == phatSinh.Kho).FirstOrDefault();
        }

        public List<PhatSinh> GetLoai(long? id)
        {
            return db.PhatSinhs.Where(x => x.TenTX == id).ToList();
        }
        public long Insert(PhatSinh entity)
        {
            db.PhatSinhs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(PhatSinh phatSinh)
        {
            try
            {
                var item = db.PhatSinhs.Find(phatSinh.Id);
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