using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhanLong.Models
{
    public class NotificationsModel
    {
        public long IdBill { set; get; }
        public string Bill { set; get; }

        public string Cont { set; get; }

        public DateTime? HanLuuBai { set; get; }
        public DateTime? HanLuuCont { set; get; }
        public DateTime? HanLuuRong { set; get; }

        public DateTime? Ngaygiao { set; get; }

        public DateTime? NgayLuuBai { set; get; }
    }
}