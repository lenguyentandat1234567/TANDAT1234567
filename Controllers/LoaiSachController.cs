using AutoMapper;
using QuanLyThuVien.Models;
using QuanLyThuVien.Models.RequestModels;
using QuanLyThuVien.Models.ResponseModels;
using QuanLyThuVien.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyThuVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoaiSachController : ControllerBase
    {
        private readonly ILoaiSachService _LoaiSachService;
        private readonly IMapper _mapper;
        public LoaiSachController(ILoaiSachService LoaiSachService, IMapper mapper)
        {
            _LoaiSachService = LoaiSachService;
            _mapper = mapper;
        }
        [HttpGet("LoaiSach")]
        public async Task<IActionResult> GetLoais()
        {
            var loai = await _LoaiSachService.GetLoais();
            return Ok(_mapper.Map<List< LoaiSachResponse>>(loai));
        }
        [HttpGet("LoaiSach/{id}")]
        public async Task<IActionResult> GetLoaiId(int id)
        {
            var loai = await _LoaiSachService.GetLoai(id);
            return Ok(_mapper.Map< LoaiSachResponse>(loai));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoaiSachRequest LoaiSach)
        {
            await _LoaiSachService.CreateLoai(LoaiSach);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, LoaiSachResponse LoaiSachResponse)
        {
            await _LoaiSachService.UpdateLoai(id, LoaiSachResponse);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _LoaiSachService.DeleteLoai(id);
            return Ok();
        }
    }
}