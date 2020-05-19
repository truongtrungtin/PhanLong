namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTSuaXe")]
    public partial class CTSuaXe
    {
        public long Id { get; set; }

        public long? MaSuaXe { get; set; }

        public long? NoiDung { get; set; }

        [StringLength(10)]
        public string SoLuong { get; set; }

        [Column(TypeName = "money")]
        public decimal? DonGia { get; set; }

        public virtual SuaXe SuaXe { get; set; }
    }
}
