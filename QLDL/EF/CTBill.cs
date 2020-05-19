namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTBill")]
    public partial class CTBill
    {
        public long Id { get; set; }

        public long? Bill { get; set; }

        [StringLength(250)]
        public string Cont { get; set; }

        [StringLength(50)]
        public string SoDK { get; set; }

        public long? Loai { get; set; }

        [StringLength(50)]
        public string Seal { get; set; }

        public DateTime? HanLuuCont { get; set; }

        public DateTime? HanLuuBai { get; set; }

        public DateTime? HanLuuRong { get; set; }

        public DateTime? NgayGiao { get; set; }

        public int? DoDay { get; set; }

        [StringLength(50)]
        public string QuyCach { get; set; }

        public long? SoXe { get; set; }

        public bool? TrangThaiLuCont { get; set; }

        public bool? TrangThaiLuuBai { get; set; }

        public bool? TrangThaiLuuRong { get; set; }

        public virtual DMBill DMBill { get; set; }
    }
}
