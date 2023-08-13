using AutoMapper;
using QuanLyThuVien.Models;
using QuanLyThuVien.Models.RequestModels;
using QuanLyThuVien.Models.ResponseModels;
using QuanLyThuVien.Repositories;
using QuanLyThuVien.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace QuanLyThuVien.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViTriController : ControllerBase
    {
        private readonly IViTriService _ViTriService;
        private readonly IMapper _mapper;
        public ViTriController(IViTriService ViTriService, IMapper mapper)
        {
            _ViTriService = ViTriService;
            _mapper = mapper;
        }
        [HttpGet("ViTri")]
        public async Task<IActionResult> GetViTris()
        {
            var vt = await _ViTriService.GetViTris();
            return Ok(_mapper.Map<List<ViTriResponse>>(vt));
        }
        [HttpGet("ViTri/{id}")]
        public async Task<IActionResult> GetViTri(int id)
        {
            var vt = await _ViTriService.GetViTri(id);
            return Ok(_mapper.Map<ViTriResponse>(vt));
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ViTriRequest vt)
        {
            await _ViTriService.CreateViTri(vt);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, ViTriResponse ViTriResponse)
        {
            await _ViTriService.UpdateViTri(id, ViTriResponse);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ViTriService.DeleteViTri(id);
            return Ok();
        }
    }
}