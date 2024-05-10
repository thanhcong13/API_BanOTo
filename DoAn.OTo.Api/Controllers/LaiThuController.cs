using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.OTo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LaiThuController : BaseController<LaiThu>
    {
        ILaiThuRepository _laiThuRepository;
        ILaiThuService _laiThuService;
        public LaiThuController(ILaiThuRepository laiThuRepository, ILaiThuService laiThuService):base(laiThuRepository, laiThuService)
        {
            _laiThuRepository = laiThuRepository;
            _laiThuService = laiThuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByLaiThu(int page, int pageSize)
        {
            try
            {
                var res = await _laiThuRepository.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
