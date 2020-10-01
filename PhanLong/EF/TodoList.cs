namespace PhanLong.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("TodoList")]
    public partial class TodoList
    {
        public long Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngay { get; set; }

        [StringLength(250)]
        public string Mota { get; set; }

        public bool? IsActive { get; set; }

        [StringLength(50)]
        public string UserCreate { get; set; }
    }
}
