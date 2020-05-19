namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHoaDon")]
    public partial class CTHoaDon
    {
        public long Id { get; set; }

        public long? HD { get; set; }

        [StringLength(250)]
        public string NoiDung { get; set; }

        public long? SoBill { get; set; }

        [StringLength(50)]
        public string DonVi { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "money")]
        public decimal? DonGia { get; set; }

        public int? Thue { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
