using AutoMapper;
using QuanLyThuVien.Models.RequestModels;
using QuanLyThuVien.Models.ResponseModels;
using QuanLyThuVien.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyThuVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachController : ControllerBase
    {
        private readonly ISachService _SachService;
        private readonly IMapper _mapper;
        public SachController(ISachService SachService, IMapper mapper)
        {
            _SachService = SachService;
            _mapper = mapper;
        }
        [HttpGet("Sach")]
        public async Task<IActionResult> GetSachs()
        {
            var tp = await _SachService.GetSachs();
            return Ok(_mapper.Map<List<SachResponse>>(tp));
        }
        [HttpGet("Sach/{id}")]
        public async Task<IActionResult> GetSach(int id)
        {
            var tp = await _SachService.GetSach(id);
            return Ok(_mapper.Map<SachResponse>(tp));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SachRequest SachRequest)
        {
            await _SachService.CreateSach(SachRequest);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SachResponse SachResponse)
        {
            await _SachService.UpdateSach(id, SachResponse);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _SachService.DeleteSach(id);
            return Ok();
        }
    }
}
