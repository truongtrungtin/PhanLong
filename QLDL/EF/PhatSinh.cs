namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhatSinh")]
    public partial class PhatSinh
    {
        public long Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngay { get; set; }

        public long? Loai { get; set; }

        public long? KhachHang { get; set; }

        public long? Kho { get; set; }

        [StringLength(50)]
        public string SoCont { get; set; }

        public long? SoBill { get; set; }

        public long? CangNhan { get; set; }

        public long? CangTra { get; set; }

        public decimal? CuocKH { get; set; }

        public decimal CuocTX { get; set; }

        public long? TenTX { get; set; }

        public long? Xe { get; set; }

        [StringLength(50)]
        public string HDNang { get; set; }

        public decimal? TienNang { get; set; }

        [StringLength(50)]
        public string HDHa { get; set; }

        public decimal? TienHa { get; set; }

        public long? PhiKH { get; set; }

        public decimal? TienPhiKH { get; set; }

        public long? PhiCT { get; set; }

        public decimal? TienPhiCT { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        [StringLength(250)]
        public string Thoigian { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMCang DMCang { get; set; }

        public virtual DMCang DMCang1 { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        public virtual DMKho DMKho { get; set; }

        public virtual DMLoai DMLoai { get; set; }

        public virtual DMNhanVien DMNhanVien { get; set; }

        public virtual DMPhi DMPhi { get; set; }

        public virtual DMPhi DMPhi1 { get; set; }

        public virtual DMXe DMXe { get; set; }
    }
}
