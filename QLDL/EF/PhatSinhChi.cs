namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhatSinhChi")]
    public partial class PhatSinhChi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhatSinhChi()
        {
            CTChis = new HashSet<CTChi>();
        }

        public long Id { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày chi")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayChi { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        [StringLength(50)]
        [Display(Name = "Số HD")]
        public string SoHD { get; set; }

        [Display(Name = "Số Bill")]
        public long? Bill { get; set; }

        [Display(Name = "Người chi")]
        public long? NguoiChi { get; set; }

        [Display(Name = "Người nhận")]
        public long? NguoiNhan { get; set; }

        [Display(Name = "Khách hàng")]
        public long? KhachHang { get; set; }

        [Display(Name = "Số tiền")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal? Tien { get; set; }

        [Display(Name = "HTTT")]
        public long? HTTT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTChi> CTChis { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        public virtual DMNhanVien DMNhanVien { get; set; }

        public virtual DMNhanVien DMNhanVien1 { get; set; }

        public virtual HinhThucTT HinhThucTT { get; set; }
    }
}
