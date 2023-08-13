namespace QuanLyThuVien.Models.ResponseModels
{
    public class ViTriResponse
    {
        public int Id { get; set; }
        public string Ke { get; set; }
        public List<SachResponse> sachVitriResponses { get; set; }
    }
}
