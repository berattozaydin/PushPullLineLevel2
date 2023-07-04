using BlazorBLL.Managers;
using BlazorDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DelayController : ControllerBase
    {
        DelayManager delayManager;
        public DelayController(DelayManager delayManager)
        {

            this.delayManager=delayManager;

        }
        [HttpGet]
        public ReturnResult<List<DelayDto>> GetDelayList()
        {
            var res = delayManager.GetDelayList();
            return res;
        }
        [HttpGet]
        public ReturnResult<DelayDto> GetDelay(int delayId)
        {
            var res = delayManager.GetDelay(delayId);
            return res;
        }
    }
}
