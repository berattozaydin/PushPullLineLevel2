using BlazorBLL.Managers;
using BlazorDAL.Models;
using BlazorDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LevelerController : ControllerBase
    {
        LevelerManager levelerManager;
        public LevelerController(LevelerManager levelerManager)
        {
                this.levelerManager = levelerManager;
        }
        [HttpGet]
        public ReturnResult<List<LEVELER_SETTING>> GetAllLevelerSettingList()
        {
            var res = levelerManager.GetAllLevelerSettingList();
            return res;
        }
        [HttpGet]
        public ReturnResult<LEVELER_SETTING> GetLevelerSetting(int levelerSettingId)
        {
            var res = levelerManager.GetLevelerSetting(levelerSettingId);
            return res;
        }
        [HttpPost]
        public ReturnResult AddLevelerSetting(LEVELER_SETTING levelerSetting)
        {
            var res = levelerManager.AddLevelerSetting(levelerSetting);
            return res;
        }
        [HttpPost]
        public ReturnResult UpdateLevelerSetting(LEVELER_SETTING levelerSetting)
        {
            var res = levelerManager.UpdateLevelerSetting(levelerSetting);
            return res;
        }
        [HttpPost]
        public ReturnResult DeleteLevelerSetting(LEVELER_SETTING levelerSetting)
        {
            var res = levelerManager.DeleteLevelerSetting(levelerSetting);
            return res;
        }
    }
}
