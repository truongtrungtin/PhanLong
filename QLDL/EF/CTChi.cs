namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTChi")]
    public partial class CTChi
    {
        public long Id { get; set; }

        [Display(Name = "Phát sinh chi")]
        public long? PhatSinhChi { get; set; }

        [Display(Name = "Nội dung")]
        public long? NoiDung { get; set; }

        [Display(Name = "Số lượng")]
        public int? SoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal? DonGia { get; set; }

        [Display(Name = "Số mooc")]
        public long? Mooc { get; set; }

        [Display(Name = "Số xe")]
        public long? Xe { get; set; }

        [Display(Name = "Số cont")]
        public long? Cont { get; set; }

        public virtual PhatSinhChi PhatSinhChi1 { get; set; }

        public virtual SuaMooc SuaMooc { get; set; }

        public virtual SuaXe SuaXe { get; set; }
    }
}
