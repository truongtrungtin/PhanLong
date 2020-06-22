namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTChiThu")]
    public partial class CTChiThu
    {
        public long Id { get; set; }

        public long? PhatSinhChiThu { get; set; }

        public long? Mooc { get; set; }

        public long? Xe { get; set; }

        [StringLength(250)]
        public string Cont { get; set; }

        [StringLength(250)]
        public string NoiDung { get; set; }

        public decimal? DonGia { get; set; }

        public int SoLuong { get; set; }

        [StringLength(250)]
        public string Garage { get; set; }

        public long? Phi { get; set; }

        public virtual DMPhi DMPhi { get; set; }

        public virtual DMMooc DMMooc { get; set; }

        public virtual DMXe DMXe { get; set; }

        public virtual PhatSinhChiThu PhatSinhChiThu1 { get; set; }
    }
}
