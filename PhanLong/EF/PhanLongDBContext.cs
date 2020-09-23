namespace PhanLong.EF
{
    using System.Data.Entity;

    public partial class PhanLongDBContext : DbContext
    {
        public PhanLongDBContext()
            : base("name=PhanLongDBContext")
        {
        }

        public virtual DbSet<Credential> Credentials { get; set; }
        public virtual DbSet<CTBill> CTBills { get; set; }
        public virtual DbSet<CTChiThu> CTChiThus { get; set; }
        public virtual DbSet<CTMenu> CTMenus { get; set; }
        public virtual DbSet<DMBill> DMBills { get; set; }
        public virtual DbSet<DMCang> DMCangs { get; set; }
        public virtual DbSet<DMKhachHang> DMKhachHangs { get; set; }
        public virtual DbSet<DMKho> DMKhoes { get; set; }
        public virtual DbSet<DMLoai> DMLoais { get; set; }
        public virtual DbSet<DMMooc> DMMoocs { get; set; }
        public virtual DbSet<DMNhanVien> DMNhanViens { get; set; }
        public virtual DbSet<DMPhi> DMPhis { get; set; }
        public virtual DbSet<DMThoiGian> DMThoiGians { get; set; }
        public virtual DbSet<DMXe> DMXes { get; set; }
        public virtual DbSet<HinhThucTT> HinhThucTTs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<LoaiPhi> LoaiPhis { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<PhatSinh> PhatSinhs { get; set; }
        public virtual DbSet<PhatSinhChiThu> PhatSinhChiThus { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SoPhuNganHang> SoPhuNganHangs { get; set; }
        public virtual DbSet<TraCuuCuoc> TraCuuCuocs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CTBill>()
                .Property(e => e.Cont)
                .IsUnicode(false);

            modelBuilder.Entity<CTBill>()
                .Property(e => e.SoDK)
                .IsUnicode(false);

            modelBuilder.Entity<CTBill>()
                .Property(e => e.Seal)
                .IsUnicode(false);

            modelBuilder.Entity<CTBill>()
                .Property(e => e.ViTri)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CTBill>()
                .Property(e => e.DoDay)
                .IsUnicode(false);

            modelBuilder.Entity<CTBill>()
                .Property(e => e.QuyCach)
                .IsUnicode(false);

            modelBuilder.Entity<CTChiThu>()
                .Property(e => e.DonGia)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CTChiThu>()
                .Property(e => e.Files)
                .IsUnicode(false);

            modelBuilder.Entity<DMBill>()
                .Property(e => e.SoToKhai)
                .IsUnicode(false);

            modelBuilder.Entity<DMBill>()
                .Property(e => e.MaBill)
                .IsUnicode(false);

            modelBuilder.Entity<DMBill>()
                .Property(e => e.Lo)
                .IsUnicode(false);

            modelBuilder.Entity<DMBill>()
                .HasMany(e => e.CTBills)
                .WithOptional(e => e.DMBill)
                .HasForeignKey(e => e.Bill);

            modelBuilder.Entity<DMBill>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.DMBill)
                .HasForeignKey(e => e.SoBill);

            modelBuilder.Entity<DMBill>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMBill)
                .HasForeignKey(e => e.SoBill);

            modelBuilder.Entity<DMBill>()
                .HasMany(e => e.PhatSinhChiThus)
                .WithOptional(e => e.DMBill)
                .HasForeignKey(e => e.Bill);

            modelBuilder.Entity<DMCang>()
                .HasMany(e => e.CTBills)
                .WithOptional(e => e.DMCang)
                .HasForeignKey(e => e.BaiGui);

            modelBuilder.Entity<DMCang>()
                .HasMany(e => e.CTBills1)
                .WithOptional(e => e.DMCang1)
                .HasForeignKey(e => e.HaRong);

            modelBuilder.Entity<DMCang>()
                .HasMany(e => e.DMBills)
                .WithOptional(e => e.DMCang)
                .HasForeignKey(e => e.CangNhan);

            modelBuilder.Entity<DMCang>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMCang)
                .HasForeignKey(e => e.CangNhan);

            modelBuilder.Entity<DMCang>()
                .HasMany(e => e.PhatSinhs1)
                .WithOptional(e => e.DMCang1)
                .HasForeignKey(e => e.CangTra);

            modelBuilder.Entity<DMCang>()
                .HasMany(e => e.TraCuuCuocs)
                .WithOptional(e => e.DMCang)
                .HasForeignKey(e => e.CangNhan);

            modelBuilder.Entity<DMCang>()
                .HasMany(e => e.TraCuuCuocs1)
                .WithOptional(e => e.DMCang1)
                .HasForeignKey(e => e.CangTra);

            modelBuilder.Entity<DMKhachHang>()
                .Property(e => e.MST)
                .IsUnicode(false);

            modelBuilder.Entity<DMKhachHang>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<DMKhachHang>()
                .HasMany(e => e.DMBills)
                .WithRequired(e => e.DMKhachHang)
                .HasForeignKey(e => e.KhachHang)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DMKhachHang>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.DMKhachHang)
                .HasForeignKey(e => e.KH);

            modelBuilder.Entity<DMKhachHang>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMKhachHang)
                .HasForeignKey(e => e.KhachHang);

            modelBuilder.Entity<DMKhachHang>()
                .HasMany(e => e.PhatSinhChiThus)
                .WithOptional(e => e.DMKhachHang)
                .HasForeignKey(e => e.KhachHang);

            modelBuilder.Entity<DMKhachHang>()
                .HasMany(e => e.PhatSinhChiThus1)
                .WithOptional(e => e.DMKhachHang1)
                .HasForeignKey(e => e.NguoiNhan);

            modelBuilder.Entity<DMKhachHang>()
                .HasMany(e => e.SoPhuNganHangs)
                .WithOptional(e => e.DMKhachHang)
                .HasForeignKey(e => e.MaKH);

            modelBuilder.Entity<DMKhachHang>()
                .HasMany(e => e.TraCuuCuocs)
                .WithOptional(e => e.DMKhachHang)
                .HasForeignKey(e => e.KhachHang);

            modelBuilder.Entity<DMKho>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<DMKho>()
                .HasMany(e => e.CTBills)
                .WithOptional(e => e.DMKho)
                .HasForeignKey(e => e.Kho);

            modelBuilder.Entity<DMKho>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMKho)
                .HasForeignKey(e => e.Kho);

            modelBuilder.Entity<DMKho>()
                .HasMany(e => e.TraCuuCuocs)
                .WithOptional(e => e.DMKho)
                .HasForeignKey(e => e.Kho);

            modelBuilder.Entity<DMLoai>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

            modelBuilder.Entity<DMLoai>()
                .HasMany(e => e.CTBills)
                .WithOptional(e => e.DMLoai)
                .HasForeignKey(e => e.Loai);

            modelBuilder.Entity<DMLoai>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMLoai)
                .HasForeignKey(e => e.Loai);

            modelBuilder.Entity<DMMooc>()
                .Property(e => e.MaMooc)
                .IsUnicode(false);

            modelBuilder.Entity<DMMooc>()
                .Property(e => e.BienSo)
                .IsUnicode(false);

            modelBuilder.Entity<DMMooc>()
                .HasMany(e => e.PhatSinhChiThus)
                .WithOptional(e => e.DMMooc)
                .HasForeignKey(e => e.Mooc);

            modelBuilder.Entity<DMNhanVien>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMNhanVien)
                .HasForeignKey(e => e.TenTX);

            modelBuilder.Entity<DMNhanVien>()
                .HasMany(e => e.PhatSinhChiThus)
                .WithOptional(e => e.DMNhanVien)
                .HasForeignKey(e => e.NguoiChiThu);

            modelBuilder.Entity<DMPhi>()
                .HasMany(e => e.CTChiThus)
                .WithOptional(e => e.DMPhi)
                .HasForeignKey(e => e.Phi);

            modelBuilder.Entity<DMPhi>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMPhi)
                .HasForeignKey(e => e.PhiCT);

            modelBuilder.Entity<DMPhi>()
                .HasMany(e => e.SoPhuNganHangs)
                .WithOptional(e => e.DMPhi)
                .HasForeignKey(e => e.Phi);

            modelBuilder.Entity<DMThoiGian>()
                .Property(e => e.MaTG)
                .IsUnicode(false);

            modelBuilder.Entity<DMThoiGian>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMThoiGian)
                .HasForeignKey(e => e.Thoigian);

            modelBuilder.Entity<DMXe>()
                .Property(e => e.MaXe)
                .IsUnicode(false);

            modelBuilder.Entity<DMXe>()
                .Property(e => e.BienSo)
                .IsUnicode(false);

            modelBuilder.Entity<DMXe>()
                .HasMany(e => e.CTBills)
                .WithOptional(e => e.DMXe)
                .HasForeignKey(e => e.SoXe);

            modelBuilder.Entity<DMXe>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMXe)
                .HasForeignKey(e => e.Xe);

            modelBuilder.Entity<DMXe>()
                .HasMany(e => e.PhatSinhChiThus)
                .WithOptional(e => e.DMXe)
                .HasForeignKey(e => e.Xe);

            modelBuilder.Entity<HinhThucTT>()
                .Property(e => e.MaHT)
                .IsUnicode(false);

            modelBuilder.Entity<HinhThucTT>()
                .HasMany(e => e.PhatSinhChiThus)
                .WithOptional(e => e.HinhThucTT)
                .HasForeignKey(e => e.HTTT);

            modelBuilder.Entity<HinhThucTT>()
                .HasMany(e => e.SoPhuNganHangs)
                .WithOptional(e => e.HinhThucTT)
                .HasForeignKey(e => e.HTTT);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.SoHD)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.SoCont)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TienCuoc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.ChiHo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.TienThanhToan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<LoaiPhi>()
                .HasMany(e => e.DMPhis)
                .WithOptional(e => e.LoaiPhi1)
                .HasForeignKey(e => e.LoaiPhi);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.CTMenus)
                .WithOptional(e => e.Menu1)
                .HasForeignKey(e => e.Menu);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.CuocKH)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.CuocTX)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.TienNang)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.TienHa)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.TienPhiKH)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.TienPhiCT)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhatSinhChiThu>()
                .HasMany(e => e.CTChiThus)
                .WithOptional(e => e.PhatSinhChiThu1)
                .HasForeignKey(e => e.PhatSinhChiThu);

            modelBuilder.Entity<SoPhuNganHang>()
                .Property(e => e.TienChi)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SoPhuNganHang>()
                .Property(e => e.TienThu)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TraCuuCuoc>()
                .Property(e => e.Cuoc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<TraCuuCuoc>()
                .Property(e => e.CuocTX)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UserGroup>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.UserGroup)
                .HasForeignKey(e => e.GroupID);
        }
    }
}
