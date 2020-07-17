namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMKhachHang")]
    public partial class DMKhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMKhachHang()
        {
            DMBills = new HashSet<DMBill>();
            HoaDons = new HashSet<HoaDon>();
            PhatSinhs = new HashSet<PhatSinh>();
            PhatSinhChiThus = new HashSet<PhatSinhChiThu>();
        }

        public long Id { get; set; }

        [StringLength(10)]
        
        [Required,Display(Name = "Mã: ")]
        public string MaKH { get; set; }

        [StringLength(250)]
        [Required, Display(Name = "Tên công ty: ")]
        public string TenCongTy { get; set; }

        [StringLength(10)]
        [Display(Name = "MST: ")]
        public string MST { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ: ")]
        public string DiaChi { get; set; }

        [StringLength(250)]
        [Display(Name = "Người liên hệ: ")]
        public string NguoiLienHe { get; set; }

        [StringLength(11)]
        [Display(Name = "Số điện thoại: ")]
        public string SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DMBill> DMBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhChiThu> PhatSinhChiThus { get; set; }
    }
}
