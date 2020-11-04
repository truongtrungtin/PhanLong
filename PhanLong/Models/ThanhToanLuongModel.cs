using System.Collections.Generic;

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

        public decimal? tiennang { get; set; }
        public decimal? tienha { get; set; }
        public string phict { get; set; }
        public decimal? tienphict { get; set; }
        public string phikhachhang { get; set; }
        public decimal? tienphikhachhang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhatSinhLuongModel> PhatSinhLuongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiLuongModel> ChiLuongs { get; set; }
    }
}