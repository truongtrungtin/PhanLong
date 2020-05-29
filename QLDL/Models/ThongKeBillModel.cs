using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace QLDL.Models
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