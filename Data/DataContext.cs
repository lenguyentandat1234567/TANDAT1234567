using System.Data.Entity;
using QuanLyThuVien.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace QuanLyThuVien.Data
{
    public class DataContext : DbContext
    {
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];
            return strConn;
        }
        #region DbSet
        public DbSet<LoaiSach> LoaiSachs { get; set; }
        public DbSet<ViTri> ViTris { get; set; }
        public DbSet<Sach> ThucPhams { get; set; }
        public DbSet<LoaiSach_Sach> LoaiSach_Sachs { get; set; }
        public DbSet<ViTri_Sach> ViTri_Sachs { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<LoaiSach_Sach>()
                .HasKey(tp => new { tp.LoaiSachId, tp.SachId });
            modelBuilder.Entity<LoaiSach_Sach>()
                .HasOne(p => p.Sach)
                .WithMany(p => p.loaiSach_Sachs)
                .HasForeignKey(p => p.SachId);
            modelBuilder.Entity<LoaiSach_Sach>()
               .HasOne(p => p.LoaiSach)
               .WithMany(p => p.loaiSach_Sachs)
               .HasForeignKey(p => p.LoaiSachId);
            
            modelBuilder.Entity<ViTri_Sach>()
                .HasKey(vt => new { vt.ViTriId, vt.SachId });
            modelBuilder.Entity<ViTri_Sach>()
                .HasOne(p => p.Sach)
                .WithMany(p => p.viTri_Sachs)
                .HasForeignKey(p => p.SachId);
            modelBuilder.Entity<ViTri_Sach>()
                .HasOne(p => p.ViTri)
                .WithMany(p => p.viTri_Sachs)
                .HasForeignKey(p => p.ViTriId);

        }
    }
}