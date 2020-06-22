namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhatSinhChiThu")]
    public partial class PhatSinhChiThu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhatSinhChiThu()
        {
            CTChiThus = new HashSet<CTChiThu>();
        }

        public long Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngay { get; set; }

        public long? NguoiChiThu { get; set; }

        public long? NguoiNhan { get; set; }

        public long? HTTT { get; set; }

        public long? KhachHang { get; set; }

        public long? Bill { get; set; }

        [StringLength(50)]
        public string SoHD { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTChiThu> CTChiThus { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        public virtual DMNhanVien DMNhanVien { get; set; }

        public virtual DMNhanVien DMNhanVien1 { get; set; }

        public virtual HinhThucTT HinhThucTT { get; set; }
    }
}
