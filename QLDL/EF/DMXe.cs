namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMXe")]
    public partial class DMXe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMXe()
        {
            PhatSinhs = new HashSet<PhatSinh>();
            SuaXes = new HashSet<SuaXe>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã xe")]
        public string MaXe { get; set; }

        [StringLength(50)]
        [Display(Name = "Biển số")]
        public string BienSo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuaXe> SuaXes { get; set; }
    }
}
