namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTChiPhi")]
    public partial class CTChiPhi
    {
        public long Id { get; set; }

        public long? ChiPhi { get; set; }

        public long? NoiDung { get; set; }

        public int? SoLuong { get; set; }

        [Column(TypeName = "money")]
        public decimal? DonGia { get; set; }

        public long? Mooc { get; set; }

        public long? Xe { get; set; }

        public long? Cont { get; set; }

        public virtual ChiPhi ChiPhi1 { get; set; }

        public virtual SuaMooc SuaMooc { get; set; }

        public virtual SuaXe SuaXe { get; set; }
    }
}
