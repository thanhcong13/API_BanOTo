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
    public class HangXeController : BaseController<HangXe>
    {
        IHangXeRepository _hangXeRepository;
        IHangXeService _hangXeService;
        public HangXeController(IHangXeRepository hangXeRepository, IHangXeService hangXeService):base(hangXeRepository, hangXeService)
        {
            _hangXeRepository = hangXeRepository;
            _hangXeService = hangXeService;
        }


        [HttpGet]
        public async Task<IActionResult> GetPageHangXe(int page, int pageSize)
        {
            try
            {
                var res = await _hangXeRepository.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
