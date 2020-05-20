namespace QLDL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("DMKho")]
    public partial class DMKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DMKho()
        {
            DMBills = new HashSet<DMBill>();
            PhatSinhs = new HashSet<PhatSinh>();
        }

        public long Id { get; set; }

        [StringLength(50), DisplayName("Mã kho")]
        public string MaKho { get; set; }

        [StringLength(250), DisplayName("Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(250), DisplayName("Người liên hệ")]
        public string NguoiLienHe { get; set; }

        [StringLength(11), DisplayName("Số điện thoại")]
        public string SoDienThoai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DMBill> DMBills { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinh> PhatSinhs { get; set; }
    }
}
