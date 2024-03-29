﻿namespace PhanLong.EF
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HinhThucTT")]
    public partial class HinhThucTT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HinhThucTT()
        {
            PhatSinhChiThus = new HashSet<PhatSinhChiThu>();
            SoPhuNganHangs = new HashSet<SoPhuNganHang>();
        }

        public long Id { get; set; }

        [Required]
        [Display(Name = "Mã: ")]
        [StringLength(50)]
        public string MaHT { get; set; }

        [Required]
        [Display(Name = "Mô tả: ")]
        [StringLength(50)]
        public string MoTa { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhChiThu> PhatSinhChiThus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoPhuNganHang> SoPhuNganHangs { get; set; }
    }
}
