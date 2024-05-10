using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Exceptions;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using DoAn.OTo.Infrastrure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.OTo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CuaHangController : BaseController<CuaHang>
    {
        ICuaHangRepository _cuaHangRepository;
        ICuaHangService _cuaHangService;
        public CuaHangController(ICuaHangRepository cuaHangRepository, ICuaHangService cuaHangService):base(cuaHangRepository , cuaHangService)
        {
            _cuaHangRepository = cuaHangRepository;
            _cuaHangService = cuaHangService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPageCuaHang(int page, int pageSize)
        {
            try
            {
                var res = await _cuaHangRepository.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
