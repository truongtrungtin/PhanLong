namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TamUng")]
    public partial class TamUng
    {
        public long Id { get; set; }

        public DateTime? Ngay { get; set; }

        public long? NVUng { get; set; }

        public long? HTTT { get; set; }

        [StringLength(250)]
        public string DienGiai { get; set; }

        public long? NoiDung { get; set; }

        [Column(TypeName = "money")]
        public decimal? Tien { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public virtual DMNhanVien DMNhanVien { get; set; }

        public virtual DMNoiDung DMNoiDung { get; set; }

        public virtual HinhThucTT HinhThucTT { get; set; }
    }
}
