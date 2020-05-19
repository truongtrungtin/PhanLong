namespace QLDL.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLDLContext : DbContext
    {
        public QLDLContext()
            : base("name=QLDLContext")
        {
        }

        public virtual DbSet<ChiPhi> ChiPhis { get; set; }
        public virtual DbSet<CTBill> CTBills { get; set; }
        public virtual DbSet<CTChiPhi> CTChiPhis { get; set; }
        public virtual DbSet<CTHoaDon> CTHoaDons { get; set; }
        public virtual DbSet<CTSuaMooc> CTSuaMoocs { get; set; }
        public virtual DbSet<CTSuaXe> CTSuaXes { get; set; }
        public virtual DbSet<DMBill> DMBills { get; set; }
        public virtual DbSet<DMCang> DMCangs { get; set; }
        public virtual DbSet<DMKhachHang> DMKhachHangs { get; set; }
        public virtual DbSet<DMKho> DMKhoes { get; set; }
        public virtual DbSet<DMLoai> DMLoais { get; set; }
        public virtual DbSet<DMMooc> DMMoocs { get; set; }
        public virtual DbSet<DMNhanVien> DMNhanViens { get; set; }
        public virtual DbSet<DMNoiDung> DMNoiDungs { get; set; }
        public virtual DbSet<DMPhi> DMPhis { get; set; }
        public virtual DbSet<DMXe> DMXes { get; set; }
        public virtual DbSet<HinhThucTT> HinhThucTTs { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<PhatSinh> PhatSinhs { get; set; }
        public virtual DbSet<SuaMooc> SuaMoocs { get; set; }
        public virtual DbSet<SuaXe> SuaXes { get; set; }
        public virtual DbSet<TamUng> TamUngs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiPhi>()
                .Property(e => e.SoHD)
                .IsUnicode(false);

            modelBuilder.Entity<ChiPhi>()
                .HasMany(e => e.CTChiPhis)
                .WithOptional(e => e.ChiPhi1)
                .HasForeignKey(e => e.ChiPhi);

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
                .Property(e => e.QuyCach)
                .IsUnicode(false);

            modelBuilder.Entity<CTChiPhi>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CTHoaDon>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CTSuaMooc>()
                .Property(e => e.SoLuong)
                .IsFixedLength();

            modelBuilder.Entity<CTSuaMooc>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<CTSuaXe>()
                .Property(e => e.SoLuong)
                .IsFixedLength();

            modelBuilder.Entity<CTSuaXe>()
                .Property(e => e.DonGia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DMBill>()
                .HasMany(e => e.ChiPhis)
                .WithOptional(e => e.DMBill)
                .HasForeignKey(e => e.Bill);

            modelBuilder.Entity<DMBill>()
                .HasMany(e => e.CTBills)
                .WithOptional(e => e.DMBill)
                .HasForeignKey(e => e.Bill);

            modelBuilder.Entity<DMCang>()
                .HasMany(e => e.DMBills)
                .WithOptional(e => e.DMCang)
                .HasForeignKey(e => e.CangNhan);

            modelBuilder.Entity<DMCang>()
                .HasMany(e => e.DMBills1)
                .WithOptional(e => e.DMCang1)
                .HasForeignKey(e => e.CangTra);

            modelBuilder.Entity<DMCang>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMCang)
                .HasForeignKey(e => e.CangNhan);

            modelBuilder.Entity<DMCang>()
                .HasMany(e => e.PhatSinhs1)
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
                .WithOptional(e => e.DMKhachHang)
                .HasForeignKey(e => e.KhachHang);

            modelBuilder.Entity<DMKhachHang>()
                .HasMany(e => e.HoaDons)
                .WithOptional(e => e.DMKhachHang)
                .HasForeignKey(e => e.KH);

            modelBuilder.Entity<DMKhachHang>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMKhachHang)
                .HasForeignKey(e => e.KhachHang);

            modelBuilder.Entity<DMKho>()
                .Property(e => e.SoDienThoai)
                .IsUnicode(false);

            modelBuilder.Entity<DMKho>()
                .HasMany(e => e.DMBills)
                .WithOptional(e => e.DMKho)
                .HasForeignKey(e => e.Kho);

            modelBuilder.Entity<DMKho>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMKho)
                .HasForeignKey(e => e.Kho);

            modelBuilder.Entity<DMLoai>()
                .Property(e => e.MaLoai)
                .IsUnicode(false);

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
                .HasMany(e => e.SuaMoocs)
                .WithOptional(e => e.DMMooc)
                .HasForeignKey(e => e.Mooc);

            modelBuilder.Entity<DMNhanVien>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMNhanVien)
                .HasForeignKey(e => e.TenTX);

            modelBuilder.Entity<DMNhanVien>()
                .HasMany(e => e.TamUngs)
                .WithOptional(e => e.DMNhanVien)
                .HasForeignKey(e => e.NVUng);

            modelBuilder.Entity<DMNoiDung>()
                .HasMany(e => e.CTSuaMoocs)
                .WithOptional(e => e.DMNoiDung)
                .HasForeignKey(e => e.NoiDung);

            modelBuilder.Entity<DMNoiDung>()
                .HasMany(e => e.TamUngs)
                .WithOptional(e => e.DMNoiDung)
                .HasForeignKey(e => e.NoiDung);

            modelBuilder.Entity<DMPhi>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMPhi)
                .HasForeignKey(e => e.PhiCT);

            modelBuilder.Entity<DMPhi>()
                .HasMany(e => e.PhatSinhs1)
                .WithOptional(e => e.DMPhi1)
                .HasForeignKey(e => e.PhiKH);

            modelBuilder.Entity<DMXe>()
                .Property(e => e.MaXe)
                .IsUnicode(false);

            modelBuilder.Entity<DMXe>()
                .Property(e => e.BienSo)
                .IsUnicode(false);

            modelBuilder.Entity<DMXe>()
                .HasMany(e => e.PhatSinhs)
                .WithOptional(e => e.DMXe)
                .HasForeignKey(e => e.Xe);

            modelBuilder.Entity<DMXe>()
                .HasMany(e => e.SuaXes)
                .WithOptional(e => e.DMXe)
                .HasForeignKey(e => e.Xe);

            modelBuilder.Entity<HinhThucTT>()
                .Property(e => e.MaHT)
                .IsUnicode(false);

            modelBuilder.Entity<HinhThucTT>()
                .HasMany(e => e.TamUngs)
                .WithOptional(e => e.HinhThucTT)
                .HasForeignKey(e => e.HTTT);

            modelBuilder.Entity<HoaDon>()
                .Property(e => e.SoHD)
                .IsUnicode(false);

            modelBuilder.Entity<HoaDon>()
                .HasMany(e => e.CTHoaDons)
                .WithOptional(e => e.HoaDon)
                .HasForeignKey(e => e.HD);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.SoCont)
                .IsUnicode(false);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.CuocKH)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.CuocTX)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.HDNang)
                .IsUnicode(false);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.TienNang)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.HDHa)
                .IsUnicode(false);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.TienHa)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.TienPhiKH)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.TienPhiCT)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PhatSinh>()
                .Property(e => e.GhiChu)
                .IsFixedLength();

            modelBuilder.Entity<SuaMooc>()
                .Property(e => e.SoHD)
                .IsUnicode(false);

            modelBuilder.Entity<SuaMooc>()
                .HasMany(e => e.CTChiPhis)
                .WithOptional(e => e.SuaMooc)
                .HasForeignKey(e => e.Mooc);

            modelBuilder.Entity<SuaMooc>()
                .HasMany(e => e.CTSuaMoocs)
                .WithOptional(e => e.SuaMooc)
                .HasForeignKey(e => e.MaSuaMooc);

            modelBuilder.Entity<SuaXe>()
                .Property(e => e.SoHD)
                .IsUnicode(false);

            modelBuilder.Entity<SuaXe>()
                .HasMany(e => e.CTChiPhis)
                .WithOptional(e => e.SuaXe)
                .HasForeignKey(e => e.Xe);

            modelBuilder.Entity<SuaXe>()
                .HasMany(e => e.CTSuaXes)
                .WithOptional(e => e.SuaXe)
                .HasForeignKey(e => e.MaSuaXe);

            modelBuilder.Entity<TamUng>()
                .Property(e => e.Tien)
                .HasPrecision(19, 4);
        }
    }
}
