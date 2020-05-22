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

        public long? Kho { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanLuuCont { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanLuuBai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanLuuRong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGiao { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayGui { get; set; }

        public int? DoDay { get; set; }

        [StringLength(50)]
        public string QuyCach { get; set; }

        public long? SoXe { get; set; }

        public bool? TrangThaiLuuCont { get; set; }

        public bool? TrangThaiLuuBai { get; set; }

        public bool? TrangThaiLuuRong { get; set; }

        [StringLength(250)]
        public string GhiChu { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMKho DMKho { get; set; }

        public virtual DMLoai DMLoai { get; set; }

        public virtual DMXe DMXe { get; set; }
    }
}
