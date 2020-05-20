namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SuaMooc")]
    public partial class SuaMooc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SuaMooc()
        {
            CTChis = new HashSet<CTChi>();
            CTSuaMoocs = new HashSet<CTSuaMooc>();
        }

        public long Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public long? Mooc { get; set; }

        [StringLength(250)]
        public string SoHD { get; set; }

        [StringLength(250)]
        public string Garage { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTChi> CTChis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTSuaMooc> CTSuaMoocs { get; set; }

        public virtual DMMooc DMMooc { get; set; }
    }
}
