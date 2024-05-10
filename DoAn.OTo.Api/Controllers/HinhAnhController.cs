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
    public class HinhAnhController : BaseController<HinhAnh>
    {
        IHinhAnhRepository _hinhAnhRepository;
        IHinhAnhService _hinhAnhService;
        public HinhAnhController(IHinhAnhRepository hinhAnhRepository, IHinhAnhService hinhAnhService):base(hinhAnhRepository, hinhAnhService)
        {
            _hinhAnhRepository = hinhAnhRepository;
            _hinhAnhService = hinhAnhService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPageHinhAnh(int page, int pageSize)
        {
            try
            {
                var res = await _hinhAnhRepository.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
