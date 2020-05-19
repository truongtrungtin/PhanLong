namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiPhi")]
    public partial class ChiPhi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiPhi()
        {
            CTChiPhis = new HashSet<CTChiPhi>();
        }

        public long Id { get; set; }

        public DateTime? NgayChi { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        [StringLength(50)]
        public string SoHD { get; set; }

        public long? Bill { get; set; }

        public virtual DMBill DMBill { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTChiPhi> CTChiPhis { get; set; }
    }
}
