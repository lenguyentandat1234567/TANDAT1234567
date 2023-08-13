using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;
using QuanLyThuVien.Models.RequestModels;
using QuanLyThuVien.Models.ResponseModels;

namespace QuanLyThuVien.Services
{
    public interface ILoaiSachService
    {
        public Task<ICollection<LoaiSach>> GetLoais();
        public Task<LoaiSach> GetLoai(int Id);
        public Task CreateLoai(LoaiSachRequest loai);
        public Task UpdateLoai(int Id, LoaiSachResponse loai);
        public Task DeleteLoai(int Id);
    }
    public class LoaiSachService : ILoaiSachService
    {
        private readonly LoaiSachRepository _loaiSachRepository;
        private readonly IMapper _mapper;
        public LoaiSachService(LoaiSachRepository loaiSachRepository, IMapper mapper)
        {
            _loaiSachRepository = loaiSachRepository;
            _mapper = mapper;
        }


        public async Task CreateLoai(LoaiSachRequest loai)
        {
            var newMap = _mapper.Map<LoaiSach>(loai);
            var newLoai = _loaiSachRepository.Create(newMap);
        }

        public async Task DeleteLoai(int Id)
        {
            await _loaiSachRepository.Delete(Id);
        }

        public async Task<LoaiSach> GetLoai(int Id)
        {
            var loai = await _loaiSachRepository.GetId(Id);
            return loai;
        }

        public async Task<ICollection<LoaiSach>> GetLoais()
        {
            var loai = await _loaiSachRepository.GetAll().ToListAsync();
            return loai;
        }

        public async Task UpdateLoai(int Id, LoaiSachResponse loai)
        {
            if (Id == loai.Id)
            {
                var update = _mapper.Map<LoaiSach>(loai);
                _loaiSachRepository.Edit(update);
            }
        }
    }
}