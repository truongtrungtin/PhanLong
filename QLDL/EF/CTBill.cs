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

        [Display(Name = "Số Bill")]
        public long? Bill { get; set; }

        [StringLength(250)]
        [Display(Name = "Số cont")]
        public string Cont { get; set; }

        [StringLength(50)]
        [Display(Name = "Số DK")]
        public string SoDK { get; set; }

        [Display(Name = "Loại")]
        public long? Loai { get; set; }

        [StringLength(50)]
        [Display(Name = "Seal")]
        public string Seal { get; set; }

        [Display(Name = "Kho")]
        public long? Kho { get; set; }

        [Column(TypeName = "date")]
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hạn lưu cont")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? HanLuuCont { get; set; }

        [Column(TypeName = "date")]
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hạn lưu bãi")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? HanLuuBai { get; set; }

        [Column(TypeName = "date")]
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Hạn lưu rỗng")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? HanLuuRong { get; set; }

        [Column(TypeName = "date")]
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày giao")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayGiao { get; set; }

        [Column(TypeName = "date")]
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày gửi bãi")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayGui { get; set; }

        [Display(Name = "Độ dày")]
        public int? DoDay { get; set; }

        [StringLength(50)]
        [Display(Name = "Qui cách")]
        public string QuyCach { get; set; }

        [Display(Name = "Số xe")]
        public long? SoXe { get; set; }

        [Display(Name = "TT lưu cont")]
        public bool? TrangThaiLuuCont { get; set; }

        [Display(Name = "TT lưu bãi")]
        public bool? TrangThaiLuuBai { get; set; }

        [Display(Name = "TT lưu rỗng")]
        public bool? TrangThaiLuuRong { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMKho DMKho { get; set; }

        public virtual DMLoai DMLoai { get; set; }
    }
}
