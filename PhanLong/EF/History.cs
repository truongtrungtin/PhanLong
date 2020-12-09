namespace PhanLong.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("History")]
    public partial class History
    {
        public long Id { get; set; }

        public long? User { get; set; }

        [StringLength(250)]
        public string Icon { get; set; }

        [StringLength(250)]
        public string Action { get; set; }

        [StringLength(250)]
        public string Location { get; set; }

        public DateTime? Time { get; set; }

        public virtual User User1 { get; set; }
    }
}
