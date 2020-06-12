using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class CTBillDao
    {
        QLDLDBContext db = null;
        public CTBillDao()
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
                    var article = db.CTBills.Where(x => x.Id == temp).SingleOrDefault();
                    db.CTBills.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool importData(DataTable dt, DMLoai dMLoai, DMKho dMKho, DMXe dMXe, DMCang dMCang, DMBill dMBill)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        CTBill cTBill = new CTBill();
                        var MaLoai = dr["Loại"].ToString();
                        var MaKho = dr["Kho"].ToString();
                        var MaBill = dr["Số Bill"].ToString();
                        var MaCang = dr["Bãi gửi"].ToString();
                        var MaXe = dr["Số Xe"].ToString();
                        long? Loai = null;
                        long? Kho = null;
                        long? Bill = null;
                        long? BaiGui = null;
                        long? Xe = null;
                        if (MaLoai != "")
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
                                var dao = new DMBillDao().InsertBill(dMBill, MaBill);
                                Bill = dao;
                            }
                        }
                        if (MaCang != "")
                        {
                            foreach (var item in db.DMCangs)
                            {
                                if (item.MaCang == MaCang || item.TenCang == MaCang)
                                {
                                    BaiGui = item.Id;
                                }

                            }
                            if (BaiGui == null)
                            {
                                var dao = new DMCangDao().InsertCang(dMCang, MaCang);
                                BaiGui = dao;
                            }
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
                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {

                            
                            if (column.ColumnName == "Số Bill")
                            {
                                if (Bill != null)
                                {
                                    cTBill.Bill = Bill;
                                }
                            }
                            else if (column.ColumnName == "Số cont")
                            {
                                cTBill.Cont = dr["Số cont"].ToString();
                            }
                            else if (column.ColumnName == "Số đăng ký")
                            {
                                cTBill.SoDK = dr["Số đăng ký"].ToString();
                            }
                            else if (column.ColumnName == "Loại")
                            {
                                if (Loai != null)
                                {
                                    cTBill.Loai = Loai;
                                }

                            }
                            else if (column.ColumnName == "Seal")
                            {
                                cTBill.Seal = dr["Seal"].ToString();
                            }
                            else if (column.ColumnName == "Kho")
                            {
                                if (Kho != null)
                                {
                                    cTBill.Kho = Kho;
                                }
                            }
                            else if (column.ColumnName == "Hạn lưu cont")
                            {
                                var Luucont = dr["Hạn lưu cont"].ToString();
                                if (Luucont != "")
                                {
                                    var hanluucont = Convert.ToDateTime(Luucont).ToShortDateString();
                                    cTBill.HanLuuCont = Convert.ToDateTime(hanluucont);
                                }
                            }
                            else if (column.ColumnName == "Hạn lưu bãi")
                            {
                                var Luubai = dr["Hạn lưu bãi"].ToString();
                                if (Luubai != "")
                                {
                                    var hanluubai = Convert.ToDateTime(Luubai).ToShortDateString();
                                    cTBill.HanLuuBai = Convert.ToDateTime(hanluubai);
                                }
                            }
                            else if (column.ColumnName == "Hạn lưu rỗng")
                            {
                                var Luurong = dr["Hạn lưu rỗng"].ToString();
                                if (Luurong != "")
                                {
                                    var hanlurong = Convert.ToDateTime(Luurong).ToShortDateString();
                                    cTBill.HanLuuRong = Convert.ToDateTime(hanlurong);
                                }
                            }
                            else if (column.ColumnName == "Ngày giao")
                            {
                                var Ngiao = dr["Ngày giao"].ToString();
                                if (Ngiao != "")
                                {
                                    var ngaygiao = Convert.ToDateTime(Ngiao).ToShortDateString();
                                    cTBill.NgayGiao = Convert.ToDateTime(ngaygiao);
                                }
                            }
                            else if (column.ColumnName == "Ngày gửi")
                            {
                                var Ngui = dr["Ngày gửi"].ToString();
                                if (Ngui != "")
                                {
                                    var Ngaygui = Convert.ToDateTime(Ngui).ToShortDateString();
                                    cTBill.NgayGui = Convert.ToDateTime(Ngaygui);
                                }
                            }
                            else if (column.ColumnName == "Bãi gửi")
                            {
                                if (BaiGui != null)
                                {
                                    cTBill.BaiGui = BaiGui;
                                }
                            }
                            else if (column.ColumnName == "Độ dày")
                            {
                                cTBill.DoDay = dr["Độ dày"].ToString();
                            }
                            else if (column.ColumnName == "Quy cách")
                            {
                                cTBill.QuyCach = dr["Quy cách"].ToString();
                            }
                            else if (column.ColumnName == "Số Xe")
                            {
                                if (Xe != null)
                                {
                                    cTBill.SoXe = Xe;
                                }
                            }
                            else if (column.ColumnName == "Ghi chú")
                            {

                                cTBill.GhiChu = dr["Ghi chú"].ToString();

                            }
                            
                        }
                        var data = db.CTBills.Add(cTBill);
                        db.SaveChanges();
                    }
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<CTBill> ListAll(long? bill)
        {
            return db.CTBills.Where(x => x.Bill == bill).OrderByDescending(x => (x.NgayGiao != null ? x.NgayGiao : x.NgayGui)).ToList();
        }


        public CTBill GetById(long? id)
        {
            return db.CTBills.SingleOrDefault(x => x.Id == id);
        }

        public List<CTBill> getbill(string cont)
        {
            return db.CTBills.Where(x => x.Cont == cont).ToList();
        }
        public long Insert(CTBill entity)
        {
            db.CTBills.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        
        public DMBill GetLastIdBill()
        {
            return db.DMBills.OrderByDescending(x => x.Id).FirstOrDefault();
        }

        public long InsertCTBill (CTBill entity)
        {
            var item = db.CTBills.Add(entity);
            item.Bill = GetLastIdBill().Id;
            db.SaveChanges();
            return entity.Id;
        }


        public bool UpdateNgayGui(CTBill cTBill)
        {
            try
            {
                var item = db.CTBills.Find(cTBill.Id);
                item.NgayGui = cTBill.NgayGui;
                item.SoXe = cTBill.SoXe;
                item.BaiGui = cTBill.BaiGui;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateNGui(CTBill cTBill)
        {
            try
            {
                var item = db.CTBills.SingleOrDefault(x=> x.Cont == cTBill.Cont);
                item.NgayGui = cTBill.NgayGui;
                item.SoXe = cTBill.SoXe;
                item.BaiGui = cTBill.BaiGui;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Update(CTBill cTBill)
        {
            try
            {
                var item = db.CTBills.Find(cTBill.Id);
                item.Cont = cTBill.Cont;
                item.SoDK = cTBill.SoDK;
                item.Loai = cTBill.Loai;
                item.Seal = cTBill.Seal;
                item.Kho = cTBill.Kho;
                item.HanLuuCont = cTBill.HanLuuCont;
                item.HanLuuBai = cTBill.HanLuuBai;
                item.HanLuuRong = cTBill.HanLuuRong;
                item.NgayGiao = cTBill.NgayGiao;
                item.DoDay = cTBill.DoDay;
                item.QuyCach = cTBill.QuyCach;
                item.SoXe = cTBill.SoXe;
                item.NgayGui = cTBill.NgayGui;
                item.GhiChu = cTBill.GhiChu;
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
                var item = db.CTBills.Find(id);
                db.CTBills.Remove(item);
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