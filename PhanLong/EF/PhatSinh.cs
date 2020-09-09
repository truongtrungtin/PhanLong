namespace PhanLong.EF
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
        [Display(Name = "Ngày: ")]
        public DateTime Ngay { get; set; }

        [Display(Name = "Loại: ")]
        public long? Loai { get; set; }
        [Display(Name = "Khách hàng: ")]
        public long? KhachHang { get; set; }
        [Display(Name = "Kho: ")]
        public long? Kho { get; set; }

        [StringLength(50)]
        [Display(Name = "Số Cont: ")]
        public string SoCont { get; set; }
        [Display(Name = "Số Bill: ")]
        public long? SoBill { get; set; }
        [Display(Name = "Cảng nhận: ")]
        public long? CangNhan { get; set; }
        [Display(Name = "Cảng trả: ")]
        public long? CangTra { get; set; }
        [Display(Name = "Cước khách hàng: ")]

        public decimal? CuocKH { get; set; }
        [Display(Name = "Cước tài xế: ")]

        public decimal? CuocTX { get; set; }
        [Display(Name = "Tên tài xế: ")]
        public long? TenTX { get; set; }
        [Display(Name = "Xe: ")]
        public long? Xe { get; set; }

        [StringLength(50)]
        [Display(Name = "Hoá đơn nâng: ")]
        public string HDNang { get; set; }
        [Display(Name = "Tiền nâng: ")]
        public decimal? TienNang { get; set; }

        [StringLength(50)]
        [Display(Name = "Hoá đơn hạ: ")]
        public string HDHa { get; set; }
        [Display(Name = "Tiền hạ: ")]
        public decimal? TienHa { get; set; }
        [Display(Name = "Phí khách hàng: ")]
        [StringLength(250)]
        public string PhiKH { get; set; }
        [Display(Name = "Tiền phí KH: ")]
        public decimal? TienPhiKH { get; set; }
        [Display(Name = "Phí công ty: ")]
        public long? PhiCT { get; set; }
        [Display(Name = "Tiền phí công ty: ")]
        public decimal? TienPhiCT { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú: ")]
        public string GhiChu { get; set; }
   
        [StringLength(250)]
        [Display(Name = "Ghi chú lương: ")]
        public string GhiChuLuong { get; set; }
        [Display(Name = "Thời gian: ")]
        public long? Thoigian { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateUpdate { get; set; }

        [Column(TypeName = "xml")]
        public string Files { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMCang DMCang { get; set; }

        public virtual DMCang DMCang1 { get; set; }

        public virtual DMKhachHang DMKhachHang { get; set; }

        public virtual DMKho DMKho { get; set; }

        public virtual DMLoai DMLoai { get; set; }

        public virtual DMNhanVien DMNhanVien { get; set; }

        public virtual DMPhi DMPhi { get; set; }

        public virtual DMThoiGian DMThoiGian { get; set; }

        public virtual DMXe DMXe { get; set; }
    }
}
