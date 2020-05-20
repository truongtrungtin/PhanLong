namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhatSinh")]
    public partial class PhatSinh
    {
        public long Id { get; set; }
        
        [Column(TypeName = "date")]
        [Required]
        [DataType(DataType.Date)]
        [Display(Name ="Ngày")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime? Ngay { get; set; }

        [Display(Name = "Loại")]
        public long? Loai { get; set; }

        [Display(Name = "Khách hàng")]
        public long? KhachHang { get; set; }

        [Display(Name = "Kho")]
        public long? Kho { get; set; }

        [StringLength(50)]
        [Display(Name = "Số cont")]
        public string SoCont { get; set; }

        [Display(Name = "Số Bill")]
        public long? SoBill { get; set; }

        [Display(Name = "Cảng Nhận")]
        public long? CangNhan { get; set; }

        [Display(Name = "Cảng Trả")]
        public long? CangTra { get; set; }

        [Display(Name = "Cước KH")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal? CuocKH { get; set; }

        [Display(Name = "Cước TX")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal? CuocTX { get; set; }

        [Display(Name = "Tên TX")]
        public long? TenTX { get; set; }

        [Display(Name = "Xe")]
        public long? Xe { get; set; }

        [StringLength(50)]
        [Display(Name = "HD nâng")]
        public string HDNang { get; set; }

        [Display(Name = "Tiền nâng")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal TienNang { get; set; }

        [StringLength(50)]
        [Display(Name = "HD hạ")]
        public string HDHa { get; set; }

        [Display(Name = "Tiền hạ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal? TienHa { get; set; }

        [Display(Name = "Phí KH")]
        public long? PhiKH { get; set; }

        [Display(Name = "Tiền phí KH")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal? TienPhiKH { get; set; }

        [Display(Name = "Phí CT")]
        public long? PhiCT { get; set; }

        [Display(Name = "Tiền phí CT")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N0}")]
        public decimal? TienPhiCT { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú")]
        public string GhiChu { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMCang DMCang { get; set; }

        public virtual DMCang DMCang1 { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        public virtual DMKho DMKho { get; set; }

        public virtual DMLoai DMLoai { get; set; }

        public virtual DMNhanVien DMNhanVien { get; set; }

        public virtual DMPhi DMPhi { get; set; }

        public virtual DMPhi DMPhi1 { get; set; }

        public virtual DMXe DMXe { get; set; }
    }
}
