namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
        public string MaXe { get; set; }

        [StringLength(50)]
        public string BienSo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDangKiem { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanDangKiem { get; set; }

        [StringLength(100)]
        public string NhanHieu { get; set; }

        [StringLength(100)]
        public string SoKhung { get; set; }

        [StringLength(50)]
        public string NamSanXuat { get; set; }

        [StringLength(100)]
        public string NuocSanXuat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanSuDung { get; set; }

        [StringLength(100)]
        public string TaiTrong { get; set; }

        [StringLength(100)]
        public string LoaiVo { get; set; }

        public bool? Ruot { get; set; }

        public int? SoLuongVo { get; set; }

        [StringLength(100)]
        public string NguoiBan { get; set; }

        [StringLength(500)]
        public string HopDong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayMua { get; set; }

        public decimal? SoTien { get; set; }

        [StringLength(100)]
        public string SoHoaDon { get; set; }

        [StringLength(500)]
        public string GhiChu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTBill> CTBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhChiThu> PhatSinhChiThus { get; set; }
    }
}
