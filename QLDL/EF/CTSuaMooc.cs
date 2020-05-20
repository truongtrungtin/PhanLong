namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTSuaMooc")]
    public partial class CTSuaMooc
    {
        public long Id { get; set; }

        public long? MaSuaMooc { get; set; }

        public long? NoiDung { get; set; }

        [StringLength(10)]
        public string SoLuong { get; set; }

        public decimal? DonGia { get; set; }

        public virtual DMNoiDung DMNoiDung { get; set; }

        public virtual SuaMooc SuaMooc { get; set; }
    }
}
