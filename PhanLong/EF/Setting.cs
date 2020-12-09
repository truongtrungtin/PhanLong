namespace PhanLong.EF
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Setting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Setting()
        {
            UserSettings = new HashSet<UserSetting>();
        }

        public long Id { get; set; }

        [StringLength(50)]
        public string Function { get; set; }

        [StringLength(50)]
        public string Class { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserSetting> UserSettings { get; set; }
    }
}
