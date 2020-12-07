namespace PhanLong.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserSetting
    {
        public long Id { get; set; }

        public long? User { get; set; }

        public long? Settings { get; set; }

        public bool? Status { get; set; }

        public virtual Setting Setting { get; set; }

        public virtual User User1 { get; set; }
    }
}
