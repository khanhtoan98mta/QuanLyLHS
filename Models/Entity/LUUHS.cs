namespace QLDHS.Models.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LUUHS : DbContext
    {
        public LUUHS()
            : base("name=LUUHS")
        {
        }

        public virtual DbSet<BacDaoTao> BacDaoTaos { get; set; }
        public virtual DbSet<BoMonDaoTao> BoMonDaoTaos { get; set; }
        public virtual DbSet<ChuyenNganhDaoTao> ChuyenNganhDaoTaos { get; set; }
        public virtual DbSet<CoSoDaoTao> CoSoDaoTaos { get; set; }
        public virtual DbSet<DiaBanDaoTao> DiaBanDaoTaos { get; set; }
        public virtual DbSet<DienKinhPhiDaoTao> DienKinhPhiDaoTaos { get; set; }
        public virtual DbSet<DoiTuong> DoiTuongs { get; set; }
        public virtual DbSet<DonVi> DonVis { get; set; }
        public virtual DbSet<HoatDong> HoatDongs { get; set; }
        public virtual DbSet<KetQuaHocTap> KetQuaHocTaps { get; set; }
        public virtual DbSet<KhenThuong> KhenThuongs { get; set; }
        public virtual DbSet<KhoaDaoTao> KhoaDaoTaos { get; set; }
        public virtual DbSet<KyLuat> KyLuats { get; set; }
        public virtual DbSet<LHS_DaoTao> LHS_DaoTao { get; set; }
        public virtual DbSet<LHS_VePhep> LHS_VePhep { get; set; }
        public virtual DbSet<LuanVanTotNghiep> LuanVanTotNghieps { get; set; }
        public virtual DbSet<LuuHocSinh> LuuHocSinhs { get; set; }
        public virtual DbSet<NganhDaoTao> NganhDaoTaos { get; set; }
        public virtual DbSet<QuanHam> QuanHams { get; set; }
        public virtual DbSet<QuaTrinhCongTac> QuaTrinhCongTacs { get; set; }
        public virtual DbSet<QuyetDinhDiHoc> QuyetDinhDiHocs { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThanNhan> ThanNhans { get; set; }
        public virtual DbSet<UserName> UserNames { get; set; }
        public virtual DbSet<VePhep> VePheps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BacDaoTao>()
                .Property(e => e.BacDaoTao1)
                .IsFixedLength();

            modelBuilder.Entity<BoMonDaoTao>()
                .HasMany(e => e.LHS_DaoTao)
                .WithOptional(e => e.BoMonDaoTao)
                .HasForeignKey(e => e.MaBMDaoTao);

            modelBuilder.Entity<ChuyenNganhDaoTao>()
                .HasMany(e => e.LHS_DaoTao)
                .WithOptional(e => e.ChuyenNganhDaoTao)
                .HasForeignKey(e => e.MaCNDaoTao1);

            modelBuilder.Entity<ChuyenNganhDaoTao>()
                .HasMany(e => e.LHS_DaoTao1)
                .WithOptional(e => e.ChuyenNganhDaoTao1)
                .HasForeignKey(e => e.MaCNDaoTao2);

            modelBuilder.Entity<DiaBanDaoTao>()
                .Property(e => e.MaDiaBan)
                .IsUnicode(false);

            modelBuilder.Entity<DonVi>()
                .HasMany(e => e.LuuHocSinhs)
                .WithOptional(e => e.DonVi)
                .HasForeignKey(e => e.MaDVBQP);

            modelBuilder.Entity<KhoaDaoTao>()
                .HasMany(e => e.LHS_DaoTao)
                .WithOptional(e => e.KhoaDaoTao)
                .HasForeignKey(e => e.MaKhoaDaoTao);

            modelBuilder.Entity<LuuHocSinh>()
                .Property(e => e.MaLHS)
                .IsUnicode(false);

            modelBuilder.Entity<LuuHocSinh>()
                .Property(e => e.SoHieuSiQuan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LuuHocSinh>()
                .HasMany(e => e.LHS_DaoTao)
                .WithRequired(e => e.LuuHocSinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LuuHocSinh>()
                .HasMany(e => e.LHS_VePhep)
                .WithRequired(e => e.LuuHocSinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LuuHocSinh>()
                .HasMany(e => e.QuaTrinhCongTacs)
                .WithRequired(e => e.LuuHocSinh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuanHam>()
                .Property(e => e.KiHieu)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThanNhan>()
                .Property(e => e.CanBo)
                .IsFixedLength();

            modelBuilder.Entity<VePhep>()
                .HasMany(e => e.LHS_VePhep)
                .WithRequired(e => e.VePhep)
                .WillCascadeOnDelete(false);
        }
    }
}
