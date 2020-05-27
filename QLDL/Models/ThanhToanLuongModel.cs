using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace QLDL.Models
{
    public partial class ThanhToanLuongModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ThanhToanLuongModel()
        {
            CTTTLuong = new HashSet<CTTTLuongModel>();
        }
        public long Id { get; set; }
        public string MaTX { get; set; }
        public string TaiXe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTTLuongModel> CTTTLuong { get; set; }
    }
}