using QLDL.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QLDL.DAO
{
    public class DMKhoDao
    {
        QLDLDBContext db = null;
        public DMKhoDao()
        {
            db = new QLDLDBContext();
        }
        public long InsertKho(DMKho entity, string kho)
        {
            entity.MaKho = kho;
            entity.DiaChi = kho;
            db.DMKhoes.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public List<DMKho> ListAll()
        {
            return db.DMKhoes.OrderByDescending(x => x.Id).ToList();
        }
        public bool checkbox(int[] chkId)
        {
            try
            {
                for (int i = 0; i < chkId.Length; i++)
                {
                    int temp = chkId[i];
                    var article = db.DMKhoes.Where(x => x.Id == temp).SingleOrDefault();
                    db.DMKhoes.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool importData(DataTable dt, DMKho dMKho)
        {
            try
            {
                if ((dt as System.Data.DataTable).Rows.Count > 0)
                {
                    foreach (DataRow dr in (dt as System.Data.DataTable).Rows)
                    {
                        foreach (DataColumn column in (dt as System.Data.DataTable).Columns)
                        {

                            if (column.ColumnName == "Mã kho")
                            {
                                dMKho.MaKho = dr["Mã kho"].ToString();
                            }
                            else if (column.ColumnName == "Địa chỉ")
                            {

                                dMKho.DiaChi = dr["Địa chỉ"].ToString();

                            }
                            else if (column.ColumnName == "Địa chỉ chi tiết")
                            {

                                dMKho.DiaChiChiTiet = dr["Địa chỉ chi tiết"].ToString();

                            }
                            else if (column.ColumnName == "Người liên hệ")
                            {

                                dMKho.NguoiLienHe = dr["Người liên hệ"].ToString();

                            }
                            else if (column.ColumnName == "Số điện thoại")
                            {

                                dMKho.SoDienThoai = dr["Số điện thoại"].ToString();

                            }
                            else if (column.ColumnName == "Lộ trình")
                            {

                                dMKho.LoTrinh = dr["Lộ trình"].ToString();

                            }
                            else if (column.ColumnName == "Giờ cấm")
                            {

                                dMKho.GioCam = dr["Giờ cấm"].ToString();

                            }
                            else if (column.ColumnName == "Ghi chú")
                            {

                                dMKho.GhiChu = dr["Ghi chú"].ToString();

                            }

                        }
                        var data = db.DMKhoes.Add(dMKho);
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
        public List<DMKho> Check(string MaKho)
        {
            return db.DMKhoes.Where(x => x.MaKho == MaKho).ToList();

        }
        public DMKho GetById(long? id)
        {
            return db.DMKhoes.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMKho entity)
        {
            db.DMKhoes.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }




        public bool Update(DMKho dMKho)
        {
            try
            {
                var item = db.DMKhoes.Find(dMKho.Id);
                item.DiaChi = dMKho.DiaChi;
                item.NguoiLienHe = dMKho.NguoiLienHe;
                item.SoDienThoai = dMKho.SoDienThoai;
                item.DiaChiChiTiet = dMKho.DiaChiChiTiet;
                item.LoTrinh = dMKho.LoTrinh;
                item.GioCam = dMKho.GioCam;
                item.GhiChu = dMKho.GhiChu;
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
                var item = db.DMKhoes.Find(id);
                db.DMKhoes.Remove(item);
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