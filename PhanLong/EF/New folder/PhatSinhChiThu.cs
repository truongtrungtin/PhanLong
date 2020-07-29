namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhatSinhChiThu")]
    public partial class PhatSinhChiThu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhatSinhChiThu()
        {
            CTChiThus = new HashSet<CTChiThu>();
        }

        public long Id { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày: ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Ngay { get; set; }
        public long? NguoiChiThu { get; set; }
        [Display(Name = "Người nhận: ")]
        public long? NguoiNhan { get; set; }
        [Display(Name = "Hình thức thanh toán: ")]
        public long? HTTT { get; set; }
        [Display(Name = "Khách hàng: ")]
        public long? KhachHang { get; set; }
        [Display(Name = "Số Bill: ")]
        public long? Bill { get; set; }
        [Display(Name = "Mooc: ")]
        public long? Mooc { get; set; }
        [Display(Name = "Xe: ")]
        public long? Xe { get; set; }

        [StringLength(50)]
        [Display(Name = "Số hoá đơn: ")]
        public string SoHD { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú: ")]
        public string GhiChu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateUpdate { get; set; }

        [Column(TypeName = "xml")]
        public string Files { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTChiThu> CTChiThus { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        public virtual DMKhachHang DMKhachHang1 { get; set; }

        public virtual DMMooc DMMooc { get; set; }

        public virtual DMNhanVien DMNhanVien { get; set; }

        public virtual DMXe DMXe { get; set; }

        public virtual HinhThucTT HinhThucTT { get; set; }
    }
}
