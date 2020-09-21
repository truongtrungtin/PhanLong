using System;

namespace PhanLong.Models
{
    public partial class ThongKeBillModel
    {
        public long IdBill { get; set; }
        public string MaBill { get; set; }

        public DateTime NgayGui { get; set; }

        public DateTime HanLuuBai { get; set; }

        public DateTime HanLuuRong { get; set; }

        public DateTime HanLuuCont { get; set; }

        public string kho { get; set; }

    }
}