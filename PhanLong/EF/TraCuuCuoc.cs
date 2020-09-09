namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TraCuuCuoc")]
    public partial class TraCuuCuoc
    {
        public long Id { get; set; }

        public long? KhachHang { get; set; }

        public long? Kho { get; set; }

        public long? CangNhan { get; set; }

        public long? CangTra { get; set; }

        public decimal? Cuoc { get; set; }

        public decimal? CuocTX { get; set; }

        public virtual DMCang DMCang { get; set; }

        public virtual DMCang DMCang1 { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        public virtual DMKho DMKho { get; set; }
    }
}
