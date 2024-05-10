using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using DoAn.OTo.Infrastrure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace DoAn.OTo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TaiKhoanController : BaseController<TaiKhoan>
    {
        ITaiKhoanRepository _taiKhoanRepository;
        ITaiKhoanService _taiKhoanService;
        public TaiKhoanController(ITaiKhoanRepository taiKhoanRepository, ITaiKhoanService taiKhoanService) : base(taiKhoanRepository, taiKhoanService)
        {
            _taiKhoanRepository = taiKhoanRepository;
            _taiKhoanService = taiKhoanService;
        }

        [HttpDelete("{TenTaiKhoan}")]
        public IActionResult DeleteAccount(string TenTaiKhoan)
        {
            try
            {
                var res = _taiKhoanRepository.Delete(TenTaiKhoan);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{TenTaiKhoan}")]
        public IActionResult UpdateAccount(TaiKhoan taiKhoan , string TenTaiKhoan)
        {
            try
            {
                var res = _taiKhoanRepository.Update(taiKhoan, TenTaiKhoan);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPageTaiKhoan(int page, int pageSize)
        {
            try
            {
                var res = await _taiKhoanRepository.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
