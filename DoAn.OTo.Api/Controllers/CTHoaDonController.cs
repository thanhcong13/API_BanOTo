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
    public class CTHoaDonController : BaseController<CTHoaDon>
    {
        ICTHoaDonRepository _ctHoaDonRepository;
        ICTHoaDonService _ctHoaDonService;
        public CTHoaDonController(ICTHoaDonRepository ctHoaDonRepository, ICTHoaDonService ctHoaDonService):base(ctHoaDonRepository, ctHoaDonService)
        {
            _ctHoaDonRepository = ctHoaDonRepository;
            _ctHoaDonService = ctHoaDonService;
        }
        [HttpGet]
        public async Task<IActionResult> GetPageCtHoaDon(int page, int pageSize)
        {
            try
            {
                var res = await _ctHoaDonRepository.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
