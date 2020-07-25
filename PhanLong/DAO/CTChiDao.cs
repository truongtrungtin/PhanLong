using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PhanLong.DAO
{
    public class CTChiDao
    {
        PhanLongDBContext db = null;
        public CTChiDao()
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
                    var article = db.CTChiThus.Where(x => x.Id == temp).SingleOrDefault();
                    db.CTChiThus.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public bool importData(DataTable dt,CTChiThu cTChiThu,PhatSinhChiThu phatSinhChiThu, DMXe dMXe, DMMooc dMMooc, DMPhi dMPhi)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        var PhatSinhCT = dr["Phát sinh chi thu"].ToString();

                        var Phi = dr["Phí"].ToString();
                        long? psct = null;
                  
                        long? phi = null;

                        if (PhatSinhCT != null && PhatSinhCT != "")
                        {
                            foreach (var item in db.PhatSinhChiThus)
                            {
                                if (item.Id == Convert.ToInt32(PhatSinhCT))
                                {
                                    psct = item.Id;
                                }
                            }
                        }
                        else
                        {
                            psct = null;
                        }
                        if (Phi != null && Phi != "")
                        {
                            foreach (var item in db.DMPhis)
                            {
                                if (item.MaPhi == Phi || item.TenPhi == Phi)
                                {
                                    phi = item.Id;
                                }

                            }
                            if (phi == null)
                            {
                                var dao = new DMPhiDao().InsertPhi(dMPhi, Phi,1);
                                phi = dao;
                            }
                        }
                        else
                        {
                            phi = null;
                        }
                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {

                            if (column.ColumnName == "Phát sinh chi thu")
                            {
                                
                                    cTChiThu.PhatSinhChiThu = Convert.ToInt32(psct);
                                
                            }
                            else if (column.ColumnName == "Phí")
                            {
                                
                                    cTChiThu.Phi = phi;
                                
                            }
                           
                            else if (column.ColumnName == "Cont")
                            {
                                if (dr["Cont"].ToString() != "")
                                {
                                    cTChiThu.Cont = dr["Cont"].ToString();

                                }
                                else
                                {
                                    cTChiThu.Cont = null;
                                }

                            }
                            else if (column.ColumnName == "Nội dung")
                            {
                                if (dr["Nội dung"].ToString() != "")
                                {
                                    cTChiThu.NoiDung = dr["Nội dung"].ToString();

                                }
                                else
                                {
                                    cTChiThu.NoiDung = null;
                                }

                            }
                            else if (column.ColumnName == "Đơn giá")
                            {
                                if (dr["Đơn giá"].ToString() != null && dr["Đơn giá"].ToString() != "")
                                {
                                    cTChiThu.DonGia = Convert.ToDecimal(dr["Đơn giá"]);
                                }
                                else
                                {
                                    cTChiThu.DonGia = null;
                                }

                            }
                            else if (column.ColumnName == "Số lượng")
                            {
                                if (dr["Số lượng"].ToString() != "")
                                {
                                    cTChiThu.SoLuong = Convert.ToInt32(dr["Số lượng"]);

                                }
                                else
                                {
                                    cTChiThu.SoLuong = 1;
                                }

                            }
                            else if (column.ColumnName == "Garage")
                            {
                                if (dr["Garage"].ToString() != "")
                                {
                                    cTChiThu.Garage = dr["Garage"].ToString();

                                }
                                else
                                {
                                    cTChiThu.Garage = null;
                                }

                            }

                        }
                        var data = db.CTChiThus.Add(cTChiThu);
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
        public List<CTChiThu> listBill(long? bill)
        {
            return db.CTChiThus.Where(x => x.PhatSinhChiThu1.Bill == bill).OrderByDescending(x => x.Id).ToList();
        }
        public List<CTChiThu> ListAll(long phatSinhChi)
        {
            return db.CTChiThus.Where(x => x.PhatSinhChiThu == phatSinhChi).OrderByDescending(x => x.Id).ToList();
        }

        public CTChiThu GetById(long? id)
        {
            return db.CTChiThus.SingleOrDefault(x => x.Id == id);
        }

        public long Insert(CTChiThu entity, long? idChi = null)
        {
            var item = db.CTChiThus.Add(entity);
            if (idChi != null)
            {
                item.PhatSinhChiThu = idChi;
            }
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(CTChiThu cTChi)
        {
            try
            {
                var item = db.CTChiThus.Find(cTChi.Id);
                item.Cont = cTChi.Cont;
                item.NoiDung = cTChi.NoiDung;
                item.Phi = cTChi.Phi;
                item.DonGia = cTChi.DonGia;
                item.SoLuong = cTChi.SoLuong;
                item.Garage = cTChi.Garage;
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
                var item = db.CTChiThus.Find(id);
                db.CTChiThus.Remove(item);
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