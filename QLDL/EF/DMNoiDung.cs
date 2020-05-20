namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMNoiDung")]
    public partial class DMNoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMNoiDung()
        {
            CTSuaMoocs = new HashSet<CTSuaMooc>();
            TamUngs = new HashSet<TamUng>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mã nội dung")]
        public string MaND { get; set; }

        [StringLength(250)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTSuaMooc> CTSuaMoocs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TamUng> TamUngs { get; set; }
    }
}
