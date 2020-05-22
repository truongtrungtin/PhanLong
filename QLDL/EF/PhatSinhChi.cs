namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhatSinhChi")]
    public partial class PhatSinhChi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhatSinhChi()
        {
            CTChis = new HashSet<CTChi>();
        }

        public long Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayChi { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        [StringLength(50)]
        public string SoHD { get; set; }

        public long? Bill { get; set; }

        public long? NguoiChi { get; set; }

        public long? NguoiNhan { get; set; }

        public long? KhachHang { get; set; }

        public decimal? Tien { get; set; }

        public long? HTTT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTChi> CTChis { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        public virtual DMNhanVien DMNhanVien { get; set; }

        public virtual DMNhanVien DMNhanVien1 { get; set; }

        public virtual HinhThucTT HinhThucTT { get; set; }
    }
}
