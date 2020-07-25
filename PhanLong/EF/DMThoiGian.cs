namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMThoiGian")]
    public partial class DMThoiGian
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMThoiGian()
        {
            PhatSinhs = new HashSet<PhatSinh>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã: ")]
        public string MaTG { get; set; }

        [StringLength(250)]
        [Display(Name = "Thời gian: ")]
        public string ThoiGian { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateUpdate { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }
    }
}
