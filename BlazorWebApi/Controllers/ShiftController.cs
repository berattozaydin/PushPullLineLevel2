using BlazorBLL.Managers;
using BlazorDAL;
using BlazorDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
 
    public class ShiftController : ControllerBase
    {
        ShiftManager shiftManager;
        public ShiftController(ShiftManager shiftManager)
        {
            this.shiftManager = shiftManager;
        }

        [HttpGet]
        public ReturnResult<USER_DATA> GetShift()
        {
            var res = shiftManager.GetShift();
            return res;
        }

        [HttpPost]
        public ReturnResult SetShiftForeman(USER_DATA accountDto) 
        {
            var res = shiftManager.SetShiftForeman(accountDto);
            return res;
        }
    }
}
