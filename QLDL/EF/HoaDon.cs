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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            CTHoaDons = new HashSet<CTHoaDon>();
        }

        public long Id { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày HD")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayHD { get; set; }

        [StringLength(10)]
        [Display(Name = "Số HD")]
        public string SoHD { get; set; }

        [Display(Name = "Khách hàng")]
        public long? KH { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHoaDon> CTHoaDons { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }
    }
}
