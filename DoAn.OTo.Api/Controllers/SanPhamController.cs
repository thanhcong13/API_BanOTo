using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Exceptions;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using DoAn.OTo.Core.Services;
using DoAn.OTo.Infrastrure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DoAn.OTo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SanPhamController : BaseController<SanPham>
    {
        ISanPhamRepository _sanPhamRepository;
        ISanPhamService _sanPhamService;
        public SanPhamController(ISanPhamRepository sanPhamRepository, ISanPhamService sanPhamService) :base(sanPhamRepository, sanPhamService)
        {
            _sanPhamRepository = sanPhamRepository;
            _sanPhamService = sanPhamService;
        }
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                var res = _sanPhamRepository.GetByName(name);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{MaHang}")]
        public IActionResult GetByHang(Guid MaHang)
        {
            try
            {
                var res = _sanPhamRepository.GetByHang(MaHang);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{MaCH}")]
        public IActionResult GetByMaCH(Guid MaCH)
        {
            try
            {
                var res = _sanPhamRepository.GetByMaCH(MaCH);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPageProduct(int page , int pageSize )
        {
            try
            {
                var res = await _sanPhamRepository.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
