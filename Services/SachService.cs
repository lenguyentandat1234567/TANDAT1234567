using QuanLyThuVien.Models.RequestModels;
using QuanLyThuVien.Models;
using QuanLyThuVien.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuanLyThuVien.Models.ResponseModels;

namespace QuanLyThuVien.Services
{
    public interface ISachService
    {
        public Task<ICollection<Sach>> GetSachs();
        public Task<Sach> GetSach(int Id);
        public Task CreateSach(SachRequest loai);
        public Task UpdateSach(int Id, SachResponse SachResponse);
        public Task DeleteSach(int Id);
    }
    public class SachService : ISachService
    {
        private readonly SachRepository _SachRepository;
        private readonly IMapper _mapper;
        public SachService(SachRepository SachRepository, IMapper mapper)
        {
            _SachRepository = SachRepository;
            _mapper = mapper;
        }

        public Task CreateSach(SachRequest loai)
        {
            var newMap = _mapper.Map<Sach>(loai);
            var newtp = _SachRepository.Create(newMap);
            return newtp;
        }

        public async Task DeleteSach(int Id)
        {
            await _SachRepository.Delete(Id);
        }

        public async Task<Sach> GetSach(int Id)
        {
            var tp = await _SachRepository.GetId(Id);
            return tp;
        }

        public async Task<ICollection<Sach>> GetSachs()
        {
            var tp = await _SachRepository.GetAll().ToListAsync();
            return tp;
        }

        public async Task UpdateSach(int Id, SachResponse SachResponse)
        {
            if (Id == SachResponse.Id)
            {
                var update = _mapper.Map<Sach>(SachResponse);
                _SachRepository.Edit(update);
            }
        }
    }
}