using PhanLong.EF;
using PhanLong.Models;
using System.Collections.Generic;
using System.Linq;

namespace PhanLong.DAO
{
    public class NotificationsDao
    {
        PhanLongDBContext db = null;
        public NotificationsDao()
        {
            db = new PhanLongDBContext();
        }


        public List<NotificationsModel> GetNotifications()
        {
            var data = from a in db.DMBills
                       join b in db.CTBills on a.Id equals b.Bill
                       select new NotificationsModel()
                       {
                           IdBill = a.Id,
                           Bill = a.MaBill,
                           Ngaygiao = b.NgayGiao,
                           NgayLuuBai = b.NgayGui,
                           HanLuuRong = b.HanLuuRong,
                           HanLuuCont = b.HanLuuCont,
                           HanLuuBai = b.HanLuuBai,
                           GhiChuBill = a.GhiChuBill,
                       };

            return data.ToList();
        }
    }
}