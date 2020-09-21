namespace PhanLong.EF
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Credential")]
    public partial class Credential
    {
        public long Id { get; set; }

        [Required]
        public long UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }
    }
}
