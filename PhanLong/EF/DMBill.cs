namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DMBill")]
    public partial class DMBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMBill()
        {
            CTBills = new HashSet<CTBill>();
            HoaDons = new HashSet<HoaDon>();
            PhatSinhs = new HashSet<PhatSinh>();
            PhatSinhChiThus = new HashSet<PhatSinhChiThu>();
        }

        public long Id { get; set; }


        [StringLength(20)]
        [Display(Name = "Số tờ khai: ")]
        public string SoToKhai { get; set; }

        [StringLength(250)]
        [Required, Display(Name = "Mã Bill: ")]
        public string MaBill { get; set; }

        [StringLength(250)]
        [Display(Name = "Người gửi: ")]
        public string NguoiGui { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Tàu đến: ")]
        public DateTime? NgayTauDen { get; set; }

        [Display(Name = "Cảng nhận: ")]
        public long? CangNhan { get; set; }

        [Display(Name = "Khách hàng: ")]
        public long? KhachHang { get; set; }


        [Column(TypeName = "date")]
        public DateTime? DateUpdate { get; set; }

        [Column(TypeName = "xml")]
        public string Files { get; set; }

        [StringLength(250)]
        [Display(Name = "Lô: ")]
        public string Lo { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày ĐK: ")]
        public DateTime? NgayDK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTBill> CTBills { get; set; }

        public virtual DMCang DMCang { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhChiThu> PhatSinhChiThus { get; set; }
    }
}
