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

        [Display(Name = "Hóa đơn")]
        public long? HD { get; set; }

        [StringLength(250)]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Display(Name = "Số bill")]
        public long? SoBill { get; set; }

        [StringLength(50)]
        [Display(Name = "Đơn vị")]
        public string DonVi { get; set; }

        [Display(Name = "Số lượng")]
        public int? SoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal? DonGia { get; set; }

        [Display(Name = "Thuế")]
        public int? Thue { get; set; }

        public virtual HoaDon HoaDon { get; set; }
    }
}
