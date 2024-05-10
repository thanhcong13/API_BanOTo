using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Exceptions;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using DoAn.OTo.Core.Interfaces.Service;
using DoAn.OTo.Core.Services;
using DoAn.OTo.Infrastrure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DoAn.OTo.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupsController : BaseController<Groups>
    {
        IGroupsReporitory _groupsReporitory;
        IGroupsService _groupsService;
        public GroupsController(IGroupsReporitory groupsReporitory, IGroupsService groupsService) : base(groupsReporitory, groupsService)
        {
            _groupsReporitory = groupsReporitory;
            _groupsService = groupsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPageGroups(int page, int pageSize)
        {
            try
            {
                var res = await _groupsReporitory.GetPage(page, pageSize);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{groupId}")]
        public IActionResult DeleteGroup(string groupId)
        {
            try
            {
                var res = _groupsReporitory.Delete(groupId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{GID}")]
        public IActionResult PutGroup(Groups entity, string GID)
        {
            try
            {
                var data = _groupsReporitory.Update(entity, GID);
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
