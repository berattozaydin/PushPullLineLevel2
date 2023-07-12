using BlazorBLL.Managers;
using BlazorDAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        AdminManager adminManager;
        public AdminController(AdminManager adminManager)
        {
            this.adminManager = adminManager;
        }

        [HttpPost]
        public ReturnResult SendRefresh()
        {
            var res = adminManager.SendRefresh();
            return res;
        }
    }
}
