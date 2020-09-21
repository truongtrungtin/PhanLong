using System;

namespace PhanLong.Models
{
    public class PhatSinhLuongModel
    {
        public long id { get; set; }
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