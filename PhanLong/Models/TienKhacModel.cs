using System;

namespace PhanLong.Models
{
    public class TienKhacModel
    {
        public long Id { get; set; }
        public DateTime Ngay { get; set; }
        public decimal? TienKhac { get; set; }
        public string NoiDung { get; set; }
        public string HinhThucTT { get; set; }
        public long LoaiPhi { get; set; }

        public long Phi { get; set; }
        public string ghichu { get; set; }

    }
}