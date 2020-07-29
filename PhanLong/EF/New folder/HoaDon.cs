namespace PhanLong.EF
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

        [Column(TypeName = "date"), Display(Name = "Ngày lập: ")]
        public DateTime? NgayHD { get; set; }

        [StringLength(10), Display(Name = "Số hoá đơn: ")]
        public string SoHD { get; set; }
        [Display(Name = "Khách hàng: ")]
        public long? KH { get; set; }

        [StringLength(50), Display(Name = "Nội dung: ")]
        public string NoiDung { get; set; }

        [StringLength(250), Display(Name = "Ghi chú: ")]
        public string GhiChu { get; set; }
        [Display(Name = "Số Bill: ")]
        public long? SoBill { get; set; }

        [StringLength(250), Display(Name = "Số Cont: ")]
        public string SoCont { get; set; }
        [Display(Name = "Số lượng cont: ")]
        public int? SoLuong { get; set; }
        [Display(Name = "Tiền cước: ")]
        public decimal? TienCuoc { get; set; }
        [Display(Name = "VAT: ")]
        public double? VAT { get; set; }
        [Display(Name = "Tiền chi hộ: ")]
        public decimal? ChiHo { get; set; }

        [Column(TypeName = "date"), Display(Name = "Ngày thanh toán: ")]
        public DateTime? NgayThanhToan { get; set; }
        [Display(Name = "Tiền thanh toán: ")]
        public decimal? TienThanhToan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateUpdate { get; set; }

        [Column(TypeName = "xml")]
        public string Files { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }
    }
}
