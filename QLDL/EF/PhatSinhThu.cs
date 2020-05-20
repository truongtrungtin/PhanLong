namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhatSinhThu")]
    public partial class PhatSinhThu
    {
        public long Id { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày thu")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayThu { get; set; }

        [StringLength(250)]
        [Display(Name = "Nội dung thu")]
        public string NoiDungThu { get; set; }

        [StringLength(50)]
        [Display(Name = "Số HD")]
        public string SoHD { get; set; }

        [Display(Name = "Người thu")]
        public long? NguoiThu { get; set; }

        [Display(Name = "Số Bill")]
        public long? Bill { get; set; }

        [Display(Name = "Khách hàng")]
        public long? KhachHang { get; set; }

        [Display(Name = "Số tiền")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal? Tien { get; set; }

        [Display(Name = "HTTT")]
        public long? HTTT { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        public virtual DMNhanVien DMNhanVien { get; set; }

        public virtual HinhThucTT HinhThucTT { get; set; }
    }
}
