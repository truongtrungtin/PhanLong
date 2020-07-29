namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Credential")]
    public partial class Credential
    {
        [Key]
        [Column(Order = 0)]
        public long UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string RoleId { get; set; }
    }
}
