namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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
        public string MaMooc { get; set; }

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
        public virtual ICollection<PhatSinhChiThu> PhatSinhChiThus { get; set; }
    }
}
