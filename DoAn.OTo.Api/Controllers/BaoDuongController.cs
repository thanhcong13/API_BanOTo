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
    public class BaoDuongController : BaseController<BaoDuong>
    {
        IBaoDuongRepository _baoDuongRepository;
        IBaoDuongService _baoDuongService;
        public BaoDuongController(IBaoDuongRepository baoDuongRepository, IBaoDuongService baoDuongService):base(baoDuongRepository ,baoDuongService)
        {
            _baoDuongRepository = baoDuongRepository;
            _baoDuongService = baoDuongService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPageBaoDuong(int page, int pageSize)
        {
            try
            {
                var res = await _baoDuongRepository.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
