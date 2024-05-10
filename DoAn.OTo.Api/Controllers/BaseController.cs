using DoAn.OTo.Core.Exceptions;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using DoAn.OTo.Core.Services;
using DoAn.OTo.Infrastrure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

namespace DoAn.OTo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<OToEntity> : ControllerBase
    {
        IBaseRepository<OToEntity> _baseRepository;
        IBaseService<OToEntity> _baseService;
        public BaseController(IBaseRepository<OToEntity> baseRepository, IBaseService<OToEntity> baseService)
        {
            _baseRepository = baseRepository;
            _baseService = baseService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var res = _baseRepository.GetAll();
                return Ok(res);
            }
            catch(ValidateException ex)
            {
                var reponse = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.InnerException,
                };
                return BadRequest(reponse);
            }
            catch(Exception ex)
            {
                var reponse = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ với chúng tôi để được giải quyết",
                    data = ex.InnerException,
                };
                return StatusCode(500, reponse);
            }
        }

        [HttpPost]
        public IActionResult Post(OToEntity entity)
        {
            try
            {
                var data = _baseService.InsertService(entity);
                return Ok(data);
            }
            catch (ValidateException ex)
            {
                var reponse = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.InnerException,
                };
                return BadRequest(reponse);
            }
            catch (Exception ex)
            {
                var reponse = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ với chúng tôi để được giải quyết",
                    data = ex.InnerException,
                };
                return StatusCode(500, reponse);
            }
        }
        [HttpPut("{id}")]
        public IActionResult Put(OToEntity entity , Guid id)
        {
            try
            {
                var data = _baseService.UpdateService(entity, id);
                return Ok(data);
            }
            catch (ValidateException ex)
            {
                var reponse = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.InnerException,
                };
                return BadRequest(reponse);
            }
            catch (Exception ex)
            {
                var reponse = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ với chúng tôi để được giải quyết",
                    data = ex.InnerException,
                };
                return StatusCode(500, reponse);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var data = _baseService.DeleteService(id);
                return Ok(data);
            }
            catch (ValidateException ex)
            {
                var reponse = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = ex.InnerException,
                };
                return BadRequest(reponse);
            }
            catch (Exception ex)
            {
                var reponse = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra vui lòng liên hệ với chúng tôi để được giải quyết",
                    data = ex.InnerException,
                };
                return StatusCode(500, reponse);
            }
        }

       

    }
}
