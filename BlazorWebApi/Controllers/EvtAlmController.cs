using BlazorBLL.Managers;
using BlazorDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class EvtAlmController : Controller
    {
        EvtAlmManager evtAlmManager;
        public EvtAlmController(EvtAlmManager evtAlmManager)
        {
            this.evtAlmManager = evtAlmManager;
        }
        [HttpPost]
        public ReturnResult<List<EvtAlmDto>> GetAllEvtAlm(EvtAlarmParams baseParameter)
        {
            var res = evtAlmManager.GetAllEvtAlm(baseParameter);
            return res;
        }
    }
}
