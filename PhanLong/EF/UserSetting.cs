namespace PhanLong.EF
{
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
