namespace PhanLong.Models
{
    public partial class ThanhToanLuong
    {

        public long IdXe { get; set; }
        public long IdTaiXe { get; set; }
        public int Ngay { get; set; }
        public int SoCont { get; set; }
        public decimal? cuoctx { get; set; }
        public decimal? tiennang { get; set; }
        public decimal? tienha { get; set; }
        public decimal? tienphikh { get; set; }
        public decimal? tienphict { get; set; }
        public decimal? luong { get; set; }
    }
}