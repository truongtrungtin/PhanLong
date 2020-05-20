namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TamUng")]
    public partial class TamUng
    {
        public long Id { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Ngay { get; set; }

        [Display(Name = "Nhân viên ứng")]
        public long? NVUng { get; set; }

        [Display(Name = "HTTT")]
        public long? HTTT { get; set; }

        [StringLength(250)]
        [Display(Name = "Diễn giải")]
        public string DienGiai { get; set; }

        [Display(Name = "Nội dung")]
        public long? NoiDung { get; set; }

        [Display(Name = "Tiền")]
        public decimal? Tien { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        public virtual DMNhanVien DMNhanVien { get; set; }

        public virtual DMNoiDung DMNoiDung { get; set; }

        public virtual HinhThucTT HinhThucTT { get; set; }
    }
}
