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

        [Display(Name = "Mã sửa xe")]
        public long? MaSuaXe { get; set; }

        [Display(Name = "Nội dung")]
        public long? NoiDung { get; set; }

        [StringLength(10)]
        [Display(Name = "Số lượng")]
        public string SoLuong { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Đơn giá")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal? DonGia { get; set; }

        public virtual SuaXe SuaXe { get; set; }
    }
}
