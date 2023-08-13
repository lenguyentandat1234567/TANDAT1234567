namespace Quan_Ly_Thu_Vien.Models
{
    public class Sach
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public int SoLuong { get; set; }
        public ICollection<LoaiSach_Sach> loaiSach_Sachs { get; set; }
        public ICollection<ViTri_Sach> viTri_Sachs { get; set; }
    }

}