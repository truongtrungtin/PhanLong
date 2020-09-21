namespace PhanLong.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CTChiThu")]
    public partial class CTChiThu
    {
        public long Id { get; set; }

        public long? PhatSinhChiThu { get; set; }

        [StringLength(250)]
        [Display(Name = "Số Cont: ")]
        public string Cont { get; set; }

        [StringLength(250)]
        [Display(Name = "Nội dung: ")]
        public string NoiDung { get; set; }


        [Display(Name = "Đơn giá: ")]
        public decimal? DonGia { get; set; }


        [Display(Name = "Số lượng: ")]
        public int SoLuong { get; set; }

        [StringLength(250)]
        [Display(Name = "Garage: ")]
        public string Garage { get; set; }

        public long? Phi { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateUpdate { get; set; }

        [Column(TypeName = "xml")]
        public string Files { get; set; }

        public virtual DMPhi DMPhi { get; set; }

        public virtual PhatSinhChiThu PhatSinhChiThu1 { get; set; }
    }
}
