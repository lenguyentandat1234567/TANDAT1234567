namespace QuanLyThuVien.Models
{
    public class LoaiSach
    {
        public int Id { get; set; }
        public string TenLoai { get; set; }
        public ICollection<LoaiSach_Sach> loaiSach_Sachs { get; set; }
    }
}
