using QLDL.EF;
using System;
using System.Collections.Generic;
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
        public List<CTBill> ListAll(long bill)
        {
            return db.CTBills.Where(x => x.Bill == bill).OrderByDescending(x => x.NgayGiao).ToList();
        }

        public CTBill GetById(long? id)
        {
            return db.CTBills.SingleOrDefault(x => x.Id == id);
        }
        public long Insert(CTBill entity)
        {
            db.CTBills.Add(entity);
            db.SaveChanges();
            return entity.Id;
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
                item.TrangThaiLuuCont = cTBill.TrangThaiLuuCont;
                item.TrangThaiLuuBai = cTBill.TrangThaiLuuBai;
                item.TrangThaiLuuRong = cTBill.TrangThaiLuuRong;
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