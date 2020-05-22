namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMBill")]
    public partial class DMBill
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMBill()
        {
            CTBills = new HashSet<CTBill>();
            PhatSinhs = new HashSet<PhatSinh>();
            PhatSinhChis = new HashSet<PhatSinhChi>();
            PhatSinhThus = new HashSet<PhatSinhThu>();
        }

        public long Id { get; set; }

        [StringLength(250)]
        public string MaBill { get; set; }

        public long? CangNhan { get; set; }

        public long? KhachHang { get; set; }

        public long? CangTra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTBill> CTBills { get; set; }

        public virtual DMCang DMCang { get; set; }

        public virtual DMCang DMCang1 { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhChi> PhatSinhChis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhThu> PhatSinhThus { get; set; }
    }
}
