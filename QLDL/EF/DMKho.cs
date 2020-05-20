namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMKho")]
    public partial class DMKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMKho()
        {
            CTBills = new HashSet<CTBill>();
            PhatSinhs = new HashSet<PhatSinh>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã kho")]
        public string MaKho { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(250)]
        [Display(Name = "Người liên hệ")]
        public string NguoiLienHe { get; set; }

        [StringLength(11)]
        [Display(Name = "Số điện thoại")]
        public string SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTBill> CTBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }
    }
}
