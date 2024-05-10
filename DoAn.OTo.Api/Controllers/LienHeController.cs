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
    public class LienHeController : BaseController<LienHe>
    {
        ILienHeRepository _lienHeRepository;
        ILienHeService _lienHeService;
        public LienHeController(ILienHeRepository lienHeRepository, ILienHeService lienHeService):base(lienHeRepository, lienHeService) 
        {
            _lienHeRepository = lienHeRepository;
            _lienHeService = lienHeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByLienHe(int page, int pageSize)
        {
            try
            {
                var res = await _lienHeRepository.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
