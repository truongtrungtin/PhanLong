namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        public long Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayHD { get; set; }

        [StringLength(10)]
        public string SoHD { get; set; }

        public long? KH { get; set; }

        [StringLength(50)]
        public string NoiDung { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public long? SoBill { get; set; }

        [StringLength(250)]
        public string SoCont { get; set; }

        public int? SoLuong { get; set; }

        public decimal? TienCuoc { get; set; }

        public double? VAT { get; set; }

        public decimal? ChiHo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThanhToan { get; set; }

        public decimal? TienThanhToan { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }
    }
}
