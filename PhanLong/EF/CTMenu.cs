namespace PhanLong.EF
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("CTMenu")]
    public partial class CTMenu
    {
        public long Id { get; set; }

        public long? Menu { get; set; }

        [StringLength(250)]
        public string Ten { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        public virtual Menu Menu1 { get; set; }
    }
}
