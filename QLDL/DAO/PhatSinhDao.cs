﻿using QLDL.EF;
using System;
using System.Collections.Generic;
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
        public List<PhatSinh> ListAll()
        {
            return db.PhatSinhs.OrderBy(x => x.Id).ToList();
        }

        public PhatSinh GetById(long id)
        {
            return db.PhatSinhs.SingleOrDefault(x => x.Id == id);
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