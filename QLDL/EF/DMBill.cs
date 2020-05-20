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
            PhatSinhChis = new HashSet<PhatSinhChi>();
            PhatSinhs = new HashSet<PhatSinh>();
            PhatSinhThus = new HashSet<PhatSinhThu>();
        }

        public long Id { get; set; }

        [StringLength(250)]
        [Display(Name = "Mã Bill")]
        public string MaBill { get; set; }

        [Display(Name = "Cảng nhận")]
        public long? CangNhan { get; set; }

        [Display(Name = "Khách hàng")]
        public long? KhachHang { get; set; }

        [Display(Name = "Cảng trả")]
        public long? CangTra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTBill> CTBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhChi> PhatSinhChis { get; set; }

        public virtual DMCang DMCang { get; set; }

        public virtual DMCang DMCang1 { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhThu> PhatSinhThus { get; set; }
    }
}
