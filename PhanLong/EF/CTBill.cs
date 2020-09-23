namespace PhanLong.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CTBill")]
    public partial class CTBill
    {
        public long Id { get; set; }

        [Display(Name = "Số Bill: ")]
        public long? Bill { get; set; }

        [StringLength(250)]
        [Display(Name = "Số Cont: ")]
        public string Cont { get; set; }

        [StringLength(50)]
        [Display(Name = "Số đăng ký: ")]
        public string SoDK { get; set; }

        [Display(Name = "Loại: ")]
        public long? Loai { get; set; }

        [StringLength(50)]
        [Display(Name = "Seal: ")]
        public string Seal { get; set; }

        [StringLength(25)]
        [Display(Name = "Vị trí: ")]
        public string ViTri { get; set; }

        [Display(Name = "Kho: ")]
        public long? Kho { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Hạn lưu cont: ")]
        public DateTime? HanLuuCont { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Hạn lưu bãi: ")]
        public DateTime? HanLuuBai { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Hạn lưu rỗng: ")]
        public DateTime? HanLuuRong { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày giao:")]
        public DateTime? NgayGiao { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày gửi:")]
        public DateTime? NgayGui { get; set; }

        [StringLength(20)]
        [Display(Name = "Dộ dày: ")]
        public string DoDay { get; set; }

        [StringLength(50)]
        [Display(Name = "Quy cách cont: ")]
        public string QuyCach { get; set; }
        [Display(Name = "Số xe: ")]
        public long? SoXe { get; set; }

        [StringLength(250)]
        [Display(Name = "Ghi chú: ")]
        public string GhiChu { get; set; }

        [Display(Name = "Bãi gửi: ")]
        public long? BaiGui { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateUpdate { get; set; }

        [Column(TypeName = "xml")]
        public string Files { get; set; }

        [Display(Name = "Hạ rỗng: ")]
        public long? HaRong { get; set; }

        public virtual DMBill DMBill { get; set; }

        public virtual DMCang DMCang { get; set; }

        public virtual DMCang DMCang1 { get; set; }

        public virtual DMKho DMKho { get; set; }

        public virtual DMLoai DMLoai { get; set; }

        public virtual DMXe DMXe { get; set; }
    }
}
