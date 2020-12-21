namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DMKho")]
    public partial class DMKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMKho()
        {
            CTBills = new HashSet<CTBill>();
            PhatSinhs = new HashSet<PhatSinh>();
            TraCuuCuocs = new HashSet<TraCuuCuoc>();
        }

        public long Id { get; set; }

        [StringLength(10)]
        [Required, Display(Name = "Mã: ")]
        public string MaKho { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ: ")]
        public string DiaChi { get; set; }

        [StringLength(250)]
        [Display(Name = "Người liên hệ: ")]
        public string NguoiLienHe { get; set; }

        [StringLength(11)]
        [Display(Name = "SĐT: ")]
        public string SoDienThoai { get; set; }

        [StringLength(250)]
        [Display(Name = "Thông tin: ")]
        public string DiaChiChiTiet { get; set; }

        [Display(Name = "Lộ trình: ")]
        public long LoTrinh { get; set; }

        [StringLength(50)]
        [Display(Name = "Giờ cấm: ")]
        public string GioCam { get; set; }

        [StringLength(255)]
        [Display(Name = "Ghí chú: ")]
        public string GhiChu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateUpdate { get; set; }

        [Column(TypeName = "xml")]
        public string Files { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTBill> CTBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TraCuuCuoc> TraCuuCuocs { get; set; }
    }
}
