namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("DMXe")]
    public partial class DMXe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMXe()
        {
            CTBills = new HashSet<CTBill>();
            PhatSinhs = new HashSet<PhatSinh>();
            PhatSinhChiThus = new HashSet<PhatSinhChiThu>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã: ")]
        public string MaXe { get; set; }

        [StringLength(50)]
        [Display(Name = "Biển số: ")]
        public string BienSo { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày đăng kiểm: ")]
        public DateTime? NgayDangKiem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTBill> CTBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhChiThu> PhatSinhChiThus { get; set; }
    }
}
