namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuaXe")]
    public partial class SuaXe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuaXe()
        {
            CTChis = new HashSet<CTChi>();
            CTSuaXes = new HashSet<CTSuaXe>();
        }

        public long Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public long? Xe { get; set; }

        [StringLength(250)]
        public string SoHD { get; set; }

        [StringLength(250)]
        public string Garage { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTChi> CTChis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTSuaXe> CTSuaXes { get; set; }

        public virtual DMXe DMXe { get; set; }
    }
}
