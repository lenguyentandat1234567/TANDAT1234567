namespace QuanLyThuVien.Models.ResponseModels
{
    public class LoaiSachResponse
    {
        public int Id { get; set; }
        public string TenLoai { get; set; }
        public List<LoaiSachResponse> sachloaiResponses { get; set; }
    }
}
