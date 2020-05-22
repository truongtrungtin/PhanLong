namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMNhanVien")]
    public partial class DMNhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMNhanVien()
        {
            PhatSinhs = new HashSet<PhatSinh>();
            PhatSinhChis = new HashSet<PhatSinhChi>();
            PhatSinhChis1 = new HashSet<PhatSinhChi>();
            PhatSinhThus = new HashSet<PhatSinhThu>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        public string MaNV { get; set; }

        [StringLength(250)]
        public string TenNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhChi> PhatSinhChis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhChi> PhatSinhChis1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhThu> PhatSinhThus { get; set; }
    }
}
