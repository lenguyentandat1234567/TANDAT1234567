namespace QuanLyThuVien.Models
{
    public class LoaiSach_Sach
    {
        public int SachId { get; set; }
        public int LoaiSachId { get; set; }
        public Sach Sach { get; set; }
        public LoaiSach LoaiSach { get; set; }
    }
}
