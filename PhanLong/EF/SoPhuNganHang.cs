namespace PhanLong.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("SoPhuNganHang")]
    public partial class SoPhuNganHang
    {
        public long Id { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày: ")]
        public DateTime? Ngay { get; set; }

        [Display(Name = "Khách hàng: ")]
        public long? MaKH { get; set; }

        [Display(Name = "Hình thức: ")]
        public long? HTTT { get; set; }

        [StringLength(250)]
        [Display(Name = "Nội dung: ")]
        public string NoiDung { get; set; }

        [Display(Name = "Phí: ")]
        public long? Phi { get; set; }

        [Display(Name = "Tiền chi: ")]
        public decimal? TienChi { get; set; }

        [Display(Name = "Tiền thu: ")]
        public decimal? TienThu { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú: ")]
        public string GhiChu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateUpdate { get; set; }

        [Column(TypeName = "xml")]
        public string Files { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        public virtual DMPhi DMPhi { get; set; }

        public virtual HinhThucTT HinhThucTT { get; set; }
    }
}
