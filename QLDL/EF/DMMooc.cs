﻿namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMMooc")]
    public partial class DMMooc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMMooc()
        {
            SuaMoocs = new HashSet<SuaMooc>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã mooc")]
        public string MaMooc { get; set; }

        [StringLength(50)]
        [Display(Name = "Biển số")]
        public string BienSo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SuaMooc> SuaMoocs { get; set; }
    }
}
