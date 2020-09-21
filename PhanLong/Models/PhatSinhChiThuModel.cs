using System;

namespace PhanLong.Models
{
    public class PhatSinhChiThuModel
    {
        public long id { get; set; }
        public DateTime Ngay { get; set; }
        public string NguoiChiThu { get; set; }
        public string NguoiNhan { get; set; }
        public string HinhThucThanhToan { get; set; }
        public string KhachHang { get; set; }
        public string Xe { get; set; }
        public string Mooc { get; set; }
        public string NoiDung { get; set; }
        public string LoaiPhi { get; set; }
        public string TenPhi { get; set; }
        public string SoBill { get; set; }
        public string SoHD { get; set; }
        public decimal? TienChi { get; set; }
        public string GhiChu { get; set; }
    }
}