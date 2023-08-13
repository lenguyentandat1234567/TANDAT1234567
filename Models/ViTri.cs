namespace Quan_Ly_Thu_Vien.Models
{
    public class ViTri
    {
        public int Id { get; set; }
        public string Ke { get; set; }
        public ICollection<ViTri_Sach> viTri_Sachs { get; set; }
    }
}