namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMPhi")]
    public partial class DMPhi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMPhi()
        {
            CTChiThus = new HashSet<CTChiThu>();
            PhatSinhs = new HashSet<PhatSinh>();
            PhatSinhs1 = new HashSet<PhatSinh>();
            SoPhuNganHangs = new HashSet<SoPhuNganHang>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        [Required, Display(Name = "Mã: ")]
        public string MaPhi { get; set; }

        [StringLength(250)]
        [Required, Display(Name = "Tên phí: ")]
        public string TenPhi { get; set; }

        [Display(Name = "Loại phí: ")]
        public long? LoaiPhi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateUpdate { get; set; }

        [Column(TypeName = "xml")]
        public string Files { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTChiThu> CTChiThus { get; set; }

        public virtual LoaiPhi LoaiPhi1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoPhuNganHang> SoPhuNganHangs { get; set; }
    }
}
