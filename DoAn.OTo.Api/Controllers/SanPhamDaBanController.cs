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
    public class SanPhamDaBanController : BaseController<SanPhamDaBan>
    {
        ISanPhamDaBanRepository _sanPhamDaBanRepository;
        ISanPhaDaBanService _sanPhaDaBanService;
        public SanPhamDaBanController(ISanPhamDaBanRepository sanPhamDaBanRepository, ISanPhaDaBanService sanPhaDaBanService):base(sanPhamDaBanRepository,sanPhaDaBanService)
        {
            _sanPhamDaBanRepository = sanPhamDaBanRepository;
            _sanPhaDaBanService = sanPhaDaBanService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPageSanPhamDaBan(int page, int pageSize)
        {
            try
            {
                var res = await _sanPhamDaBanRepository.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
