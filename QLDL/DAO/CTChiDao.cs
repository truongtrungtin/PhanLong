﻿using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace QLDL.DAO
{
    public class CTChiDao
    {
        QLDLDBContext db = null;
        public CTChiDao()
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
                        var PhatSinhChiThu = dr["Phát sinh chi thu"].ToString();
                        var Mooc = dr["Mooc"].ToString();
                        var Xe = dr["Xe"].ToString();
                        var Phi = dr["Phí"].ToString();
                        long? psct = null;
                        long? mooc = null;
                        long? xe = null;
                        long? phi = null;

                        if (PhatSinhChiThu != null)
                        {
                            foreach (var item in db.PhatSinhChiThus)
                            {
                                if (item.Id == psct)
                                {
                                    psct = item.Id;
                                }

                            }
                        }
                        else
                        {
                            psct = null;
                        }
                        if (Mooc != null)
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
                        if (Xe != null)
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
                        if (Phi != null)
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
                                var dao = new DMPhiDao().InsertPhi(dMPhi, Phi);
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
                                if (psct != null)
                                {
                                    cTChiThu.PhatSinhChiThu = psct;
                                }
                            }
                            else if (column.ColumnName == "Mooc")
                            {
                                if (mooc != null)
                                {
                                    cTChiThu.Mooc = mooc;
                                }
                            }
                            else if (column.ColumnName == "Xe")
                            {
                                if (xe != null)
                                {
                                    cTChiThu.Xe = xe;
                                }
                            }
                            else if (column.ColumnName == "Phí")
                            {
                                if (phi != null)
                                {
                                    cTChiThu.Phi = phi;
                                }
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
                item.Mooc = cTChi.Mooc;
                item.Xe = cTChi.Xe;
                item.Cont = cTChi.Cont;
                item.NoiDung = cTChi.NoiDung;
                item.Phi = cTChi.Phi;
                item.DonGia = cTChi.DonGia;
                item.SoLuong = cTChi.SoLuong;
                item.Garage = cTChi.Garage;
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