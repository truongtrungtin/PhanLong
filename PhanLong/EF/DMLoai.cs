namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DMLoai")]
    public partial class DMLoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMLoai()
        {
            CTBills = new HashSet<CTBill>();
            PhatSinhs = new HashSet<PhatSinh>();
        }

        public long Id { get; set; }

        [Required, Display(Name = "Mã: ")]
        [StringLength(50)]
        public string MaLoai { get; set; }

        [StringLength(250)]
        [Display(Name = "Loại cont: ")]
        public string MoTa { get; set; }

        [StringLength(250)]
        [Display(Name = "Loại hàng: ")]
        public string MoTa1 { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateUpdate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTBill> CTBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }
    }
}
