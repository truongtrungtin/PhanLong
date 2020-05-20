namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhatSinhThu")]
    public partial class PhatSinhThu
    {
        public long Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayThu { get; set; }

        [StringLength(250)]
        public string NoiDungThu { get; set; }

        [StringLength(50)]
        public string SoHD { get; set; }

        public long? NguoiThu { get; set; }

        public long? Bill { get; set; }

        public long? KhachHang { get; set; }

        public decimal? Tien { get; set; }

        public long? HTTT { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        public virtual DMNhanVien DMNhanVien { get; set; }

        public virtual HinhThucTT HinhThucTT { get; set; }
    }
}
