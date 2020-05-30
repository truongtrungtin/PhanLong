using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLDL.Models
{
    public   class CTTTLuongModel
    {
        public DateTime Ngay { get; set; }
        public string Loai { get; set; }
        public string KhachHang { get; set; }
        public string Kho { get; set; }
        public string SoCont { get; set; }
        public string CangNhan { get; set; }
        public string CangTra { get; set; }
        public decimal? TienCuoc { get; set; }
        public string ghichu { get; set; }
        public virtual ThanhToanLuongModel ThanhToanLuong { get; set; }

    }
}