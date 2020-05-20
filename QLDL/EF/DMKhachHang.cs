namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMKhachHang")]
    public partial class DMKhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMKhachHang()
        {
            DMBills = new HashSet<DMBill>();
            HoaDons = new HashSet<HoaDon>();
            PhatSinhs = new HashSet<PhatSinh>();
            PhatSinhChis = new HashSet<PhatSinhChi>();
            PhatSinhThus = new HashSet<PhatSinhThu>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        public string MaKH { get; set; }

        [StringLength(250)]
        public string TenCongTy { get; set; }

        [StringLength(10)]
        public string MST { get; set; }

        [StringLength(250)]
        public string DiaChi { get; set; }

        [StringLength(250)]
        public string NguoiLienHe { get; set; }

        [StringLength(11)]
        public string SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DMBill> DMBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhChi> PhatSinhChis { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhThu> PhatSinhThus { get; set; }
    }
}
