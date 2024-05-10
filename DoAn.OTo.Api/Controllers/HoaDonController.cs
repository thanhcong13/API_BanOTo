using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.OTo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HoaDonController : BaseController<HoaDon>
    {
        IHoaDonRepository _hoaDonRepository;
        IHoaDonService _hoaDonService;
        public HoaDonController(IHoaDonRepository hoaDonRepository, IHoaDonService hoaDonService):base(hoaDonRepository, hoaDonService)
        {
            _hoaDonRepository = hoaDonRepository;
            _hoaDonService = hoaDonService;
        }
        [HttpGet]
        public async Task<IActionResult> GetByHoaDon(int page, int pageSize)
        {
            try
            {
                var res = await _hoaDonRepository.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
