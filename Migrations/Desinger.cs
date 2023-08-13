using QuanLyThuVien.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuanLyThuVien.Data;

#nullable disable

namespace QuanLyThuVien.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("_dbinit")]
    partial class dbinit
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QuanLyThuVien.Models.LoaiSach", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("TenLoai")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("LoaiSachs");
            });

            modelBuilder.Entity("QuanLyThuVien.Models.LoaiSach_Sach", b =>
            {
                b.Property<int>("LoaiSachId")
                    .HasColumnType("int");

                b.Property<int>("SachId")
                    .HasColumnType("int");

                b.HasKey("LoaiSachId", "SachId");

                b.HasIndex("SachId");

                b.ToTable("LoaiSach_Sachs");
            });

            modelBuilder.Entity("QuanLyThuVien.Models.Sach", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<int>("SoLuong")
                    .HasColumnType("int");

                b.Property<string>("Ten")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("Sachs");
            });

            modelBuilder.Entity("QuanLyThuVien.Models.ViTri", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                b.Property<string>("Ke")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Id");

                b.ToTable("ViTris");
            });

            modelBuilder.Entity("QuanLyThuVien.Models.ViTri_Sach", b =>
            {
                b.Property<int>("ViTriId")
                    .HasColumnType("int");

                b.Property<int>("SachId")
                    .HasColumnType("int");

                b.HasKey("ViTriId", "SachId");

                b.HasIndex("SachId");

                b.ToTable("ViTri_Sachs");
            });

            modelBuilder.Entity("QuanLyThuVien.Models.LoaiSach_Sach", b =>
            {
                b.HasOne("QuanLyThuVien.Models.LoaiSach", "LoaiSach")
                    .WithMany("loaiSach_Sachs")
                    .HasForeignKey("LoaiSachId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("QuanLyThuVien.Models.Sach", "Sach")
                    .WithMany("loaiSach_Sachs")
                    .HasForeignKey("SachId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("LoaiSach");

                b.Navigation("Sach");
            });

            modelBuilder.Entity("QuanLyThuVien.Models.ViTri_Sach", b =>
            {
                b.HasOne("QuanLyThuVien.Models.Sach", "Sach")
                    .WithMany("viTri_Sachs")
                    .HasForeignKey("SachId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("QuanLyThuVien.Models.ViTri", "ViTri")
                    .WithMany("viTri_Sachs")
                    .HasForeignKey("ViTriId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Sach");

                b.Navigation("ViTri");
            });

            modelBuilder.Entity("QuanLyThuVien.Models.LoaiSach", b =>
            {
                b.Navigation("loaiSach_Sachs");
            });

            modelBuilder.Entity("QuanLyThuVien.Models.Sach", b =>
            {
                b.Navigation("loaiSach_Sachs");

                b.Navigation("viTri_Sachs");
            });

            modelBuilder.Entity("QuanLyThuVien.Models.ViTri", b =>
            {
                b.Navigation("viTri_Sachs");
            });

        }
    }
}