using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PhanLong.DAO
{
    public class DMKhachHangDao
    {
        PhanLongDBContext db = null;
        public DMKhachHangDao()
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
                    var article = db.DMKhachHangs.Where(x => x.Id == temp).SingleOrDefault();
                    db.DMKhachHangs.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool importData(DataTable dt, DMKhachHang dMKhachHang)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {

                            if (column.ColumnName == "Mã khách hàng")
                            {
                                if (dr["Mã khách hàng"].ToString() != "" && dr["Mã khách hàng"].ToString() != null)
                                {
                                    dMKhachHang.MaKH = dr["Mã khách hàng"].ToString();

                                }
                                else
                                {
                                    dMKhachHang.MaKH = null;

                                }
                            }
                            else if (column.ColumnName == "Tên công ty")
                            {
                                if (dr["Tên công ty"].ToString() != "" && dr["Tên công ty"].ToString() != null)
                                {
                                    dMKhachHang.TenCongTy = dr["Tên công ty"].ToString();

                                }
                                else
                                {
                                    dMKhachHang.TenCongTy = null;
                                }

                            }
                            else if (column.ColumnName == "Mã số thuế")
                            {
                                if (dr["Mã số thuế"].ToString() != "" && dr["Mã số thuế"].ToString() != null)
                                {
                                    dMKhachHang.MST = dr["Mã số thuế"].ToString();

                                }
                                else
                                {
                                    dMKhachHang.MST = null;
                                }


                            }
                            else if (column.ColumnName == "Địa chỉ")
                            {
                                if (dr["Địa chỉ"].ToString() != "" && dr["Địa chỉ"].ToString() != null)
                                {
                                    dMKhachHang.DiaChi = dr["Địa chỉ"].ToString();

                                }
                                else
                                {
                                    dMKhachHang.DiaChi = null;
                                }


                            }
                            else if (column.ColumnName == "Người liên hệ")
                            {
                                if (dr["Người liên hệ"].ToString() != "" && dr["Người liên hệ"].ToString() != null)
                                {
                                    dMKhachHang.NguoiLienHe = dr["Người liên hệ"].ToString();

                                }
                                else
                                {
                                    dMKhachHang.NguoiLienHe = null;

                                }


                            }
                            else if (column.ColumnName == "Số điện thoại")
                            {
                                if (dr["Số điện thoại"].ToString() != "" && dr["Số điện thoại"].ToString() != null)
                                {
                                    dMKhachHang.SoDienThoai = dr["Số điện thoại"].ToString();

                                }
                                else
                                {
                                    dMKhachHang.SoDienThoai = null;
                                }


                            }
                        }
                        var data = db.DMKhachHangs.Add(dMKhachHang);
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
        public List<DMKhachHang> ListAll()
        {
            return db.DMKhachHangs.OrderByDescending(x => x.Id).ToList();
        }
        public List<DMKhachHang> Check(string MaKhachHang)
        {
            return db.DMKhachHangs.Where(x => x.MaKH == MaKhachHang).ToList();
        }
        public DMKhachHang GetById(long? id)
        {
            return db.DMKhachHangs.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMKhachHang entity)
        {
            db.DMKhachHangs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public long InsertKhachHang(DMKhachHang entity, string kh)
        {
            entity.MaKH = kh;
            entity.TenCongTy = kh;
            db.DMKhachHangs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool Update(DMKhachHang dMKhachHang)
        {
            try
            {
                var item = db.DMKhachHangs.Find(dMKhachHang.Id);
                item.TenCongTy = dMKhachHang.TenCongTy;
                item.MST = dMKhachHang.MST;
                item.DiaChi = dMKhachHang.DiaChi;
                item.NguoiLienHe = dMKhachHang.NguoiLienHe;
                item.SoDienThoai = dMKhachHang.SoDienThoai;
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
                var item = db.DMKhachHangs.Find(id);
                db.DMKhachHangs.Remove(item);
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