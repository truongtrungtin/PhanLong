namespace PhanLong.EF
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Notification
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        [StringLength(250)]
        public string MaBill { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanLuuBai { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanLuuCont { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HanLuuRong { get; set; }

        [StringLength(250)]
        public string GhiChuBill { get; set; }
    }
}
