using PhanLong.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhanLong.DAO
{
    public class DMMoocDao
    {
        PhanLongDBContext db = null;
        public DMMoocDao()
        {
            db = new PhanLongDBContext();
        }
        public long InsertMooc(DMMooc entity, string mooc)
        {
            entity.MaMooc = mooc;
            entity.BienSo = mooc;
            db.DMMoocs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public bool checkbox(int[] chkId)
        {
            try
            {
                for (int i = 0; i < chkId.Length; i++)
                {
                    int temp = chkId[i];
                    var article = db.DMMoocs.Where(x => x.Id == temp).SingleOrDefault();
                    db.DMMoocs.Remove(article);
                }
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }
        public List<DMMooc> ListAll()
        {
            return db.DMMoocs.OrderByDescending(x => x.Id).ToList();
        }

        public List<DMMooc> Check(string MaMooc)
        {
            return db.DMMoocs.Where(x => x.MaMooc == MaMooc).ToList();

        }
        public DMMooc GetById(long? id)
        {
            return db.DMMoocs.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(DMMooc entity)
        {
            db.DMMoocs.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public bool Update(DMMooc dMMooc)
        {
            try
            {
                var item = db.DMMoocs.Find(dMMooc.Id);
                item.MaMooc = dMMooc.MaMooc;
                item.BienSo = dMMooc.BienSo;
                item.NgayDangKiem = dMMooc.NgayDangKiem;
                item.HanDangKiem = dMMooc.HanDangKiem;
                item.NhanHieu = dMMooc.NhanHieu;
                item.SoKhung = dMMooc.SoKhung;
                item.NamSanXuat = dMMooc.NamSanXuat;
                item.HanSuDung = dMMooc.HanSuDung;
                item.TaiTrong = dMMooc.TaiTrong;
                item.LoaiVo = dMMooc.LoaiVo;
                item.Ruot = dMMooc.Ruot;
                item.SoLuongVo = dMMooc.SoLuongVo;
                item.NguoiBan = dMMooc.NguoiBan;
                item.HopDong = dMMooc.HopDong;
                item.NgayMua = dMMooc.NgayMua;
                item.SoTien = dMMooc.SoTien;
                item.HopDong = dMMooc.HopDong;
                item.SoHoaDon = dMMooc.SoHoaDon;
                item.GhiChu = dMMooc.GhiChu;
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
                var item = db.DMMoocs.Find(id);
                db.DMMoocs.Remove(item);
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