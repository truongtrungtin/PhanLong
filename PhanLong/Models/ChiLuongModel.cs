using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhanLong.Models
{
    public   class ChiLuongModel
    {

        public DateTime NgayChi { get; set; }

        public decimal? TienTru { get; set; }
        public string NoiDung { get; set; }
        public string HinhThucTT { get; set; }
        public string ghichu { get; set; }
        public virtual ThanhToanLuongModel ThanhToanLuong { get; set; }

    }
}