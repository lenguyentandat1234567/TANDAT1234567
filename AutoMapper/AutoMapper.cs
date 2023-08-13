using AutoMapper;
using QuanLyThuVien.Models;
using QuanLyThuVien.Models.RequestModels;
using QuanLyThuVien.Models.ResponseModels;
using QuanLyThuVien.Repositories;

namespace QuanLyThuVien.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapSach();
            MapViTri();
            MapLoai();
        }
        private void MapLoai()
        {
            CreateMap<LoaiSach, LoaiSachResponse>().ReverseMap();
            CreateMap<LoaiSachRequest, LoaiSach>().ReverseMap();
        }
        private void MapViTri()
        {
            CreateMap<ViTri, ViTriResponse>().ReverseMap();
            CreateMap<ViTriRequest, ViTri>().ReverseMap();
        }
        private void MapSach()
        {
            CreateMap<Sach, SachResponse>().ReverseMap();
            CreateMap<SachRequest, ThucPham>().ReverseMap();
        }
    }
}