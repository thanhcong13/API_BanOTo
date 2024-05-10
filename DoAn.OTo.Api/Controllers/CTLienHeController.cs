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
    public class CTLienHeController : BaseController<CTLienHe>
    {
        ICTLienHeRepository _ctLienHeRepository;
        ICTLienHeService _ctLienHeService;
        public CTLienHeController(ICTLienHeRepository ctLienHeRepository, ICTLienHeService ctLienHeService):base(ctLienHeRepository, ctLienHeService)
        {
            _ctLienHeRepository = ctLienHeRepository;
            _ctLienHeService = ctLienHeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPageCTLienHe(int page, int pageSize)
        {
            try
            {
                var res = await _ctLienHeRepository.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
