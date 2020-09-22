namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DMMooc")]
    public partial class DMMooc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMMooc()
        {
            PhatSinhChiThus = new HashSet<PhatSinhChiThu>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã: ")]
        public string MaMooc { get; set; }

        [StringLength(50)]
        [Display(Name = "Biển số: ")]
        public string BienSo { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày đăng kiểm: ")]
        public DateTime? NgayDangKiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhChiThu> PhatSinhChiThus { get; set; }
    }
}
