namespace QLDL.EF
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
            PhatSinhs = new HashSet<PhatSinh>();
            PhatSinhs1 = new HashSet<PhatSinh>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã phí")]
        public string MaPhi { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên phí")]
        public string TenPhi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs1 { get; set; }
    }
}
