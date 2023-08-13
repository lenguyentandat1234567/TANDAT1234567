namespace QuanLyThuVien.Models
{
    public class ViTri_Sach
    {
        public int ViTriId { get; set; }
        public int SachId { get; set; }
        public ViTri ViTri { get; set; }
        public Sach Sach { get; set; }
    }
}
