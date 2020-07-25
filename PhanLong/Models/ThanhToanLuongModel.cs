using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PhanLong.Models
{
    public partial class ThanhToanLuongModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhToanLuongModel()
        {
            PhatSinhLuongs = new HashSet<PhatSinhLuongModel>();
            ChiLuongs = new HashSet<ChiLuongModel>();
        }
        public string TenTX { get; set; }
        public long Xe { get; set; }
        public string Cont { get; set; }

        public decimal? tiencuoc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhLuongModel> PhatSinhLuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiLuongModel> ChiLuongs { get; set; }
    }
}