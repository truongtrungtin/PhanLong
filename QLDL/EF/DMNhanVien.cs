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
            PhatSinhChiThus = new HashSet<PhatSinhChiThu>();
            PhatSinhChiThus1 = new HashSet<PhatSinhChiThu>();
        }

        public long Id { get; set; }

        [Display(Name = "Mã nhân viên: ")]
        [StringLength(50)]
        public string MaNV { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên nhân viên: ")]
        public string TenNV { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhChiThu> PhatSinhChiThus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhChiThu> PhatSinhChiThus1 { get; set; }
    }
}
