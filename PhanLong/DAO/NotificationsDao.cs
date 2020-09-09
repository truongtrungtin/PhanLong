using PhanLong.EF;
using PhanLong.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanLong.DAO
{
    public class NotificationsDao
    {
        PhanLongDBContext db = null;
        public NotificationsDao()
        {
            db = new PhanLongDBContext();
        }

        public List<NotificationsModel> GetNotificationsLuuBai()
        {
            var data = from a in db.DMBills
                       join b in db.CTBills on a.Id equals b.Bill
                       select new NotificationsModel()
                       {
                           IdBill = a.Id,
                           Bill = a.MaBill,
                           Cont = b.Cont,
                           HanLuuBai = b.HanLuuBai,
                           Ngaygiao = b.NgayGiao,
                           NgayLuuBai = b.NgayGui,
                       };

            return data.OrderBy(x=>x.HanLuuBai).ToList();

        }
        public List<NotificationsModel> GetNotificationsLuuCont()
        {
            var data = from a in db.DMBills
                       join b in db.CTBills on a.Id equals b.Bill
                       select new NotificationsModel()
                       {
                           IdBill = a.Id,
                           Bill = a.MaBill,
                           Cont = b.Cont,
                           Ngaygiao = b.NgayGiao,
                           NgayLuuBai = b.NgayGui,
                           HanLuuCont = b.HanLuuCont,
                       };

            return data.OrderBy(x => x.HanLuuCont).ToList();

        }
        public List<NotificationsModel> GetNotificationsLuuRong()
        {
            var data = from a in db.DMBills
                       join b in db.CTBills on a.Id equals b.Bill
                       select new NotificationsModel()
                       {
                           IdBill = a.Id,
                           Bill = a.MaBill,
                           Cont = b.Cont,
                           Ngaygiao = b.NgayGiao,
                           NgayLuuBai = b.NgayGui,
                           HanLuuRong = b.HanLuuRong,
                       };

            return data.OrderBy(x => x.HanLuuRong).ToList();

        }
    }
}