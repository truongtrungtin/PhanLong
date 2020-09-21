namespace PhanLong.EF
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Menu")]
    public partial class Menu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu()
        {
            CTMenus = new HashSet<CTMenu>();
        }

        public long Id { get; set; }

        [StringLength(250)]
        public string TenMenu { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        [StringLength(250)]
        public string Icon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTMenu> CTMenus { get; set; }
    }
}
