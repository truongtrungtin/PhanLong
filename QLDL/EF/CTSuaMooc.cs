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

        [Display(Name = "Mã sửa mooc")]
        public long? MaSuaMooc { get; set; }

        [Display(Name = "Nội dung")]
        public long? NoiDung { get; set; }

        [StringLength(10)]
        [Display(Name = "Số lượng")]
        public string SoLuong { get; set; }

        [Display(Name = "Đơn giá")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal? DonGia { get; set; }

        public virtual DMNoiDung DMNoiDung { get; set; }

        public virtual SuaMooc SuaMooc { get; set; }
    }
}
