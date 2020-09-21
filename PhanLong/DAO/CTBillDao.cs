using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PhanLong.DAO
{
    public class CTBillDao
    {
        PhanLongDBContext db = null;
        public CTBillDao()
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
                                if (item.MaLoai == MaLoai)
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
                        else
                        {
                            Loai = null;
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
                        else
                        {
                            BaiGui = null;
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
                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {
                            if (column.ColumnName == "Số Bill")
                            {
                                cTBill.Bill = Bill;
                            }
                            else if (column.ColumnName == "Số cont")
                            {
                                if (dr["Số cont"].ToString() != "")
                                {
                                    cTBill.Cont = dr["Số cont"].ToString();
                                }
                                else
                                {
                                    cTBill.Cont = null;
                                }

                            }
                            else if (column.ColumnName == "Số đăng ký")
                            {
                                if (dr["Số đăng ký"].ToString() != "")
                                {
                                    cTBill.SoDK = dr["Số đăng ký"].ToString();
                                }
                                else
                                {
                                    cTBill.SoDK = null;
                                }

                            }
                            else if (column.ColumnName == "Loại")
                            {
                                cTBill.Loai = Loai;
                            }
                            else if (column.ColumnName == "Seal")
                            {
                                if (dr["Seal"].ToString() != "")
                                {
                                    cTBill.Seal = dr["Seal"].ToString();
                                }
                                else
                                {
                                    cTBill.Seal = null;
                                }

                            }
                            else if (column.ColumnName == "Kho")
                            {
                                cTBill.Kho = Kho;
                            }
                            else if (column.ColumnName == "Hạn lưu cont")
                            {
                                var Luucont = dr["Hạn lưu cont"].ToString();
                                if (Luucont != "")
                                {
                                    var hanluucont = Convert.ToDateTime(Luucont).ToShortDateString();
                                    cTBill.HanLuuCont = Convert.ToDateTime(hanluucont);
                                }
                                else
                                {
                                    cTBill.HanLuuCont = null;
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
                                else
                                {
                                    cTBill.HanLuuBai = null;
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
                                else
                                {
                                    cTBill.HanLuuRong = null;
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
                                else
                                {
                                    cTBill.NgayGiao = null;
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
                                else
                                {
                                    cTBill.NgayGui = null;
                                }
                            }
                            else if (column.ColumnName == "Bãi gửi")
                            {
                                cTBill.BaiGui = BaiGui;
                            }
                            else if (column.ColumnName == "Độ dày")
                            {
                                if (dr["Độ dày"].ToString() != "")
                                {
                                    cTBill.DoDay = dr["Độ dày"].ToString();
                                }
                                else
                                {
                                    cTBill.DoDay = null;
                                }
                            }
                            else if (column.ColumnName == "Quy cách")
                            {
                                if (dr["Quy cách"].ToString() != "")
                                {
                                    cTBill.QuyCach = dr["Quy cách"].ToString();
                                }
                                else
                                {
                                    cTBill.QuyCach = null;
                                }

                            }
                            else if (column.ColumnName == "Số Xe")
                            {
                                cTBill.SoXe = Xe;
                            }
                            else if (column.ColumnName == "Ghi chú")
                            {
                                if (dr["Ghi chú"].ToString() != "")
                                {
                                    cTBill.GhiChu = dr["Ghi chú"].ToString();
                                }
                                else
                                {
                                    cTBill.GhiChu = null;
                                }
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
            return db.CTBills.Where(x => x.Bill == bill).OrderBy(x => (x.NgayGiao == null ? x.NgayGiao : x.NgayGui)).ToList();
        }

        public CTBill Check(long Bill, string cont)
        {
            return db.CTBills.SingleOrDefault(x => x.Bill == Bill && x.Cont == cont);
        }

        public CTBill GetById(long? id)
        {
            return db.CTBills.SingleOrDefault(x => x.Id == id);
        }
        public List<CTBill> getbill(long bill)
        {
            return db.CTBills.Where(x => x.Bill == bill).ToList();
        }
        public long? Insert(CTBill entity)
        {
            db.CTBills.Add(entity);
            db.SaveChanges();
            return entity.Bill;
        }

        public DMBill GetLastIdBill()
        {
            return db.DMBills.OrderByDescending(x => x.Id).FirstOrDefault();
        }

        public long InsertCTBill(CTBill entity)
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
                item.DateUpdate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public bool UpdateNgayGiao(CTBill cTBill)
        {
            try
            {
                var item = db.CTBills.SingleOrDefault(x => x.Bill == cTBill.Bill && x.Cont == cTBill.Cont);
                item.NgayGiao = cTBill.NgayGiao;
                item.SoXe = cTBill.SoXe;
                item.DateUpdate = DateTime.Now;
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

        public bool AddFiles(CTBill cTBill)
        {
            try
            {
                var item = db.CTBills.Find(cTBill.Id);
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