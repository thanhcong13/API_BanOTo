using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using DoAn.OTo.Infrastrure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.OTo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NhanVienController : BaseController<NhanVien>
    {
        INhanVienRepository _nhanVienRepository;
        INhanVienService _nhanVienService;
        public NhanVienController(INhanVienRepository nhanVienRepository, INhanVienService nhanVienService) : base(nhanVienRepository, nhanVienService)
        {
            _nhanVienRepository = nhanVienRepository;
            _nhanVienService = nhanVienService;
        }

        [HttpGet("{MaCH}")]
        public IActionResult GetByCH(Guid MaCH)
        {
            try
            {
                var res = _nhanVienRepository.GetByCH(MaCH);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{MaNV}")]
        public IActionResult DeleteNhanVien(string MaNV)
        {
            try
            {
                var res = _nhanVienRepository.Delete(MaNV);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{MaNV}")]
        public IActionResult UpdateNhanVien(NhanVien nhanVien , string MaNV)
        {
            try
            {
                var res = _nhanVienRepository.Update(nhanVien, MaNV);
                return Ok(res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPageNhanVien(int page, int pageSize)
        {
            try
            {
                var res = await _nhanVienRepository.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
